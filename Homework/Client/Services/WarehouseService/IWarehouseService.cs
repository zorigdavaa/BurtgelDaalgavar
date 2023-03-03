using Homework.Shared.DTO;
using Homework.Shared.Entities;

namespace Homework.Client.Services.WarehouseService
{
    public interface IWarehouseService
    {
        public List<WareHouse> WareHouses { get; set; }
        public Task GetWareHousesAsync();
        public Task GetWareHousesWithItemsAsync();
        public Task<WareHouse?> GetWareHouseAsync(int id);
        public Task AddProductToWareHouse(TransactionProd addingBaraa);
        public Task<List<TransactionProd>?> GetTransactionToWareHouse(int warehouseId);
        public Task<List<TransactionProd>?> GetTransactionFromWareHouse(int warehouseId);
    }
}
