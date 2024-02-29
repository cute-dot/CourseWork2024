using System;

namespace LocalNet.Models;

public class ItemModel
{
    private int _id;
    private double _x;
    private double _y;
    private int _width;
    private int _height;
    private string _url;

    public int Width
    {
        get => _width;
        set => _width = value;
    }

    public int Height
    {
        get => _height;
        set => _height = value;
    }

    public int Id
    {
        get => _id;
        set => _id = value;
    }

    public double X
    {
        get => _x;
        set => _x = value;
    }

    public double Y
    {
        get => _y;
        set => _y = value;
    }

    public string Url
    {
        get => _url;
        set => _url = value ?? throw new ArgumentNullException(nameof(value));
    }
}