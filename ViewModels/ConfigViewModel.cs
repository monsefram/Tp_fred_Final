using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Tp_Final_Fred.Services;
using System.Collections.ObjectModel;


namespace Tp_Final_Fred.ViewModels
{
    public class ConfigViewModel : INotifyPropertyChanged
    {
        private string _language;
        private string _apiKey;

        public event Action? CloseRequested;


        public string Language
        {
            get => _language;
            set { _language = value; OnPropertyChanged(); }
        }

        public string ApiKey
        {
            get => _apiKey;
            set { _apiKey = value; OnPropertyChanged(); }
        }

        public ICommand SaveCommand { get; }

        public ConfigViewModel()
        {
            var config = ConfigService.Load();

            Language = config.Language;
            ApiKey = config.ApiKey;

            SaveCommand = new RelayCommand(Save);
        }

        private void Save()
        {
            ConfigService.Save(new AppConfig
            {
                Language = Language,
                ApiKey = ApiKey
            });

            CloseRequested?.Invoke();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? p = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));

        public ObservableCollection<string> Languages { get; }
            = new ObservableCollection<string> { "fr", "en" };

    }
}
