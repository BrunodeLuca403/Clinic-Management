using ClinicManagement.Core.Entitys.OpenIA;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClinicManagement.Infrastructure.Service
{
    public class OpenIAService : IAService
    {
        private readonly HttpClient _httpClient;
        private readonly OpenAIConfig _openAIConfig;
        public OpenIAService(HttpClient httpClient, IOptions<OpenAIConfig> openAIConfig)
        {
            _httpClient = httpClient;
            _openAIConfig = openAIConfig.Value;
        }

        public async Task<string> Complete(string systemPrompt, string userPrompt)
        {
            var apiKey = _openAIConfig.ApiKey;

            var message = new HttpRequestMessage(HttpMethod.Post, _openAIConfig.ResponseUrl);
            message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            var payload = new
            {
                model = "gpt-4.1-nano",
                input = $"System Prompt: {systemPrompt}. UserPrompt: {userPrompt}"
            };

            var json = JsonSerializer.Serialize(payload);
            message.Content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(message);

            var responseJson = await response.Content.ReadAsStringAsync();

            var openAiResponse = await response.Content.ReadFromJsonAsync<OpenAIResponse>();

            return openAiResponse?.Output.First()?.Content?.First()?.Text ?? string.Empty;

        }


    }
}
