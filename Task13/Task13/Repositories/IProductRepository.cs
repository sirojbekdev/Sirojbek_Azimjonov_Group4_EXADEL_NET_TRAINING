using MongoDB.Bson;
using Task13.Models;

namespace Task13.Repositories
{
    public interface IProductRepository
    {
        Task<List<ProductDto>> GetAllWithShortInfoAsync();
        Task<List<Product>> GetAllUpdatedProductsAsync();
        Task CreateManyAsync(IEnumerable<Product> products);
        Task DeleteProductsWithEmptyFeatures();
        Task UpdateProductNameAsync(Guid id, string newName);
    }
}