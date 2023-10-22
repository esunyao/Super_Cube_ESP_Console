namespace Super_Cube_ESP_Console;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // 导航
        Routing.RegisterRoute(nameof(MainConsolePage), typeof(MainConsolePage));
    }
}