using System;
using System.Globalization;
using System.Runtime.Versioning;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.PanAndZoom;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Shapes;
using Avalonia.Data.Converters;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.ReactiveUI;
using Avalonia.Skia;
using DynamicData;
using LocalNet.ViewModels;
using ReactiveUI;
using SkiaSharp;
using Splat;
using MouseButton = Avalonia.Remote.Protocol.Input.MouseButton;

namespace LocalNet.Views;

public partial class MainWindow :  Window
{
    
    private readonly ZoomBorder? _zoomBorder;
    public double startPosX;
    public double startPosY;
    public Point startPos;
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
        
    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        isdrugging = true; 
        
        Console.WriteLine(isdrugging);
    }

    private void MCanvas_OnPointerMoved(object? sender, PointerEventArgs e)
    {
        if (isdrugging)
        {
            
        }

    }

    private void InputElement_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        startPos = e.GetPosition(this);
        Console.WriteLine(startPos.X);
        Console.WriteLine(startPos.Y);
    }
}