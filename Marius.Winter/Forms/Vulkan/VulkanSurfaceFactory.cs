using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using NvgSharp.OpenTK.Vulkan;
using OpenTK.Graphics;
using OpenTK.Graphics.Vulkan;
using OpenTK.Mathematics;
using OpenTK.Platform;

namespace Marius.Winter.Forms.Vulkan;

public unsafe class VulkanSurfaceFactory : SurfaceFactory
{
    private readonly bool _enableDebugLayer;

    private VkDebugUtilsMessengerEXT _debugMessenger;

    public VulkanSurfaceFactory(bool enableDebugLayer = true)
    {
        _enableDebugLayer = enableDebugLayer;
    }

    public override Surface Create(Vector2i size, bool isFullScreen, bool resizable)
    {
        VKLoader.Init();

        var instance = CreateVkInstance(_enableDebugLayer);
        var window = Toolkit.Window.Create(new VulkanGraphicsApiHints { });
        var result = Toolkit.Vulkan.CreateWindowSurface(instance, window, null, out var surface);

        var gpuCount = 0U;
        result = Vk.EnumeratePhysicalDevices(instance, &gpuCount, null);
        if (result != VkResult.Success && result != VkResult.Incomplete)
            throw new Exception($"Failed to enumerate physical devices: {result}");

        var gpu = stackalloc VkPhysicalDevice[(int)gpuCount];
        result = Vk.EnumeratePhysicalDevices(instance, &gpuCount, gpu);

        var idx = 0U;
        var useIdx = false;
        var discreteIdx = false;
        for (var i = 0; i < gpuCount; i++)
        {
            var queueCount = 0U;
            Vk.GetPhysicalDeviceQueueFamilyProperties(gpu[i], &queueCount, null);

            var queueProperties = new VkQueueFamilyProperties[(int)queueCount];
            fixed (VkQueueFamilyProperties* ptr = queueProperties)
                Vk.GetPhysicalDeviceQueueFamilyProperties(gpu[i], &queueCount, ptr);

            for (var m = 0U; m < queueCount; m++)
            {
                var supported = 0;
                Vk.GetPhysicalDeviceSurfaceSupportKHR(gpu[i], m, surface, &supported);
                if ((queueProperties[m].queueFlags & VkQueueFlagBits.QueueGraphicsBit) != 0 && supported != 0)
                {
                    var pr = default(VkPhysicalDeviceProperties);
                    Vk.GetPhysicalDeviceProperties(gpu[i], &pr);

                    idx = (uint)i;
                    useIdx = true;
                    if (pr.deviceType == VkPhysicalDeviceType.PhysicalDeviceTypeDiscreteGpu)
                        discreteIdx = true;
                    break;
                }
            }
        }

        if (!useIdx)
            throw new Exception("No suitable GPU found");

        var device = CreateVulkanDevice(gpu[idx], surface, _enableDebugLayer, out var ext);

        var executionQueue = default(VkQueue);
        var presentQueue = default(VkQueue);
        Vk.GetDeviceQueue(device.Device, device.GraphicsQueueFamilyIndex, 0, &executionQueue);
        Vk.GetDeviceQueue(device.Device, device.PresentIndex, 0, &presentQueue);

        if (!resizable)
            Toolkit.Window.SetBorderStyle(window, WindowBorderStyle.FixedBorder);

        return new VulkanSurface(window, device, surface, executionQueue, presentQueue, ext);
    }

