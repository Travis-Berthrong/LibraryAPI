using Microsoft.AspNetCore.Mvc;
using LibraryAPI.DTO.BookDTOs;
using LibraryAPI.Services;
using LibraryAPI.Entities.BookDataEntities;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController(BookService bookService) : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Book> books = await bookService.GetBooks();
            List<BookOut> books_out = new List<BookOut>();
            foreach (Book book in books)
            {
                BookOut book_out = new BookOut(book);
                books_out.Add(book_out);
            }
            return Ok(books_out);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Book? book = await bookService.GetBook(id);
            if (book != null)
            {
                BookOut book_out = new BookOut(book);
                return Ok(book_out);
            }
            return NotFound();
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookIn bookInDto)
        {
            Book book = new Book
            {
                Title = bookInDto.Title,
                Author = bookInDto.Author,
                Description = bookInDto.Description,
                PublicationDate = bookInDto.PublicationDate,
                PageCount = bookInDto.PageCount,
                Genre = bookInDto.Genre,
                NumAvailable = bookInDto.NumAvailable,
                NumTotal = bookInDto.NumTotal
            };
            await bookService.CreateBook(book);
            return Ok("Book created successfully!");

        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] BookIn bookdto)
        {
            Book? book = await bookService.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }
            book.Title = bookdto.Title;
            book.Author = bookdto.Author;
            book.Description = bookdto.Description;
            book.PublicationDate = bookdto.PublicationDate;
            book.PageCount = bookdto.PageCount;
            book.Genre = bookdto.Genre;
            book.NumAvailable = bookdto.NumAvailable;
            book.NumTotal = bookdto.NumTotal;
            await bookService.UpdateBook(book);
            return Ok("Book updated successfully!");
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Book? book = await bookService.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }
            await bookService.DeleteBook(book);
            return Ok("Book deleted successfully!");
        }
    }
}
