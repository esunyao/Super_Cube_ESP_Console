using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Super_Cube_ESP_Console.executor;
using Super_Cube_ESP_Console.utils;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;

namespace Super_Cube_ESP_Console.ViewModel;

public partial class MainViewModel : ObservableObject
{
    public MainViewModel()
    {

    }
    [ObservableProperty]
    string account;
    [ObservableProperty]
    string passwd;

    [RelayCommand]
    async void Login()
    {
        var mainView = new MainView();
        MauiProgram.matcher.RegisterHandlers(mainView);
        JsonDocument doc = await HttpsRequest.SendPostRequest("https://127.0.0.1:8000/login", new JsonObject
        {
            ["account"] = account,
            ["passwd"] = utils.encryption.MD5_Encrypte(passwd)
        });
        Console.WriteLine(account);
    }
}

class MainView
{
    [Handle("nima")]
    public async Task ServerCallBack(https_handler matcher, Dictionary<string, object> kwargs)
    {
        Console.WriteLine("ServerCallBack");
        await Task.Yield();
    }
}