using System;

namespace LocalNet.Models;

public class ItemModel
{
    private int _id;
    private double _x;
    private double _y;
    private int _size;
    private string _url;

    
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

    public int Size
    {
        get => _size;
        set => _size = value;
    }

    public string Url
    {
        get => _url;
        set => _url = value ?? throw new ArgumentNullException(nameof(value));
    }
}