using Homework.Shared.DTO;
using Homework.Shared.Entities;

namespace Homework.Client.Services.BaraaService
{
    public interface IProductService
    {
        public List<Product> Items { get; set; }

        public Task GetItemsAsync();
        public Task<Product> GetItemAsync(int id);

        public Task RemoveItem(int id);
        public Task AddItemAsync(ProductDTO addingBaraa);
        public Task EditItem(ProductDTO editingBaraa);

    }
}
