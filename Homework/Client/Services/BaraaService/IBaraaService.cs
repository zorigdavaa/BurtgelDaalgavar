using Shared;

namespace Homework.Client.Services.BaraaService
{
    public interface IBaraaService
    {
        public List<Baraa> Items { get; set; }
        public List<WareHouse> WareHouses { get; set; }
        public Task GetItemsAsync();
        public Task<Baraa> GetItemAsync(int id);
        public Task GetWareHousesAsync();
        public Task<WareHouse> GetWareHouseAsync(int id);

    }
}
