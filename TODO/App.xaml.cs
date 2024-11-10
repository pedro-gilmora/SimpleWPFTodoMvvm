using System.Configuration;
using System.Data;
using System.Windows;

namespace TODO;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);


        // Set initial theme based on OS theme
        UpdateTheme(ThemeHelper.IsDarkTheme());

        // Start listening for theme changes
        ThemeHelper.StartListeningForThemeChanges();
        ThemeHelper.ThemeChanged += OnThemeChanged;
    }

    protected override void OnExit(ExitEventArgs e)
    {
        ThemeHelper.StopListeningForThemeChanges();
        base.OnExit(e);
    }

    private void OnThemeChanged(object? sender, bool isDarkTheme)
    {
        UpdateTheme(isDarkTheme);
    }

    private void UpdateTheme(bool isDarkTheme)
    {
        // Clear existing theme
        Resources.MergedDictionaries.Clear();

        // Apply new theme based on OS setting
        var themeUri = new Uri(isDarkTheme ? "Dark.xaml" : "Light.xaml", UriKind.Relative);
        Resources.MergedDictionaries.Add(new ResourceDictionary { Source = themeUri });
    }
}
