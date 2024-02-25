using System;
using System.Globalization;
using System.Runtime.Versioning;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.PanAndZoom;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Primitives;
using Avalonia.Data.Converters;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.ReactiveUI;
using DynamicData;
using LocalNet.ViewModels;
using ReactiveUI;
using Splat;
using MouseButton = Avalonia.Remote.Protocol.Input.MouseButton;

namespace LocalNet.Views;

public partial class MainWindow :  Window
{
    private readonly ZoomBorder? _zoomBorder;
    public double relativeMouseX;
    public double relativeMouseY;
    public bool isdrugging = false;
    public int itemID;
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