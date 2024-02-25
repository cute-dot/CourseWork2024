using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace LocalNet.Views;

public partial class ErrorWindow : Window
{
    public ErrorWindow()
    {
        InitializeComponent();
        // this.SystemDecorations = SystemDecorations.None; // Отключение системных декораций
        // this.ExtendClientAreaToDecorationsHint = true; // расширение клиентской области
        // this.ExtendClientAreaTitleBarHeightHint = 30;  //
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        this.Close();
    }
}