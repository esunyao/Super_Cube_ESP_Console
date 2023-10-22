using Microsoft.VisualBasic;
using System;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
// using Windows.Data.Json;
// using Windows.Foundation.Collections;

namespace Super_Cube_ESP_Console.utils;

public class HttpsRequest
{
    public static async Task<JsonDocument> SendGetRequest(string url)
    {
        // ����֤����֤�������ڲ��Ի�����������������ʹ�ã�
        HttpClientHandler handler = new HttpClientHandler();
        handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

        using (HttpClient client = new HttpClient(handler))
        {
            HttpResponseMessage response = await client.GetAsync(url);
            string content = await response.Content.ReadAsStringAsync();
            try
            {
                JsonDocument doc = JsonDocument.Parse(content);
                await MauiProgram.matcher.ActivationHandler(doc.RootElement.GetProperty("execute").ToString(), new Dictionary<string, object>
                {
                    { "url", url }
                });
                return doc;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            };
            return null;
        }
    }

    public static async Task<JsonDocument> SendPostRequest(string url, System.Text.Json.Nodes.JsonObject dic)
    {
        // ����֤����֤�������ڲ��Ի�����������������ʹ�ã�
        HttpClientHandler handler = new HttpClientHandler();
        handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

        using (HttpClient client = new HttpClient(handler))
        {
            // �����������������
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            // �� JsonObject �������л�Ϊ JSON �ַ���
            string jsonString = dic.ToString();

            // ����Ҫ���͵���������
            StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            // ���� POST ����
            HttpResponseMessage response = await client.PostAsync(url, content);

            // �����Ӧ״̬��
            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                try
                {
                    JsonDocument doc = JsonDocument.Parse(responseContent);
                    await MauiProgram.matcher.ActivationHandler(doc.RootElement.GetProperty("execute").ToString(), new Dictionary<string, object>
                {
                    { "url", url }
                });
                    return doc;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                };
            }
            else
            {
                Console.WriteLine("Error: " + response.StatusCode);
            }
            
            return null;
        }
    }

}