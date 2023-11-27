using BookStore_API.Application.Repositories;
using Microsoft.AspNetCore.Mvc;

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
        public async Task Get()
        {
            await _productWriteRepository.AddAsync(new()
            {
                Name = "NewBook",
                Price = 1.500F
            });
            await _productWriteRepository.SaveAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var product = await _productReadRepository.GetByIdAsync(id);

            return Ok(product);

        }


    }
}
