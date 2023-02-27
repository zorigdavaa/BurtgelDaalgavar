using Homework.Shared;
using Shared;

namespace Homework.Client.Services.WarehouseService
{
    public interface IWarehouseService
    {
        public List<WareHouse> WareHouses { get; set; }
        public Task GetWareHousesAsync();
        public Task<WareHouse> GetWareHouseAsync(int id);
        public Task AddProductToWareHouse(TransactionProd addingBaraa);
    }
}
