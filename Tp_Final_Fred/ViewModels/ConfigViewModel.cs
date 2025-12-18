using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Tp_Final_Fred.ViewModels
{
    public class ConfigViewModel : INotifyPropertyChanged
    {
        private string _language = "fr-CA";
        private string _apiKey;

        public event Action? CloseRequested;

        public ObservableCollection<string> Languages { get; }
            = new() { "fr-CA", "en-US" };

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
            Language = Properties.Settings.Default.langue;
            ApiKey = Properties.Settings.Default.apiKey;

            SaveCommand = new RelayCommand(Save);
        }

        private void Save()
        {
            Properties.Settings.Default.langue = Language;
            Properties.Settings.Default.apiKey = ApiKey;
            Properties.Settings.Default.Save();

            CloseRequested?.Invoke();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? p = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
    }
}
