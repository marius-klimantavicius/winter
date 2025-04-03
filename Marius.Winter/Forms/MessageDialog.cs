using System;

namespace Marius.Winter.Forms;

public class MessageDialog : Window
{
    protected Label _messageLabel;

    public Label MessageLabel
    {
        get => _messageLabel;
        set => _messageLabel = value;
    }

    public event Action<MessageDialog, int>? Closed;
    
    public MessageDialog(Widget? parent, MessageDialogType type, string title = "Untitled", string message = "Message", string buttonText = "OK", string altButtonText = "Cancel", bool altButton = false)
        : base(parent, title)
    {
        Layout = new BoxLayout(Orientation.Vertical, margin: 10, spacing: 10);
        IsModal = true;

        var panel1 = new Widget(this)
        {
            Layout = new BoxLayout(Orientation.Horizontal, margin: 10, spacing: 15),
        };

        var icon = default(FontIcon);
        switch (type)
        {
            case MessageDialogType.Information: icon = _theme.MessageInformationIcon; break;
            case MessageDialogType.Question: icon = _theme.MessageQuestionIcon; break;
            case MessageDialogType.Warning: icon = _theme.MessageWarningIcon; break;
        }
        
        var iconLabel = new Label(this, icon?.IconText ?? "", icon?.IconFont ?? _theme.FontIcons, 50);
        _messageLabel = new Label(panel1, message, _theme.FontSansRegular)
        {
            FixedWidth = 200,
        };

        var panel2 = new Widget(this)
        {
            Layout = new BoxLayout(Orientation.Horizontal, margin: 0, spacing: 15),
        };

        if (altButton)
        {
            var altButtonWidget = new Button(panel2, altButtonText, _theme.MessageAltButtonIcon);
            altButtonWidget.Clicked += _ =>
            {
                Closed?.Invoke(this, 1);
                Dispose();
            };
        }

        var button = new Button(panel2, buttonText, _theme.MessagePrimaryButtonIcon);
        button.Clicked += _ =>
        {
            Closed?.Invoke(this, 0);
            Dispose();
        };

        Center();
        RequestFocus();
    }
}