using LibraryAPI.Data.BookData;
using LibraryAPI.Entities.BookDataEntities;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Services
{
    public class BookService(BookDataContext _context)
    {
        public async Task<IEnumerable<Book>> GetBooks()
        {
            IEnumerable<Book> books = await _context.Books.ToArrayAsync();
            return books;
        }
        public async Task<Book?> GetBook(int id)
        {
            Book? book = await _context.Books.FindAsync(id);
            return book;
        }
        public async Task CreateBook(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateBook(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteBook(Book book)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}
