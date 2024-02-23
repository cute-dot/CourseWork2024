using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using DynamicData;
using LocalNet.ViewModels;
using Newtonsoft.Json;

namespace LocalNet.Models;

public static class ItemsRepository
{
    
    public static void Save(List<Item> list)
    {
        string path = @"C:\Users\sasha\RiderProjects\CourseWork2024\LocalNet\ItemsRep.json";
        var json = File.ReadAllText(path);
        var itemsRep = JsonConvert.DeserializeObject<List<ItemModel>>(json);
        itemsRep.Clear();
        if (itemsRep == null)
        {
            itemsRep = new List<ItemModel>();
        }

        foreach (var item in list)
        {
            var model = new ItemModel();
            model.X = item.X;
            model.Y = item.Y;
            model.Size = item.Size;
            model.Url = item.Url;
            model.Id = item.Id;
            itemsRep.Add(model);
        }
        var newjson = JsonConvert.SerializeObject(itemsRep, Formatting.Indented);
        File.WriteAllText(path, newjson);

    }

    public static void Load(ObservableCollection<Item> list)
    {
        string path = @"C:\Users\sasha\RiderProjects\CourseWork2024\LocalNet\ItemsRep.json";
        var json = File.ReadAllText(path);
        var itemsRep = JsonConvert.DeserializeObject<List<ItemModel>>(json);
        if (list.Count == 0)
        {
            foreach (var item in itemsRep)
            {
                var butt = new Item(item.Id,item.X,item.Y,item.Size,item.Url);
                list.Add(butt);
            }
        }
        else
        {
            list.Clear();
            foreach (var item in itemsRep)
            {
                var butt = new Item(item.Id,item.X,item.Y,item.Size,item.Url);
                list.Add(butt);
            }
        }
    }
}