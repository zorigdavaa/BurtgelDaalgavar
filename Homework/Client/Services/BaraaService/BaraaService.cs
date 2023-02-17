using Shared;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace Homework.Client.Services.BaraaService
{
    public class BaraaService : IBaraaService
    {
        HttpClient _httpClient;
        public BaraaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public List<Baraa> Items { get; set; } = new List<Baraa>();
        public List<WareHouse> WareHouses { get; set; } = new List<WareHouse>();

        public async Task AddItemAsync(Baraa addingBaraa)
        {
            await _httpClient.PostAsJsonAsync("api/Baraa", addingBaraa);

            //HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Post, "api/Baraa");
            //var json = JsonSerializer.Serialize(addingBaraa);
            //httpRequest.Content = new StringContent(json);
            //await _httpClient.SendAsync(httpRequest);
        }

        public async Task EditItem(Baraa editingBaraa)
        {
            await _httpClient.PutAsJsonAsync("api/Baraa" + editingBaraa.Id, editingBaraa);
        }

        public Task<Baraa> GetItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task GetItemsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Baraa>>("api/Baraa");
            if (response != null)
            {
                Items = response;
            }
        }

        public Task<WareHouse> GetWareHouseAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task GetWareHousesAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<WareHouse>>("api/WareHouse");
            if (response != null)
            {
                WareHouses = response;
                Console.WriteLine(response.Count.ToString());
            }
        }

        public async Task RemoveItem(int id)
        {
            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Delete, "api/Baraa/" + id);
            await _httpClient.SendAsync(httpRequest);
        }
    }
}
