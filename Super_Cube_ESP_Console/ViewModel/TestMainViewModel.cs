using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace Super_Cube_ESP_Console.ViewModel;

public partial class TestMainPageViewModel:ObservableObject
{
    private int _va;
    private SerialPort _serialPort = new SerialPort();
    public int va
    {
        get { return _va; }
        set { SetProperty(ref _va, value); }
    }
    
    public TestMainPageViewModel()
    {
        // 初始化串口对象
        _serialPort = new SerialPort("COM1", 9600); // 替换为您要使用的串口号和波特率
        _serialPort.DataReceived += OnDataReceived;
        _serialPort.Open();
    }
    
    private void OnDataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        SerialPort sp = (SerialPort)sender;
        string data = sp.ReadExisting(); // 假设数据以字符串形式返回

        // 假设您需要将接收到的数据转换为整数并更新 va 属性
        if (int.TryParse(data, out int result))
        {
            va = result;
        }
        else
        {
            // 数据转换失败时的处理逻辑
        }
    }
}