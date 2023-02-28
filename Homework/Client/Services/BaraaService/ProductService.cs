using Homework.Shared.DTO;
using Homework.Shared.Entities;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace Homework.Client.Services.BaraaService
{
    public class ProductService : IProductService
    {
        HttpClient _httpClient;
        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public List<Product> Items { get; set; } = new List<Product>();


        public async Task AddItemAsync(ProductDTO addingBaraa)
        {
            Console.WriteLine(JsonSerializer.Serialize(addingBaraa));
            await _httpClient.PostAsJsonAsync("api/Product", addingBaraa);

            //HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Post, "api/Baraa");
            //var json = JsonSerializer.Serialize(addingBaraa);
            //httpRequest.Content = new StringContent(json);
            //await _httpClient.SendAsync(httpRequest);
        }

        public async Task EditItem(ProductDTO editingBaraa)
        {
            await _httpClient.PutAsJsonAsync("api/Product/" + editingBaraa.Id, editingBaraa);
        }

        public Task<Product> GetItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task GetItemsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Product>>("api/Product");
            if (response != null)
            {
                Items = response;
            }
        }



        public async Task RemoveItem(int id)
        {
            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Delete, "api/Product/" + id);
            await _httpClient.SendAsync(httpRequest);
        }
    }
}
