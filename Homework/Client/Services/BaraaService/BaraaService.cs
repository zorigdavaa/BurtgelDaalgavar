using Shared;
using System.Net.Http;
using System.Net.Http.Json;

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
            }
        }
    }
}
