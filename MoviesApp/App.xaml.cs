using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MoviesApp.Services;
using MoviesApp.ViewModel;
using System.Configuration;
using System.Data;
using System.Windows;

namespace MoviesApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private IHost? _host;
    private void Application_Startup(object sender, StartupEventArgs e)
    {
        var builder = Host.CreateApplicationBuilder(new HostApplicationBuilderSettings
        {
            ContentRootPath = AppContext.BaseDirectory,
        });

        builder.ConfigureServices();

        _host = builder.Build();

        var mainWindow = _host.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();
        
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
        //Services
        builder.Services.AddTransient<IMovieService, MovieService>();
        builder.Services.AddTransient<IDirectorService, DirectorService>();
        builder.Services.AddTransient<IGenreService, GenreService>();

        //Windows
        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient(sp =>
        {
            return new MainWindow
            {
                DataContext = sp.GetRequiredService<MainViewModel>()
            };
        });

        return builder;
    }
}
