using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Task13.Data;
using Task13.Models;

namespace Task13.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _products;

        public ProductRepository(IMongoClient client, IOptions<DatabaseSettings> databaseSettings)
        {
            var database = client.GetDatabase(databaseSettings.Value.DatabaseName);
            _products = database.GetCollection<Product>(databaseSettings.Value.ProductsCollectionName);
        }

        public async Task<List<ProductDto>> GetAllWithShortInfoAsync()
        {
            var emptyFilter = Builders<Product>.Filter.Empty;
            var productShortInfo = await _products.Find(emptyFilter).Project(x => new ProductDto() { Id = x.Id, Name = x.Name }).ToListAsync();
            return productShortInfo;
        }

        public async Task<List<Product>> GetAllUpdatedProductsAsync()
        {
            var products = await _products.Find(x => x.AuditInfo.Version > 1).SortBy(x => x.AuditInfo.Version).ToListAsync();
            return products;
        }

        public async Task CreateManyAsync(IEnumerable<Product> products)
        {
            await _products.InsertManyAsync(products);
        }

        public async Task DeleteProductsWithEmptyFeatures()
        {
            await _products.DeleteManyAsync(x => !x.Features.Any());
        }

        public async Task UpdateProductNameAsync(Guid id, string newName)
        {
            var filter = Builders<Product>.Filter.And(
            Builders<Product>.Filter.Eq(x => x.Id, id));
            var updates = Builders<Product>.Update.Inc(x => x.AuditInfo.Version, 1).Set(x => x.Name, newName);

            await _products.FindOneAndUpdateAsync(filter, updates);
        }
    }
}
