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
        JsonDocument doc = await HttpsRequest.SendPostRequest("https://localhost:8081/api/v1/login", new JsonObject
        {
            ["account"] = account,
            ["password"] = utils.encryption.MD5_Encrypte(passwd)
        });
        JsonElement doc_root = doc.RootElement;
        if (doc_root.TryGetProperty("data", out JsonElement value))
        {
            JsonDocument data = JsonDocument.Parse(value.GetString());
            JsonElement data_root = data.RootElement;
            if (data_root.TryGetProperty("token", out JsonElement val))
            {
                Console.WriteLine(val.GetString()); // Output: value
                await Shell.Current.GoToAsync(nameof(MainConsolePage));
            }
        }
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