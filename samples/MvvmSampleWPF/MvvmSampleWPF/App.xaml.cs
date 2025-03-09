using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvvmSampleWPF.Services.UI;
using MvvmSampleWPF.Views.Windows;
using System.Configuration;
using System.Data;
using System.Reflection;
using System.Windows;
using Wpf.Ui;

namespace MvvmSampleWPF;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private IHost? _host;

    public App()
    {
        InitializeHost();
    }

    private void InitializeHost()
    {
        IHostBuilder builder = Host.CreateDefaultBuilder();
        builder.ConfigureServices((context, services) =>
        {
            services.AddHostedService<ApplicationHostService>();

            //add services
            services.AddNavigationViewPageProvider();
            services.AddSingleton<IWindow, MainWindow>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<ISnackbarService, SnackbarService>();
            services.AddSingleton<IContentDialogService, ContentDialogService>();
            services.AddSingleton<WindowsProviderService>();

            //use Reflection autoload
            var assembly = Assembly.GetExecutingAssembly();

            // add Window
            var windowTypes = assembly.GetTypes()
                .Where(t => t.Name.EndsWith("Window") && t.IsClass && !t.IsAbstract);
            foreach (var windowType in windowTypes)
            {
                services.AddSingleton(windowType);
            }

            // add ViewModel
            var viewModelTypes = assembly.GetTypes()
                .Where(t => t.Name.EndsWith("ViewModel") && t.IsClass && !t.IsAbstract);
            foreach (var viewModelType in viewModelTypes)
            {
                services.AddSingleton(viewModelType);
            }

            // add UserControl
            var usercontrols = assembly.GetTypes()
                .Where(t => t.Name.EndsWith("Control") && t.IsClass && !t.IsAbstract);
            foreach (var usercontrol in usercontrols)
            {
                services.AddSingleton(usercontrol);
            }

            // add View
            var viewTypes = assembly.GetTypes()
            .Where(t => t.Name.EndsWith("Page") && t.IsClass && !t.IsAbstract);
            foreach (var viewType in viewTypes)
            {
                services.AddSingleton(viewType);
            }

        });

        _host = builder.Build();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        try
        {
            if (_host != null)
            {
                await _host.StartAsync();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            if (_host != null)
            {
                await _host.StopAsync();
                _host.Dispose();
            }
        }

    }

    protected override async void OnExit(ExitEventArgs e)
    {
        try
        {
            if (_host != null)
            {
                await _host.StopAsync();
                _host.Dispose();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred during shutdown: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        base.OnExit(e);
    }
}

