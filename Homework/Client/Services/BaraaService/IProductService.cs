using Shared;

namespace Homework.Client.Services.BaraaService
{
    public interface IProductService
    {
        public List<Product> Items { get; set; }
        public List<WareHouse> WareHouses { get; set; }
        public Task GetItemsAsync();
        public Task<Product> GetItemAsync(int id);
        public Task GetWareHousesAsync();
        public Task<WareHouse> GetWareHouseAsync(int id);
        public Task RemoveItem(int id);
        public Task AddItemAsync(Product addingBaraa);
        public Task EditItem(Product editingBaraa);

    }
}
