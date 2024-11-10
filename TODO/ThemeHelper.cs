using Microsoft.Win32;

namespace TODO;

public static class ThemeHelper
{
    public static event EventHandler<bool>? ThemeChanged; // bool indicates if Dark mode is active

    // Check OS theme on startup
    public static bool IsDarkTheme()
    {
        return Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize")?.GetValue("AppsUseLightTheme") is 0;
    }

    // Subscribe to OS theme change events
    public static void StartListeningForThemeChanges()
    {
        SystemEvents.UserPreferenceChanged += SystemEvents_UserPreferenceChanged;
    }

    public static void StopListeningForThemeChanges()
    {
        SystemEvents.UserPreferenceChanged -= SystemEvents_UserPreferenceChanged;
    }

    private static void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
    {
        if (e.Category == UserPreferenceCategory.General)
        {
            bool isDarkTheme = IsDarkTheme();
            ThemeChanged?.Invoke(null, isDarkTheme);
        }
    }
}
