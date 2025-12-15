using Autofac;
using System.Windows;
using Tp_Final_Fred.ViewModels;
using Tp_Final_Fred.Views;

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
        private async void AddRegion_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainViewModel vm)
            {
                await vm.AddRegion();
            }
        }


        private void OpenConfig_Click(object sender, RoutedEventArgs e)
        {
            var win = new ConfigWindow();
            win.ShowDialog();
        }


        private async void DeleteRegion_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainViewModel vm)
                await vm.DeleteSelectedRegion();
        }



    }
}
