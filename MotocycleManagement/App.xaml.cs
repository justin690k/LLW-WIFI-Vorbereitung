using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MotocycleManagement.WPF.Controller;
using MotocycleManagement.WPF.Model;
using System.Configuration;
using System.Data;
using System.Windows;

namespace MotocycleManagement
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost? _host;
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var builder = Host.CreateApplicationBuilder();

            builder.Services.AddTransient<IMotocycleController, MotocycleController>();

            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient(sp =>
            {
                return new MainWindow
                {
                    DataContext = sp.GetRequiredService<MainViewModel>()
                };
            });

            _host = builder.Build();
            _host.Start();

            var window = _host.Services.GetRequiredService<MainWindow>();  
            window.Show();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            _host?.Dispose();
        }
    }

}
