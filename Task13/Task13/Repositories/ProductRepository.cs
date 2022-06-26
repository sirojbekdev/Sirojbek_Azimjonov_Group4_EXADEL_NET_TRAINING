using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Task13.Models;

namespace Task13.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _products;
        public ProductRepository(IOptions<DatabaseSettings> databaseSettings)
        {
            var client = new MongoClient(databaseSettings.Value.ConnectionString);
            var database = client.GetDatabase(databaseSettings.Value.DatabaseName);
            _products = database.GetCollection<Product>(databaseSettings.Value.ProductsCollectionName);
        }

        public async Task<List<ProductShortInfo>> GetAllWithShortInfoAsync()
        {
            var emptyFilter = Builders<Product>.Filter.Empty;
            var productShortInfo = await _products.Find(emptyFilter).Project(x=> new ProductShortInfo() { Id = x.Id, Name = x.Name}).ToListAsync();
            return productShortInfo;
        }

        public async Task<List<Product>> GetAllUpdatedProductsAsync()
        {
            var products = await _products.Find(x=>x.AuditInfo.Version > 1).SortBy(x=>x.AuditInfo.Version).ToListAsync();
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
            var product = Builders<Product>.Filter.Eq(x => x.Id, id);
            var newProdVersion = _products.Find(product).FirstOrDefault().AuditInfo.Version + 1;
            var update = Builders<Product>.Update.Set(x => x.Name, newName).Set(x=>x.AuditInfo.Version, newProdVersion);
            var result = await _products.UpdateOneAsync(product, update);
        }
    }
}
