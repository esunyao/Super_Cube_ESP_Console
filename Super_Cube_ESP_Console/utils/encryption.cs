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
            // �������ַ���ת��Ϊ�ֽ�����
            byte[] inputBytes = Encoding.UTF8.GetBytes(data);

            // �����ϣֵ
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // ����ϣֵת��Ϊʮ�������ַ���
            StringBuilder hashStringBuilder = new();
            foreach (byte b in hashBytes)
            {
                hashStringBuilder.Append(b.ToString("x2")); // ʹ��Сдʮ�����Ʊ�ʾ
            }

            string hashResult = hashStringBuilder.ToString();

            return hashResult;
        }
    }

}