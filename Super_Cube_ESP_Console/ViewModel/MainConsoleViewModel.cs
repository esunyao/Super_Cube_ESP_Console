using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace Super_Cube_ESP_Console.ViewModel;

public partial class MainConsoleViewModel:ObservableObject
{
    public MainConsoleViewModel()
    {

    }
    [RelayCommand]
    async void StartSports()
    {
        await Shell.Current.GoToAsync(nameof(TestMainPage));
    }
}
