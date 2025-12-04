using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Tp_Final_Fred.Services;

namespace Tp_Final_Fred.ViewModels
{
    public class ConfigViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> Languages { get; } =
            new ObservableCollection<string> { "fr", "en" };

        private string _language;
        public string Language
        {
            get => _language;
            set { _language = value; OnPropertyChanged(); }
        }

        private string _apiKey;
        public string ApiKey
        {
            get => _apiKey;
            set { _apiKey = value; OnPropertyChanged(); }
        }

        private AppConfig _config;

        public ConfigViewModel()
        {
            _config = ConfigService.Load();
            Language = _config.Language;
            ApiKey = _config.ApiKey;
        }

        public void Save()
        {
            _config.Language = Language;
            _config.ApiKey = ApiKey;
            ConfigService.Save(_config);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string p = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
    }
}
