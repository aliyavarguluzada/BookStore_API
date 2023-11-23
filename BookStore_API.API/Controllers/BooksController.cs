using Microsoft.AspNetCore.Mvc;

namespace BookStore_API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        //private readonly IBookService _bookService;

        public BooksController()
        {
        }
        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok();
        }
    }
}
