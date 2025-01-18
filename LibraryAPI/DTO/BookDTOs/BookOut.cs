using LibraryAPI.Data.Enums;
using LibraryAPI.Entities.BookDataEntities;

namespace LibraryAPI.DTO.BookDTOs
{
    public class BookOut(Book book)
    {
        public int Id { get; set; } = book.Id;
        public string Title { get; set; } = book.Title;
        public string Author { get; set; } = book.Author;
        public string? Description { get; set; } = book.Description;
        public DateOnly PublicationDate { get; set; } = book.PublicationDate;
        public int PageCount { get; set; } = book.PageCount;
        public BookGenre Genre { get; set; } = book.Genre;
        public int NumAvailable { get; set; } = book.NumAvailable;
        public int NumTotal { get; set; } = book.NumTotal;
    }
}
