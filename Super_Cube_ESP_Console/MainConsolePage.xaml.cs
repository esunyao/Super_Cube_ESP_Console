using Super_Cube_ESP_Console.ViewModel;

namespace Super_Cube_ESP_Console;

public partial class MainConsolePage : ContentPage
{
	
	public MainConsolePage(MainConsoleViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

	private void OnButtonPressed(object sender, EventArgs e)
	{
		if (sender is ImageButton button)
		{
			button.TranslationY = 2; // 垂直偏移量
			button.TranslationX = 2; // 水平偏移量
			button.Opacity = 0.8; // 
			if (button.Scale.Equals(0.8))
				button.Scale = 1;
			else if (button.Scale.Equals(1))
				button.Scale = 0.8;
		}
	}

	private void OnButtonReleased(object sender, EventArgs e)
	{
		if (sender is ImageButton button)
		{
			button.TranslationY = 0; // 恢复垂直偏移量
			button.TranslationX = 0; // 恢复水平偏移量
			button.Opacity = 1; // 恢复透明度
		}
	}
}