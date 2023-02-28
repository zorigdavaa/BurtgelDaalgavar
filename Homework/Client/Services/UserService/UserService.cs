using Homework.Shared.Entities;
using System.Text.Json;

namespace Homework.Client.Services.UserService
{

    public class UserService : IUserService
    {
        HttpClient _httpClient;
        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> Login(Userr user)
        {
            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7234/api/user");
            var json = JsonSerializer.Serialize(user);
            Console.WriteLine(json);
            httpRequest.Content = new StringContent(json);
            httpRequest.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await _httpClient.SendAsync(httpRequest);
            return response.IsSuccessStatusCode;

        }
    }
}
