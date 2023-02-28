using Homework.Shared.DTO;
using Homework.Shared.Entities;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace Homework.Client.Services.WarehouseService
{
    public class WarehouseService : IWarehouseService
    {
        HttpClient _httpClient;
        public WarehouseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public List<WareHouse> WareHouses { get; set; } = new List<WareHouse>();
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
        public async Task AddProductToWareHouse(TransactionProd addingBaraa)
        {
            
            Console.WriteLine(JsonSerializer.Serialize(addingBaraa));
            var res = await _httpClient.PostAsJsonAsync("api/Warehouse", addingBaraa);
            Console.WriteLine("is Success is " + res.StatusCode);
            Console.WriteLine(await res.Content.ReadAsStringAsync());
        }
    }
}
