using System.Windows;
using Tp_Final_Fred.ViewModels;

namespace Tp_Final_Fred.Views
{
    public partial class ConfigWindow : Window
    {
        public ConfigWindow()
        {
            InitializeComponent();

            var vm = new ConfigViewModel();
            vm.CloseRequested += () => this.Close();

            DataContext = vm;
        }
    }
}