    private VkInstance CreateVkInstance(bool enableDebugLayer)
    {
        var applicationInfo = new VkApplicationInfo
        {
            apiVersion = Vk.VK_API_VERSION_1_0,
            applicationVersion = 1,
            engineVersion = 1,
        };

        var required = Toolkit.Vulkan.GetRequiredInstanceExtensions();
        var extensions = stackalloc byte*[required.Length + 2];

        var target = extensions;
        *target++ = (byte*)Marshal.StringToCoTaskMemUTF8(Vk.KhrGetPhysicalDeviceProperties2ExtensionName);
        *target++ = (byte*)Marshal.StringToCoTaskMemUTF8(Vk.ExtDebugUtilsExtensionName);
        for (var i = 0; i < required.Length; i++)
            *target++ = (byte*)Marshal.StringToCoTaskMemUTF8(required[i]);

        var instanceInfo = new VkInstanceCreateInfo
        {
            sType = VkStructureType.StructureTypeInstanceCreateInfo,
            pApplicationInfo = &applicationInfo,
            enabledExtensionCount = (uint)required.Length + 2,
            ppEnabledExtensionNames = extensions,
        };

        var layers = stackalloc byte*[1];
        if (enableDebugLayer)
        {
            layers[0] = (byte*)Marshal.StringToCoTaskMemAnsi("VK_LAYER_KHRONOS_validation");
            instanceInfo.enabledLayerCount = 1;
            instanceInfo.ppEnabledLayerNames = layers;
        }

        var layerCount = 0U;
        Vk.EnumerateInstanceLayerProperties(&layerCount, null);
        var properties = stackalloc VkLayerProperties[(int)layerCount];
        Vk.EnumerateInstanceLayerProperties(&layerCount, properties);
        for (var i = 0; i < layerCount; i++)
        {
            var name = properties[i].layerName;
            var version = properties[i].specVersion;

            var nameSpan = new string((sbyte*)&name.element);
            Console.WriteLine($"Layer: {nameSpan}, Version: {version}");
        }

        var instance = default(VkInstance);
        var result = Vk.CreateInstance(&instanceInfo, null, &instance);
        if (result != VkResult.Success)
            throw new Exception($"Failed to create Vulkan instance: {result}");

        for (var i = 0; i < required.Length + 2; i++)
            Marshal.FreeCoTaskMem((nint)extensions[i]);

        if (enableDebugLayer)
            Marshal.FreeCoTaskMem((nint)layers[0]);

        if (enableDebugLayer)
        {
            var debugInfo = new VkDebugUtilsMessengerCreateInfoEXT
            {
                sType = VkStructureType.StructureTypeDebugUtilsMessengerCreateInfoExt,
                messageSeverity = VkDebugUtilsMessageSeverityFlagBitsEXT.DebugUtilsMessageSeverityVerboseBitExt |
                    VkDebugUtilsMessageSeverityFlagBitsEXT.DebugUtilsMessageSeverityInfoBitExt |
                    VkDebugUtilsMessageSeverityFlagBitsEXT.DebugUtilsMessageSeverityWarningBitExt |
                    VkDebugUtilsMessageSeverityFlagBitsEXT.DebugUtilsMessageSeverityErrorBitExt,
                messageType = VkDebugUtilsMessageTypeFlagBitsEXT.DebugUtilsMessageTypeGeneralBitExt | VkDebugUtilsMessageTypeFlagBitsEXT.DebugUtilsMessageTypeValidationBitExt | VkDebugUtilsMessageTypeFlagBitsEXT.DebugUtilsMessageTypePerformanceBitExt,
            };

            delegate* unmanaged[Cdecl]<VkDebugUtilsMessageSeverityFlagBitsEXT, VkDebugUtilsMessageTypeFlagBitsEXT, VkDebugUtilsMessengerCallbackDataEXT*, void*, int> debugCallback = &DebugCallback;
            debugInfo.pfnUserCallback = debugCallback;
            var vkCreateDebugUtilsMessengerEXT = (delegate* unmanaged<VkInstance, VkDebugUtilsMessengerCreateInfoEXT*, VkAllocationCallbacks*, VkDebugUtilsMessengerEXT*, VkResult>)Vk.GetInstanceProcAddr(instance, (byte*)Marshal.StringToCoTaskMemUTF8("vkCreateDebugUtilsMessengerEXT"));
            if (vkCreateDebugUtilsMessengerEXT == null)
            {
                Console.WriteLine("vkCreateDebugUtilsMessengerEXT not found");
            }
            else
            {
                fixed (VkDebugUtilsMessengerEXT* ptr = &_debugMessenger)
                {
                    var res = vkCreateDebugUtilsMessengerEXT(instance, &debugInfo, null, ptr);
                    if (res != VkResult.Success)
                    {
                        _debugMessenger = VkDebugUtilsMessengerEXT.Zero;
                        Console.WriteLine("CreateDebugUtilsMessengerEXT failed ({0})", res);
                    }
                }
            }
        }

        return instance;
    }

