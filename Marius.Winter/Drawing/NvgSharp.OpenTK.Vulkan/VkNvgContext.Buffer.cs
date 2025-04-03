using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using OpenTK.Graphics.Vulkan;

namespace NvgSharp.OpenTK.Vulkan;

internal unsafe partial class VkNvgContext
{
    private static VkNvgBuffer CreateBuffer<T>(VkDevice device, VkPhysicalDeviceMemoryProperties memoryProperties, VkAllocationCallbacks* allocator, VkBufferUsageFlagBits usage, VkMemoryPropertyFlagBits memory_type, ReadOnlySpan<T> data)
        where T : unmanaged
    {
        var bufferCreateInfo = new VkBufferCreateInfo
        {
            sType = VkStructureType.StructureTypeBufferCreateInfo,
            size = (ulong)data.Length * (ulong)sizeof(T),
            usage = usage,
        };

        var buffer = new VkBuffer();
        CheckResult(Vk.CreateBuffer(device, &bufferCreateInfo, allocator, &buffer));

        var memoryRequirements = new VkMemoryRequirements();
        Vk.GetBufferMemoryRequirements(device, buffer, &memoryRequirements);

        var res = GetMemoryTypeFromProperties(memoryProperties, memoryRequirements.memoryTypeBits, memory_type, out var memoryTypeIndex);
        Debug.Assert(res == VkResult.Success);
        
        var memoryAllocateInfo = new VkMemoryAllocateInfo
        {
            sType = VkStructureType.StructureTypeMemoryAllocateInfo,
            allocationSize = memoryRequirements.size,
            memoryTypeIndex = memoryTypeIndex,
        };

        VkDeviceMemory mem;
        CheckResult(Vk.AllocateMemory(device, &memoryAllocateInfo, null, &mem));

        void* mapped;
        CheckResult(Vk.MapMemory(device, mem, 0, memoryAllocateInfo.allocationSize, 0, &mapped));
        
        var mappedSpan = new Span<T>(mapped, data.Length);
        data.CopyTo(mappedSpan);

        CheckResult(Vk.BindBufferMemory(device, buffer, mem, 0));
        var buf = new VkNvgBuffer
        {
            Buffer = buffer,
            DeviceMemory = mem,
            DeviceSize = memoryAllocateInfo.allocationSize,
            Mapped = mapped,
            IsInitialized = true,
        };
        return buf;
    }

    public static void DestroyBuffer(VkDevice device, VkAllocationCallbacks* allocator, ref VkNvgBuffer buffer)
    {
        if (buffer.IsInitialized)
        {
            Vk.UnmapMemory(device, buffer.DeviceMemory);
        }

        Vk.DestroyBuffer(device, buffer.Buffer, allocator);
        Vk.FreeMemory(device, buffer.DeviceMemory, allocator);

        buffer = default;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void UpdateBuffer<T>(VkDevice device, VkAllocationCallbacks* allocator, ref VkNvgBuffer buffer, VkPhysicalDeviceMemoryProperties memoryProperties, VkBufferUsageFlagBits usage, VkMemoryPropertyFlagBits memory_type, List<T> data)
        where T : unmanaged
    {
        var span = CollectionsMarshal.AsSpan(data);
        UpdateBuffer(device, allocator, ref buffer, memoryProperties, usage, memory_type, (ReadOnlySpan<T>)span);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void UpdateBuffer<T>(VkDevice device, VkAllocationCallbacks* allocator, ref VkNvgBuffer buffer, VkPhysicalDeviceMemoryProperties memoryProperties, VkBufferUsageFlagBits usage, VkMemoryPropertyFlagBits memory_type, Span<T> data)
        where T : unmanaged
    {
        UpdateBuffer(device, allocator, ref buffer, memoryProperties, usage, memory_type, (ReadOnlySpan<T>)data);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void UpdateBuffer<T>(VkDevice device, VkAllocationCallbacks* allocator, ref VkNvgBuffer buffer, VkPhysicalDeviceMemoryProperties memoryProperties, VkBufferUsageFlagBits usage, VkMemoryPropertyFlagBits memory_type, ReadOnlySpan<T> data)
        where T : unmanaged
    {
        var size = (uint)(data.Length * sizeof(T));
        var span = data;
        if (buffer.DeviceSize < size)
        {
            DestroyBuffer(device, allocator, ref buffer);
            buffer = CreateBuffer(device, memoryProperties, allocator, usage, memory_type, span);
        }
        else
        {
            var dest = new Span<T>(buffer.Mapped, data.Length);
            span.CopyTo(dest);
        }
    }}