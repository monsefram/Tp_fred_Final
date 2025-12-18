using Autofac;
using System.Windows;
using Tp_Final_Fred.ViewModels;

namespace Tp_Final_Fred.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = FournisseurDI.Container.Resolve<MainViewModel>();
        }

        private async void AddRegion_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainViewModel vm)
                await vm.AddRegion();
        }

        private async void DeleteRegion_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainViewModel vm)
                await vm.DeleteSelectedRegion();
        }

        private void OpenConfig_Click(object sender, RoutedEventArgs e)
        {
            var win = new ConfigWindow();
            win.ShowDialog();
        }
    }
}
