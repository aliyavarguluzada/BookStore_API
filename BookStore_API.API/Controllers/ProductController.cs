using BookStore_API.Application.Repositories;
using BookStore_API.Application.ViewModels.Products;
using BookStore_API.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookStore_API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;
        public ProductController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var product = _productReadRepository.GetAll();

            return Ok(product);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _productReadRepository.GetByIdAsync(id, false));
        }


        [HttpPost]
        public async Task<IActionResult> Post(Vm_Create_Product model)
        {

                var newProduct = await _productWriteRepository.AddAsync(new()
                {
                    Name = model.ProductName,
                    Price = model.ProductPrice,
                    Stock = model.ProductStock
                });
            await _productWriteRepository.SaveAsync();

            return StatusCode((int)HttpStatusCode.Created);
        }


        [HttpPut]
        public async Task<IActionResult> Put(Vm_Update_Product model)
        {
            Product product = await _productReadRepository.GetByIdAsync(model.Id);
            product.Stock = model.ProductStock;
            product.Price = model.ProductPrice;
            product.Name = model.ProductName;

            await _productWriteRepository.SaveAsync();
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveAsync();

            return Ok();
        }
    }
}
