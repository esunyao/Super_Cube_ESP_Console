using Microsoft.VisualBasic;
using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace Super_Cube_ESP_Console.utils;

public class encryption
{
    public static string MD5_Encrypte(string data)
    {
        using (MD5 md5 = new MD5CryptoServiceProvider())
        {
            // 将输入字符串转换为字节数组
            byte[] inputBytes = Encoding.UTF8.GetBytes(data);

            // 计算哈希值
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // 将哈希值转换为十六进制字符串
            StringBuilder hashStringBuilder = new();
            foreach (byte b in hashBytes)
            {
                hashStringBuilder.Append(b.ToString("x2")); // 使用小写十六进制表示
            }

            string hashResult = hashStringBuilder.ToString();

            return hashResult;
        }
    }

}