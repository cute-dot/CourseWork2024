using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.PanAndZoom;
using Avalonia.Input;
using Avalonia.Interactivity;
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
   
    private void MCanvas_OnPointerMoved(object? sender, PointerEventArgs e)
    {
        if (sender is Canvas)
        {
            var data = (MainWindowViewModel)DataContext;
            Point point = e.GetPosition(MCanvas);
            var pointX = Math.Round(((point.X - data.CanvasH)/ data.CanvasH), 1).ToString();
            var pointY = Math.Round(-((point.Y - data.CanvasH))/ data.CanvasH, 1).ToString();
            data.MouseX = pointX;
            data.MouseY = pointY;
        }
    }

    private void Button_OnClickTop(object? sender, RoutedEventArgs e)
    {
        var button = e.Source as Control;
        var data = (Item)button.DataContext;
        data.Height += 20;
        data.Width += 20;
    }

    private void Button_OnClickRight(object? sender, RoutedEventArgs e)
    {
        var button = e.Source as Control;
        var data = (Item)button.DataContext;
        data.Height -= 20;
        data.Width -= 20;
    }

    private void Button1_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        var arrowButt = e.Source as Control;
        var data = (Item)arrowButt.DataContext;
        if (e.GetCurrentPoint(arrowButt).Properties.IsRightButtonPressed)
        {
            if (data.Id == 10)
            {
                string getUrl = data.Url;
                getUrl = getUrl.Substring(73, getUrl.Length-77);
                Console.WriteLine(data.Url);
                Console.WriteLine(getUrl);
                switch (getUrl)
                {
                    case "right":
                    {
                        data.Url = "C:/Users/sasha/RiderProjects/CourseWork2024/LocalNet/Assets/Arrows/arrow-left.png";
                        return;
                    }
                    case "left":
                    {
                        data.Url = "C:/Users/sasha/RiderProjects/CourseWork2024/LocalNet/Assets/Arrows/arrow-up-left.png";
                        return;
                    }
                    case "up-left":
                    {
                        data.Url = "C:/Users/sasha/RiderProjects/CourseWork2024/LocalNet/Assets/Arrows/arrow-up-right.png";
                        return;
                    }
                    case "up-right":
                    {
                        data.Url = "C:/Users/sasha/RiderProjects/CourseWork2024/LocalNet/Assets/Arrows/arrow-right.png";
                        return;
                    }
                }
            
            }
        }
    }
}