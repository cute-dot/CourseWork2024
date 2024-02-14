using System.Collections.ObjectModel;
using System.Drawing;
using System.Reactive;
using Avalonia;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using ReactiveUI;
#nullable disable
namespace LocalNet.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<Item> items;
        public ObservableCollection<Item> Items{ get; }
        public MainWindowViewModel()
        {
            CreateButton = ReactiveCommand.Create(AddButton);
            Items = new ObservableCollection<Item>();
        }
        

        public ReactiveCommand<Unit, Unit> CreateButton
        {
            get;
        }

        public void AddButton()
        {
            
            Items.Add(new Item(){X = 275, Y = 275, Size = 50, Url = "/Assets/technology-integration.png"});
            Items[0].X += 50;
        }
        
    }

    public class Item : ViewModelBase
    {
        private int x;
        private int y;
        private int size;
        private string url;

        public int X
        {
            get => x;
            set => this.RaiseAndSetIfChanged(ref x, value);
        }
        public int Y
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

