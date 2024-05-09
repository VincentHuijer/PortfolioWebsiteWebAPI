using CVWebsite.Interfaces;
using CVWebsite.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace CVWebsite.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Book>))]
        public IActionResult GetBooks()
        {
            var books = _bookRepository.GetBooks();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(books);
        }

        [HttpGet("{bookId}")]
        [ProducesResponseType(200, Type = typeof(Book))]
        [ProducesResponseType(400)]
        public IActionResult GetBook(int bookId)
        {
            if (!_bookRepository.BookExists(bookId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok();
        }
    }
}
