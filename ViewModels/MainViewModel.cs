using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Tp_Final_Fred.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _regionName;
        public string RegionName
        {
            get => _regionName;
            set { _regionName = value; OnPropertyChanged(); }
        }

        private double _latitude;
        public double Latitude
        {
            get => _latitude;
            set { _latitude = value; OnPropertyChanged(); }
        }

        private double _longitude;
        public double Longitude
        {
            get => _longitude;
            set { _longitude = value; OnPropertyChanged(); }
        }

        public ObservableCollection<string> Regions { get; set; } =
            new ObservableCollection<string>();

        private string _selectedRegion;
        public string SelectedRegion
        {
            get => _selectedRegion;
            set { _selectedRegion = value; OnPropertyChanged(); }
        }

        public MainViewModel()
        {
            // Région par défaut comme dans le projet
            Regions.Add("Shawinigan\nLat: 46.5698\nLon: -72.7381");
            SelectedRegion = Regions[0];
        }

        public void AddRegion()
        {
            Regions.Add($"{RegionName}\nLat: {Latitude}\nLon: {Longitude}");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string p = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
    }
}
