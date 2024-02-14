using Avalonia.Controls;
using Avalonia.Controls.PanAndZoom;
using Avalonia.Input;
using Avalonia.ReactiveUI;
using LocalNet.ViewModels;

namespace LocalNet.Views;

public partial class MainWindow :  Window
{
    private readonly ZoomBorder? _zoomBorder;
    public MainWindow()
    {
        InitializeComponent();
        _zoomBorder = this.Find<ZoomBorder>("ZoomBorder");
        if (_zoomBorder != null)
        {
            _zoomBorder.KeyDown += ZoomBorder_key;
        }
    }
    
    private void ZoomBorder_key(object? sender, KeyEventArgs e)
    {
        if (e.Key == Key.R)
        {
            _zoomBorder?.ResetMatrix();
        }
        
    }
}