    private static VulkanDevice CreateVulkanDevice(VkPhysicalDevice physicalDevice, VkSurfaceKHR surface, bool isDebugEnabled, out VkNvgExt ext)
    {
        var device = new VulkanDevice
        {
            PhysicalDevice = physicalDevice,
        };
        Vk.GetPhysicalDeviceMemoryProperties(physicalDevice, &device.PhysicalDeviceMemoryProperties);
        Vk.GetPhysicalDeviceProperties(physicalDevice, &device.PhysicalDeviceProperties);

        var queueFamilyPropertiesCount = 0U;
        Vk.GetPhysicalDeviceQueueFamilyProperties(physicalDevice, &queueFamilyPropertiesCount, null);

        device.QueueFamilyProperties = new VkQueueFamilyProperties[queueFamilyPropertiesCount];

        fixed (VkQueueFamilyProperties* ptr = device.QueueFamilyProperties)
            Vk.GetPhysicalDeviceQueueFamilyProperties(physicalDevice, &queueFamilyPropertiesCount, ptr);

        device.GraphicsQueueFamilyIndex = uint.MaxValue;
        device.PresentIndex = uint.MaxValue;
        for (var i = 0U; i < device.QueueFamilyProperties.Length; ++i)
        {
            var properties = device.QueueFamilyProperties[i];
            if ((properties.queueFlags & VkQueueFlagBits.QueueGraphicsBit) != 0)
                device.GraphicsQueueFamilyIndex = i;

            var presentSupport = 0;
            Vk.GetPhysicalDeviceSurfaceSupportKHR(physicalDevice, i, surface, &presentSupport);
            if (presentSupport != 0)
                device.PresentIndex = i;

            if (device.PresentIndex != uint.MaxValue && device.GraphicsQueueFamilyIndex != uint.MaxValue)
                break;
        }

        var queuePriorities = stackalloc float[1] { 0.0f };
        var queueCreateInfo = new VkDeviceQueueCreateInfo
        {
            sType = VkStructureType.StructureTypeDeviceQueueCreateInfo,
            queueCount = 1,
            pQueuePriorities = queuePriorities,
            queueFamilyIndex = device.GraphicsQueueFamilyIndex,
        };

        var extendedDynamicStateFeatures = new VkPhysicalDeviceExtendedDynamicStateFeaturesEXT
        {
            sType = VkStructureType.StructureTypePhysicalDeviceExtendedDynamicStateFeaturesExt,
        };
        var extendedDynamicState3Features = new VkPhysicalDeviceExtendedDynamicState3FeaturesEXT
        {
            sType = VkStructureType.StructureTypePhysicalDeviceExtendedDynamicState3FeaturesExt,
        };

        extendedDynamicStateFeatures.pNext = &extendedDynamicState3Features;

        //Provided by VK_VERSION_1_1 or VK_KHR_get_physical_device_properties2/VK_KHR_GET_PHYSICAL_DEVICE_PROPERTIES_2_EXTENSION_NAME
        var physicalDeviceFeatures2 = new VkPhysicalDeviceFeatures2
        {
            sType = VkStructureType.StructureTypePhysicalDeviceFeatures2,
            pNext = &extendedDynamicStateFeatures,
        };
        Vk.GetPhysicalDeviceFeatures2(physicalDevice, &physicalDeviceFeatures2);

        var count = 0U;

        Vk.EnumerateDeviceExtensionProperties(physicalDevice, null, &count, null);

        ext = new VkNvgExt();

        var enableDynamicState = false;
        var enableDynamicState3 = false;
        var enabledExtensionCount = 1;
        var enabledExtensions = stackalloc byte*[16];

        var extensions = new VkExtensionProperties[count];
        fixed (VkExtensionProperties* ptr = extensions)
        {
            Vk.EnumerateDeviceExtensionProperties(physicalDevice, null, &count, ptr);

            physicalDeviceFeatures2.pNext = null;
            extendedDynamicStateFeatures.pNext = null;
            extendedDynamicState3Features.pNext = null;

            for (var i = 0U; i < count; i++)
            {
                var extensionName = new string((sbyte*)&ptr[i].extensionName.element);
                if (Vk.ExtExtendedDynamicStateExtensionName == extensionName)
                {
                    enableDynamicState = true;
                    enabledExtensionCount++;
                    physicalDeviceFeatures2.pNext = &extendedDynamicStateFeatures;
                    ext.DynamicState = extendedDynamicStateFeatures.extendedDynamicState != 0;
                }

                if (!isDebugEnabled && Vk.ExtExtendedDynamicState3ExtensionName == extensionName)
                {
                    enableDynamicState3 = true;
                    enabledExtensionCount++;
                    extendedDynamicStateFeatures.pNext = &extendedDynamicState3Features;
                    ext.ColorBlendEquation = extendedDynamicState3Features.extendedDynamicState3ColorBlendEquation != 0;
                    ext.ColorWriteMask = extendedDynamicState3Features.extendedDynamicState3ColorWriteMask != 0;
                }
            }
        }

        *enabledExtensions++ = (byte*)Marshal.StringToCoTaskMemUTF8(Vk.KhrSwapchainExtensionName);
        if (enableDynamicState)
            *enabledExtensions++ = (byte*)Marshal.StringToCoTaskMemUTF8(Vk.ExtExtendedDynamicStateExtensionName);

        if (enableDynamicState3)
            *enabledExtensions++ = (byte*)Marshal.StringToCoTaskMemUTF8(Vk.ExtExtendedDynamicState3ExtensionName);

        var deviceInfo = new VkDeviceCreateInfo
        {
            sType = VkStructureType.StructureTypeDeviceCreateInfo,
            queueCreateInfoCount = 1,
            pQueueCreateInfos = &queueCreateInfo,
            enabledExtensionCount = (uint)enabledExtensionCount,
            ppEnabledExtensionNames = enabledExtensions,
            pEnabledFeatures = null,
            pNext = &physicalDeviceFeatures2,
        };

        var res = Vk.CreateDevice(physicalDevice, &deviceInfo, null, &device.Device);
        Debug.Assert(res == VkResult.Success);

        for (var i = 0; i < enabledExtensionCount; i++)
            Marshal.FreeCoTaskMem((nint)enabledExtensions[i]);

        /* Create a command pool to allocate our command buffer from */
        var commandPoolCreateInfo = new VkCommandPoolCreateInfo
        {
            sType = VkStructureType.StructureTypeCommandPoolCreateInfo,
            queueFamilyIndex = device.GraphicsQueueFamilyIndex,
            flags = VkCommandPoolCreateFlagBits.CommandPoolCreateResetCommandBufferBit,
        };
        res = Vk.CreateCommandPool(device.Device, &commandPoolCreateInfo, null, &device.CommandPool);
        Debug.Assert(res == VkResult.Success);

        return device;
    }

    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static int DebugCallback(VkDebugUtilsMessageSeverityFlagBitsEXT messageSeverity, VkDebugUtilsMessageTypeFlagBitsEXT messageType, VkDebugUtilsMessengerCallbackDataEXT* data, void* userData)
    {
        Console.WriteLine(new string((sbyte*)data->pMessage));

        if (messageSeverity == VkDebugUtilsMessageSeverityFlagBitsEXT.DebugUtilsMessageSeverityErrorBitExt)
            Debugger.Break();

        return 0;
    }
}