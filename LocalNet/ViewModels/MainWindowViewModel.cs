using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using Avalonia.Controls;
using LocalNet.Models;
using LocalNet.Views;
using ReactiveUI;
#nullable disable
namespace LocalNet.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private  ObservableCollection<Item> _items = new ObservableCollection<Item>();
        
        public ObservableCollection<Item> Items
        {
            get => _items;
            set => this.RaiseAndSetIfChanged(ref _items, value);
        }

        private string _mouseX;
        private string _mouseY;
        
        private double _canvasW = 600;
        private double _canvasH = 600;
        public string MouseX
        {
            get => _mouseX;
            set => this.RaiseAndSetIfChanged(ref _mouseX, value);
        }
        public string MouseY
        {
            get => _mouseY;
            set => this.RaiseAndSetIfChanged(ref _mouseY, value);
        }
        public double CanvasW
        {
            get => _canvasW;
            set => this.RaiseAndSetIfChanged(ref _canvasW, value);
        }
        public double CanvasH
        {
            get => _canvasH;
            set => this.RaiseAndSetIfChanged(ref _canvasH, value);
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
            ChangeCanvasSizePlus = ReactiveCommand.Create(CanvasIncrease);
            ChangeCanvasSizeMinus = ReactiveCommand.Create(CanvasDecrease);
            ClearMap = ReactiveCommand.Create(Clear);
            CreateArrowWr = ReactiveCommand.Create(AddArrowWireless);
            CreateArrow = ReactiveCommand.Create(AddArrow);
        }
        public ReactiveCommand<Unit,Unit> CreateArrow { get; }
        public ReactiveCommand<Unit, Unit> CreateArrowWr { get; }
        public ReactiveCommand<Unit, Unit> ClearMap { get; }
        public ReactiveCommand<Unit, Unit> ChangeCanvasSizePlus { get; }
        public ReactiveCommand<Unit, Unit> ChangeCanvasSizeMinus { get; }
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

        public void CanvasIncrease()
        {
            
            CanvasW += 100;
            CanvasH += 100;
            foreach (var item in Items)
            {
                item.X += 100;
                item.Y += 100;
            }
        }
        public void CanvasDecrease()
        {
            if (CanvasW > 100 && CanvasH > 100)
            {
                CanvasW -= 100;
                CanvasH -= 100;
                foreach (var item in Items)
                {
                    item.X -= 100;
                    item.Y -= 100;
                }
            }
        }
        
        public void Clear()
        {
            Items.Clear();
        }

        public void AddArrow()
        {
            var itemButt = new Item(11,CanvasW/2, CanvasH/2, 50, 50,"C:/Users/sasha/RiderProjects/CourseWork2024/LocalNet/Assets/Arrows/arrDown.png");
            Items.Add(itemButt);
        }
        public void AddArrowWireless()
        {
            var itemButt = new Item(10,CanvasW/2, CanvasH/2, 50, 50,"C:/Users/sasha/RiderProjects/CourseWork2024/LocalNet/Assets/Arrows/arrow-right.png");
            Items.Add(itemButt);
        }
        
        public void AddButton()
        {
            var count = (from item in Items where item.Id == 0 select item).Count();
            if (count == 0)
            {
                var itemButt = new Item(0,CanvasW/2, CanvasH/2, 50,50, "C:/Users/sasha/RiderProjects/CourseWork2024/LocalNet/Assets/technology-integration.png");
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
            var itemButt = new Item(4,CanvasW/2, CanvasH/2, 50, 50,"C:/Users/sasha/RiderProjects/CourseWork2024/LocalNet/Assets/laptop.png");
            Items.Add(itemButt);
        }
        public void AddPhone()
        {
            var itemButt = new Item(4,CanvasW/2, CanvasH/2, 50, 50,"C:/Users/sasha/RiderProjects/CourseWork2024/LocalNet/Assets/iphone.png");
            Items.Add(itemButt);
        }
        public void AddWrRouter()
        {
            var itemButt = new Item(3,CanvasW/2, CanvasH/2, 50, 50,"C:/Users/sasha/RiderProjects/CourseWork2024/LocalNet/Assets/wireless-router.png");
            Items.Add(itemButt);
        }
        public void AddPrinter()
        {
            var itemButt = new Item(2,CanvasW/2, CanvasH/2, 50, 50,"C:/Users/sasha/RiderProjects/CourseWork2024/LocalNet/Assets/printer.png");
            Items.Add(itemButt);
        }
        public void AddWrPrinter()
        {
            var itemButt = new Item(4,CanvasW/2, CanvasH/2, 50,50, "C:/Users/sasha/RiderProjects/CourseWork2024/LocalNet/Assets/WirelessPrinter.png");
            Items.Add(itemButt);
        }
        public void AddServer()
        {
            var itemButt = new Item(5,CanvasW/2, CanvasH/2, 50, 50,"C:/Users/sasha/RiderProjects/CourseWork2024/LocalNet/Assets/server.png");
            Items.Add(itemButt);
        }
        public void AddPC()
        {
            var itemButt = new Item(2,CanvasW/2, CanvasH/2, 50, 50, "C:/Users/sasha/RiderProjects/CourseWork2024/LocalNet/Assets/PC.png");
            Items.Add(itemButt);
        }
        public void AddCommutator()
        {
            var itemButt = new Item(1,CanvasW/2, CanvasH/2, 50, 50, "C:/Users/sasha/RiderProjects/CourseWork2024/LocalNet/Assets/Commutator.png");
            Items.Add(itemButt);
        }
        public void Save()
        {
            
            List<Item> list = new List<Item>();
            foreach (var item in Items)
            {
                // item.SuppressChangeNotifications();
                list.Add(item);
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
        private int _id;
        private double _x;
        private double _y;
        private int _width;
        private int _height;
        private string _url; 
        
        public Item(int id, double x, double y, int width,int height, string url)
        {
            _id = id;
            _x = x;
            _y = y;
            _width = width;
            _height = height;
            _url = url;
        }
        public int Id
        {
            get => _id;
            set => this.RaiseAndSetIfChanged(ref _id, value);
        }

        public double X
        {
            get => _x;
            set => this.RaiseAndSetIfChanged(ref _x, value);
        }
        public double Y
        {
            get =>_y;
            set => this.RaiseAndSetIfChanged(ref _y, value);
        }
        public int Width
        {
            get => _width;
            set => this.RaiseAndSetIfChanged(ref _width, value);
        }
        public int Height
        {
            get => _height;
            set => this.RaiseAndSetIfChanged(ref _height, value);
        }
        public string Url
        {
            get => _url;
            set => this.RaiseAndSetIfChanged(ref _url, value);
        }
    }
    
}

