using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using Tp_Final_Fred.Data.Repositories.Interfaces;
using Tp_Final_Fred.Models;
using Tp_Final_Fred.Services;

namespace Tp_Final_Fred.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IRegionRepository _regionRepo;

        private Region? _selectedRegion;
        private string _regionName = "";
        private double _latitude;
        private double _longitude;

        public ObservableCollection<Region> Regions { get; set; }
            = new ObservableCollection<Region>();

        public ObservableCollection<WeatherDay> Forecast { get; set; }
            = new ObservableCollection<WeatherDay>();

        public Region? SelectedRegion
        {
            get => _selectedRegion;
            set
            {
                _selectedRegion = value;
                OnPropertyChanged();

                if (value != null)
                    _ = LoadWeather(value.Latitude, value.Longitude);
            }
        }

        public string RegionName
        {
            get => _regionName;
            set { _regionName = value; OnPropertyChanged(); }
        }

        public double Latitude
        {
            get => _latitude;
            set { _latitude = value; OnPropertyChanged(); }
        }

        public double Longitude
        {
            get => _longitude;
            set { _longitude = value; OnPropertyChanged(); }
        }

        // 🔹 INJECTION VIA AUTOFAC
        public MainViewModel(IRegionRepository regionRepo)
        {
            _regionRepo = regionRepo;

            Regions = new ObservableCollection<Region>(_regionRepo.GetAll());

            // Seeding obligatoire
            if (!Regions.Any())
            {
                var shawi = new Region
                {
                    Name = "Shawinigan",
                    Latitude = 46.5698,
                    Longitude = -72.7381
                };

                _regionRepo.AddAsync(shawi).Wait();
                Regions.Add(shawi);
            }

            SelectedRegion = Regions.First();
        }

        public async Task AddRegion()
        {
            if (string.IsNullOrWhiteSpace(RegionName))
                return;

            var region = new Region
            {
                Name = RegionName,
                Latitude = Latitude,
                Longitude = Longitude
            };

            await _regionRepo.AddAsync(region);

            Regions.Add(region);
            SelectedRegion = region;

            RegionName = "";
            Latitude = 0;
            Longitude = 0;
        }


        public async Task LoadWeather(double lat, double lon)
        {
            var apiKey = Properties.Settings.Default.apiKey;
            var api = new WeatherService(apiKey);


            Forecast.Clear();

            var result = await api.Get7DayForecast(lat, lon);

            foreach (var d in result)
                Forecast.Add(d);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? p = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));


        public async Task DeleteSelectedRegion()
        {
            if (SelectedRegion == null)
                return;

            var result = MessageBox.Show(
                $"Supprimer la région '{SelectedRegion.Name}' ?",
                "Confirmation",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning
            );

            if (result != MessageBoxResult.Yes)
                return;

            await _regionRepo.DeleteAsync(SelectedRegion);

            Regions.Remove(SelectedRegion);
            SelectedRegion = null;
        }

    }


}
