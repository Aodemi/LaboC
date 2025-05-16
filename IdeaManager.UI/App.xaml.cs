using IdeaManager.Services;
using IdeaManager.Data;
using IdeaManager.UI.ViewModels;
using IdeaManager.UI.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace IdeaManager.UI;

public partial class App : Application
{
    public static IServiceProvider ServiceProvider { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        var services = new ServiceCollection();

        // Registre Data et Services
        services.AddDataServices("Data Source=ideas.db");
        services.AddDomainServices();
        services.AddUIServices();

        // Ajout des vues
        services.AddSingleton<IdeaListView>();
        services.AddSingleton<IdeaFormView>();
        services.AddSingleton<MenuView>();

        // ViewModels
        services.AddSingleton<MainViewModel>();

        // Fenêtre principale
        services.AddSingleton<MainWindow>();

        ServiceProvider = services.BuildServiceProvider();

        var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
}
