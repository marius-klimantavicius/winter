using FontStashSharp;
using Marius.Winter.Forms;
using Marius.Winter.Forms.OpenGL;
using Microsoft.Extensions.FileProviders;
using OpenTK.Mathematics;
using OpenTK.Platform;

namespace Marius.Winter.Playground;

internal class Program
{
    private static void Main(string[] args)
    {
        Toolkit.Init(new ToolkitOptions());

        EventQueue.EventRaised += (handle, type, e) =>
        {
            if (handle is WindowHandle wh && e is CloseEventArgs)
            {
                Toolkit.Window.Destroy(wh);
            }
        };

        var screen = new Screen(new Vector2i(800, 600), new OpenGlBackendFactory());

        var vpanel = new VScrollPanel(screen)
        {
            Position = new Vector2i(100, 100),
            FixedSize = new Vector2i(100, 200),
        };

        var label = new Label(vpanel, "", Theme.Default.FontSansRegular, 14)
        {
            //FixedWidth = 100,
            Caption = """
                      Window *window = new Window(this, "Button demo");
                      window->set_position(Vector2i(15, 15));
                      window->set_layout(new GroupLayout());
                      
                      /* No need to store a pointer, the data structure will be automatically
                         freed when the parent window is deleted */
                      new Label(window, "Push buttons", "sans-bold");
                      
                      Button *b = new Button(window, "Plain button");
                      b->set_callback([] { std::cout << "pushed!" << std::endl; });
                      b->set_tooltip("short tooltip");
                      
                      /* Alternative construction notation using variadic template */
                      b = window->add<Button>("Styled", FA_ROCKET);
                      b->set_background_color(Color(0, 0, 255, 25));
                      b->set_callback([] { std::cout << "pushed!" << std::endl; });
                      b->set_tooltip("This button has a fairly long tooltip. It is so long, in "
                              "fact, that the shown text will span several lines.");
                      
                      new Label(window, "Toggle buttons", "sans-bold");
                      b = new Button(window, "Toggle me");
                      b->set_flags(Button::ToggleButton);
                      b->set_change_callback([](bool state) { std::cout << "Toggle button state: " << state << std::endl; });
                      }
                      """,
        };

        var checkbox = new Checkbox(screen, "CB")
        {
            Position = new Vector2i(300, 200),
            Size = new Vector2i(200, 40),
        };

        var button = new PopupButton(screen, "Ze button")
        {
            Position = new Vector2i(250, 100),
            TooltipText = """
                      void Screen::nvg_flush() {
                          NVGparams *params = nvgInternalParams(m_nvg_context);
                          params->renderFlush(params->userPtr);
                          params->renderViewport(params->userPtr, _size[0], _size[1], m_pixel_ratio);
                      }
                      """,

        };

        var pg = new ProgressBar(screen)
        {
            Position = new Vector2i(250, 200),
        };
        new Slider(screen)
        {
            Position = new Vector2i(250, 250),
            MaxValue = 12,
            HighlightMinValue = 2,
            HighlightMaxValue = 4,
        };
        new NumberBox<float>(screen)
        {
            Position = new Vector2i(300, 30),
            Size = new Vector2i(200, 40),
            IsSpinnable = true,
            FixedWidth = 200,
            IsEditable = true,
            TooltipText = """
                      void /ebScreen/ed::nvg_flush() {
                          /tsNVGparams/td *params = nvgInternalParams(m_nvg_context);
                          /tuparams/td->renderFlush(params->userPtr);
                          params->renderViewport(params->userPtr, _size[0], _size[1], m_pixel_ratio);
                      }
                      """,
        };

        var tabs = new TabWidget(screen)
        {
            TabsDraggable = true,
            TabsCloseable = true,
            Position = new Vector2i(300, 300),
        };
        tabs.AppendTab("ColorWheel", new ColorPicker(tabs, caption: "Selekt ze kolor"));
        tabs.AppendTab("Slide", new Slider(tabs));
        tabs.AppendTab("Number", new NumberBox<float>(tabs)
        {
            IsSpinnable = true,
            //FixedWidth = 200,
            IsEditable = true,
        });

        var gridLayout = new AdvancedGridLayout([50, 100, 30], [30, 50, 50, 50, 50]);
        var window = new Window(screen)
        {
            Position = new Vector2i(350, 100),
            Size = new Vector2i(200, 100),
            //FixedWidth = 200,
            Layout = gridLayout,
        };

        var windowLabels = new List<Widget>
        {
            new Label(window, "AAAA", Theme.Default.FontSansRegular, 14),
            new Label(window, "BBBB", Theme.Default.FontSansRegular, 14),
            new Label(window, "Hello0", Theme.Default.FontMonoRegular, 14),
            new TextBox(window)
            {
                TooltipText = """
                      void Screen::nvg_flush() {
                          NVGparams *params = nvgInternalParams(m_nvg_context);
                          params->renderFlush(params->userPtr);
                          params->renderViewport(params->userPtr, _size[0], _size[1], m_pixel_ratio);
                      }
                      """,
            },
            new ComboBox(window, ["one", "two", "treeeeeee", "one", "two", "treeeeeee", "one", "two", "treeeeeee", "one", "two", "treeeeeee", "one", "two", "treeeeeee", "one", "two", "treeeeeee", "one", "two", "treeeeeee", "one", "two", "treeeeeee"]),
            new Label(window, "Hello3", Theme.Default.FontSansRegular, 14),
            new Label(window, "Hello4", Theme.Default.FontMonoRegular, 14),
            new Label(window, "      __AAAAAAAAAAAAAAAAAAA", Theme.Default.FontSansRegular, 14) { },
        };
        gridLayout.SetColumnStretch(0, 1);
        gridLayout.SetColumnStretch(1, 2);
        gridLayout.SetAnchor(windowLabels[0], 0, 0);
        gridLayout.SetAnchor(windowLabels[1], 1, 0);
        gridLayout.SetAnchor(windowLabels[2], 0, 1);
        gridLayout.SetAnchor(windowLabels[3], 1, 1);
        gridLayout.SetAnchor(windowLabels[4], 1, 2, columnSpan: 2);
        gridLayout.SetAnchor(windowLabels[5], 1, 3, rowSpan: 2, vertical: Alignment.Maximum);
        gridLayout.SetAnchor(windowLabels[6], 0, 3);
        gridLayout.SetAnchor(windowLabels[7], 1, 3, rowSpan: 2, vertical: Alignment.Middle);

        var tb = new ToolButton(window.ButtonPanel, "", new FontIcon(Icons.FA_CLOUD, Theme.Default.FontIcons))
        {
            //Position = new Vector2i(300, 10),
        };

        tb.Toggled += (_, b) =>
        {
            // if (!b)
            //     gridLayout.Orientation = Orientation.Horizontal;
            // else
            //     gridLayout.Orientation = Orientation.Vertical;

            screen.PerformLayout(screen.Context);
            window.Title = $"Width: {window.Size.X}, Height: {window.Size.Y}";
        };

        button.Clicked += s =>
        {
            if (s.Icon == null)
            {
                Span<int> dest = stackalloc int[1];
                Random.Shared.GetItems(Icons.Available, dest);
                s.Icon = new FontIcon(dest[0], Theme.Default.FontIcons);
            }
            else
            {
                s.Icon = null;
            }

            //window.Center();

            if (pg.Value >= 1)
                pg.Value = 0;

            pg.Value += 0.08f;

            new MessageDialog(screen, MessageDialogType.Question);
        };

        screen.IsVisible = true;

        screen.PerformLayout(screen.Context);
        checkbox.Size = checkbox.GetPreferredSize(screen.Context);
        label.Size = label.GetPreferredSize(screen.Context);
        button.Size = button.GetPreferredSize(screen.Context);
        vpanel.PerformLayout(screen.Context);
        tb.PerformLayout(screen.Context);

        while (Toolkit.Window.IsWindowDestroyed(screen.NativeWindow) == false)
        {
            screen.DrawAll(true);

            Toolkit.Window.ProcessEvents(false);
        }
    }

    private static FontSystem LoadFont(IFileProvider fileProvider, string path)
    {
        var result = new FontSystem();
        var fileInfo = fileProvider.GetFileInfo(path);
        if (!fileInfo.Exists)
            throw new FileNotFoundException("Font file not found", path);

        using (var stream = fileInfo.CreateReadStream())
            result.AddFont(stream);

        return result;
    }
}