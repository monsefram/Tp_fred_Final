using Autofac;
using Autofac.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Globalization;
using System.Threading;
using System.Windows;
using Tp_Final_Fred.Data;
using Tp_Final_Fred.Properties;
using Tp_Final_Fred.Views;

namespace Tp_Final_Fred
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            string langue = Settings.Default.langue;

            if (string.IsNullOrWhiteSpace(langue))
                langue = "fr-CA";



            Thread.CurrentThread.CurrentCulture =
                new CultureInfo(langue);

            Thread.CurrentThread.CurrentUICulture =
                new CultureInfo(langue);
            var config = new ConfigurationBuilder()
                .AddJsonFile("di.json", optional: false)
                .Build();

            var builder = new ContainerBuilder();
            builder.RegisterModule(new ConfigurationModule(config));

            FournisseurDI.Container = builder.Build();

            using (var scope = FournisseurDI.Container.BeginLifetimeScope())
            {
                var context = scope.Resolve<MeteoDbContext>();
                context.Database.Migrate();
            }

            var mainWindow = new Views.MainWindow
            {
                DataContext = FournisseurDI.Container.Resolve<ViewModels.MainViewModel>()
            };

            mainWindow.Show();
        }
    }
}
