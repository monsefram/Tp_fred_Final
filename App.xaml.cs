using Autofac;
using Autofac.Configuration;
using Microsoft.Extensions.Configuration;
using System.Windows;
using Tp_Final_Fred.Data;
using Microsoft.EntityFrameworkCore;

namespace Tp_Final_Fred
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var config = new ConfigurationBuilder();
            config.AddJsonFile("di.json", optional: false);

            var module = new ConfigurationModule(config.Build());
            var builder = new ContainerBuilder();
            builder.RegisterModule(module);

            FournisseurDI.Container = builder.Build();

            // Migration automatique (comme vu en classe)
            using var scope = FournisseurDI.Container.BeginLifetimeScope();
            var context = scope.Resolve<MeteoDbContext>();
            context.Database.Migrate();
        }
    }
}
