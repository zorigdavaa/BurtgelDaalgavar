using Homework.Shared.DTO;
using Homework.Shared.Entities;
using System;
using System.Collections.Generic;
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
        public async Task<WareHouse?> GetWareHouseAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<WareHouse>("api/WareHouse/" + id);
            if (response != null)
            {
                return response;
            }
            return null;
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

        public async Task GetWareHousesWithItemsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<WareHouse>>("api/WareHouse/withItem");
            if (response != null)
            {
                WareHouses = response;
            }
        }
        public async Task<List<TransactionProd>?> GetTransactionToWareHouse(int warehouseId)
        {
            var response = await _httpClient.GetAsync(_httpClient.BaseAddress + "api/WareHouse/trato/" + warehouseId);

            if (!response.IsSuccessStatusCode)
            {
                // Handle non-OK status code
                //response.EnsureSuccessStatusCode();
                return null;
            }

            return await response.Content.ReadFromJsonAsync<List<TransactionProd>>();

            //var response = await _httpClient.GetFromJsonAsync<List<TransactionProd>>("api/WareHouse/trato/" + warehouseId);
            //if (response != null)
            //{
            //    return response;
            //}
            //return null;
        }
        public async Task<List<TransactionProd>?> GetTransactionFromWareHouse(int warehouseId)
        {
            var response = await _httpClient.GetAsync(_httpClient.BaseAddress + "api/WareHouse/trafrom/" + warehouseId);

            if (!response.IsSuccessStatusCode)
            {
                // Handle non-OK status code
                //response.EnsureSuccessStatusCode();
                return null;
            }

            return await response.Content.ReadFromJsonAsync<List<TransactionProd>>();
            //var response = await _httpClient.GetFromJsonAsync<List<TransactionProd>>("api/WareHouse/trafrom/" + warehouseId);
            //if (response != null)
            //{
            //    return response;
            //}
            //return null;
        }
    }
}
