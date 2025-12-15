using Autofac;
using System.Windows;
using Tp_Final_Fred.ViewModels;

namespace Tp_Final_Fred
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = FournisseurDI.Container.Resolve<MainViewModel>();
        }

        // Bouton +
        private void AddRegion_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainViewModel vm)
            {
                vm.AddRegion();
            }
        }

        // Menu Configuration (on fera la fenêtre plus tard)
        private void OpenConfig_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Fenêtre de configuration à venir",
                "Configuration",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
    }
}
