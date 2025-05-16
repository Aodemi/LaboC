using IdeaManager.Data;
using IdeaManager.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using IdeaManager.UI.Views;

namespace IdeaManager.UI;
public partial class App : Application
{
    public static IServiceProvider ServiceProvider { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        var services = new ServiceCollection();

        services.AddDataServices("Data Source=ideas.db");
        services.AddDomainServices();
        services.AddUIServices();

        ServiceProvider = services.BuildServiceProvider();

        var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
}