using Homework.Shared;
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
            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Post, "api/User");
            var json = JsonSerializer.Serialize(user);
            httpRequest.Content = new StringContent(json);
            HttpResponseMessage response = await _httpClient.SendAsync(httpRequest);
            return response.IsSuccessStatusCode;

        }
    }
}
