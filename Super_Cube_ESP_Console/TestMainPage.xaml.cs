using Super_Cube_ESP_Console.ViewModel;

namespace Super_Cube_ESP_Console;

public partial class TestMainPage : ContentPage
{
	public int va;
	public TestMainPage(MainViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}