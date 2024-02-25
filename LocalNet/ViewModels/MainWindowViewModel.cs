using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data.Converters;
using Avalonia.Input;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using DynamicData.Binding;
using LocalNet.Models;
using LocalNet.Views;
using ReactiveUI;
using Bitmap = Avalonia.Media.Imaging.Bitmap;

#nullable disable
namespace LocalNet.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public  ObservableCollection<Item> _items = new ObservableCollection<Item>();
        
        public ObservableCollection<Item> Items
        {
            get => _items;
            // set => this.RaiseAndSetIfChanged(ref _items, value);
        }
        public MainWindowViewModel()
        {
            CreateButton = ReactiveCommand.Create(AddButton);
            CreateLoad = ReactiveCommand.Create(Load);
            CreateSave = ReactiveCommand.Create(Save);
            CreateCommutator = ReactiveCommand.Create(AddCommutator);
            CreatePC = ReactiveCommand.Create(AddPC);
            CreateLaptop = ReactiveCommand.Create(AddLaptop);
            CreateWrRouter = ReactiveCommand.Create(AddWrRouter);
            CreatePhone = ReactiveCommand.Create(AddPhone);
            CreatePrinter = ReactiveCommand.Create(AddPrinter);
            CreateWrPrinter = ReactiveCommand.Create(AddWrPrinter);
            CreateServer = ReactiveCommand.Create(AddServer);
        }

        public ReactiveCommand<Unit, Unit> CreateSave { get; }
        public ReactiveCommand<Unit, Unit> CreateButton { get; }
        public ReactiveCommand<Unit, Unit> CreateCommutator { get; }
        public ReactiveCommand<Unit,Unit> CreatePC { get; }
        public ReactiveCommand<Unit, Unit> CreateLoad { get; }
        public ReactiveCommand<Unit, Unit> CreatePhone { get; }
        public ReactiveCommand<Unit, Unit> CreateWrRouter { get; }
        public ReactiveCommand<Unit, Unit> CreateLaptop { get; }
        public ReactiveCommand<Unit, Unit> CreatePrinter { get; }
        public ReactiveCommand<Unit, Unit> CreateWrPrinter { get; }
        public ReactiveCommand<Unit, Unit> CreateServer { get; }
        public void AddButton()
        {
            var count = (from item in Items where item.Id == 0 select item).Count();
            if (count == 0)
            {
                var itemButt = new Item(0,275, 275, 50, "C:/Users/sasha/RiderProjects/CourseWork2024/LocalNet/Assets/technology-integration.png");
                Items.Add(itemButt);
            }
            else
            {
                var window = new ErrorWindow();
                window.Show();
            }
        }
        public void AddLaptop()
        {
            var itemButt = new Item(4,275, 275, 50, "C:/Users/sasha/RiderProjects/CourseWork2024/LocalNet/Assets/laptop.png");
            Items.Add(itemButt);
        }
        public void AddPhone()
        {
            var itemButt = new Item(4,275, 275, 50, "C:/Users/sasha/RiderProjects/CourseWork2024/LocalNet/Assets/iphone.png");
            Items.Add(itemButt);
        }
        public void AddWrRouter()
        {
            var itemButt = new Item(3,275, 275, 50, "C:/Users/sasha/RiderProjects/CourseWork2024/LocalNet/Assets/wireless-router.png");
            Items.Add(itemButt);
        }
        public void AddPrinter()
        {
            var itemButt = new Item(2,275, 275, 50, "C:/Users/sasha/RiderProjects/CourseWork2024/LocalNet/Assets/printer.png");
            Items.Add(itemButt);
        }
        public void AddWrPrinter()
        {
            var itemButt = new Item(4,275, 275, 50, "C:/Users/sasha/RiderProjects/CourseWork2024/LocalNet/Assets/WirelessPrinter.png");
            Items.Add(itemButt);
        }
        public void AddServer()
        {
            var itemButt = new Item(5,275, 275, 50, "C:/Users/sasha/RiderProjects/CourseWork2024/LocalNet/Assets/server.png");
            Items.Add(itemButt);
        }
        public void AddPC()
        {
            var itemButt = new Item(2,275, 275, 50, "C:/Users/sasha/RiderProjects/CourseWork2024/LocalNet/Assets/PC.png");
            Items.Add(itemButt);
        }
        public void AddCommutator()
        {
            var itemButt = new Item(1,275, 275, 50, "C:/Users/sasha/RiderProjects/CourseWork2024/LocalNet/Assets/Commutator.png");
            Items.Add(itemButt);
        }

        public void Save()
        {
            
            List<Item> list = new List<Item>();
            foreach (var item in Items)
            {
                // item.SuppressChangeNotifications();
                list.Add(item);
                Console.WriteLine("1");
                Console.WriteLine(list[0].X);
            }
            
            ItemsRepository.Save(list);
        }

        public void Load()
        {
            ItemsRepository.Load(Items);
        }
        
    }

    public class Item : ViewModelBase
    {
        private int id;
        private double x;
        private double y;
        private int size;
        private string url; 
        
        public Item(int id, double x, double y, int size, string url)
        {
            this.id = id;
            this.x = x;
            this.y = y;
            this.size = size;
            this.url = url;
        }
        public int Id
        {
            get => id;
            set => this.RaiseAndSetIfChanged(ref id, value);
        }

        public double X
        {
            get => x;
            set => this.RaiseAndSetIfChanged(ref x, value);
        }
        public double Y
        {
            get => y;
            set => this.RaiseAndSetIfChanged(ref y, value);
        }
        public int Size
        {
            get => size;
            set => this.RaiseAndSetIfChanged(ref size, value);
        }
        public string Url
        {
            get => url;
            set => this.RaiseAndSetIfChanged(ref url, value);
        }
        
    }
    
}

