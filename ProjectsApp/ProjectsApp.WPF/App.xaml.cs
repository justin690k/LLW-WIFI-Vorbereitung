using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjectsApp.WPF.Services;
using ProjectsApp.WPF.ViewModel;
using System.Configuration;
using System.Data;
using System.Windows;

namespace ProjectsApp.WPF;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private IHost _host;
    private void Application_Startup(object sender, StartupEventArgs e)
    {
        var builder = Host.CreateApplicationBuilder()
            .ConfigureServices();
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

public static class AppHost
{
    public static HostApplicationBuilder ConfigureServices(this HostApplicationBuilder builder)
    {
        builder.Services.AddTransient<IProjectService, ProjectService>();

        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient(sp =>
        {
            return new MainWindow
            {
                DataContext = sp.GetRequiredService<MainViewModel>(),
            };
        });

        return builder;
    }
}
