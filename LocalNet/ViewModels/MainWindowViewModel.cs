using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Globalization;
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
        private string mouseX;
        private string mouseY;

        public string MouseX
        {
            get => mouseX;
            set => this.RaiseAndSetIfChanged(ref mouseX, value);
        }

        public string MouseY
        {
            get => mouseY;
            set => this.RaiseAndSetIfChanged(ref mouseY, value);
        }

        public MainWindowViewModel()
        {
            CreateButton = ReactiveCommand.Create(AddButton);
            CreateLoad = ReactiveCommand.Create(Load);
            CreateSave = ReactiveCommand.Create(Save);
            // CreateSave.Execute(Unit.Default).Subscribe().Dispose();
        }

        public ReactiveCommand<Unit, Unit> CreateSave { get; }

        public ReactiveCommand<Unit, Unit> CreateButton { get; }
        
        public ReactiveCommand<Unit, Unit> CreateLoad { get; }
        public void AddButton()
        {
            var itemButt = new Item(0,275, 275, 50, "C:/Users/sasha/RiderProjects/CourseWork2024/LocalNet/Assets/technology-integration.png");
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

