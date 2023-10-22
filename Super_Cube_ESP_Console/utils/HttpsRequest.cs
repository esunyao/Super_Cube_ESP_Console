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
        // 忽略证书验证（仅用于测试环境，生产环境请勿使用）
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
        // 忽略证书验证（仅用于测试环境，生产环境请勿使用）
        HttpClientHandler handler = new HttpClientHandler();
        handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

        using (HttpClient client = new HttpClient(handler))
        {
            // 设置请求的内容类型
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            // 将 JsonObject 对象序列化为 JSON 字符串
            string jsonString = dic.ToString();

            // 创建要发送的请求内容
            StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            // 发送 POST 请求
            HttpResponseMessage response = await client.PostAsync(url, content);

            // 检查响应状态码
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