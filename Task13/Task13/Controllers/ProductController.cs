using Microsoft.AspNetCore.Mvc;
using Task13.Models;
using Task13.Repositories;

namespace Task13.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsShortInfo()
        {
            return Ok(await _repository.GetAllWithShortInfoAsync());
        }

        [HttpGet("updated")]
        public async Task<IActionResult> GetUpdatedProductsFor()
        {
            return Ok(await _repository.GetAllUpdatedProductsAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateManyProducts(IEnumerable<Product> products)
        {
            await _repository.CreateManyAsync(products);
            return Ok( products);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFeaturelessProducts()
        {
            await _repository.DeleteProductsWithEmptyFeatures();
            return NoContent();
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateOneName(Guid id, [FromBody] string newName)
        {
            await _repository.UpdateProductNameAsync(id, newName);
            return NoContent();
        }

    }
}
