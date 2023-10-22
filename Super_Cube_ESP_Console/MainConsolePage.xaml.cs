using Super_Cube_ESP_Console.ViewModel;

namespace Super_Cube_ESP_Console;

public partial class MainConsolePage : ContentPage
{
	public MainConsolePage(MainConsoleViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}