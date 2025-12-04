using System.Windows;
using Tp_Final_Fred.ViewModels;

namespace Tp_Final_Fred.Views
{
    public partial class ConfigWindow : Window
    {
        public ConfigViewModel VM => DataContext as ConfigViewModel;

        public ConfigWindow()
        {
            InitializeComponent();
            DataContext = new ConfigViewModel();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            VM.Save();
            Close();
        }
    }
}
