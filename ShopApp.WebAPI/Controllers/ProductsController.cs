using Microsoft.AspNetCore.Mvc;
using ShopApp.Business.Abstract;
using ShopApp.Entity;
using ShopApp.WebAPI.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetAll();

            var productsDTO = new List<ProductDTO>();

            foreach (var p in products)
            {
                productsDTO.Add(ProductToDTO(p));
            }

            return Ok(productsDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var p = await _productService.GetByID(id);
            if (p == null)
            {
                return NotFound();
            }
            return Ok(ProductToDTO(p));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            await _productService.CreateAsync(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, ProductToDTO(product));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id,Product entity)
        {
            if(id!=entity.ProductId)
            {
                return BadRequest();
            }

            var product = await _productService.GetByID(id);

            if(product==null)
            {
                return NotFound();
            }

            await _productService.UpdateAsync(product, entity);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productService.GetByID(id);

            if (product == null)
            {
                return NotFound();
            }

            await _productService.DeleteAsync(product);

            return NoContent();
        }

        #region Private Methods
        private static ProductDTO ProductToDTO(Product p)
        {
            return new ProductDTO
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Url = p.Url,
                Price = p.Price,
                ImageUrl = p.ImageUrl,
                Description = p.Description,
            };
        }
        #endregion
    }
}
