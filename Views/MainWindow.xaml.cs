using System.Windows;
using Tp_Final_Fred.ViewModels;
using Tp_Final_Fred.Views;

namespace Tp_Final_Fred

{
    public partial class MainWindow : Window
    {
        public MainViewModel VM => DataContext as MainViewModel;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddRegion_Click(object sender, RoutedEventArgs e)
        {
            VM.AddRegion();
        }

        private void OpenConfig_Click(object sender, RoutedEventArgs e)
        {
            new ConfigWindow().ShowDialog();
        }

    }
}
