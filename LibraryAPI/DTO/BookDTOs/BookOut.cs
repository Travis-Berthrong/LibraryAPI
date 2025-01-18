using LibraryAPI.Data.Enums;
using LibraryAPI.Entities.BookDataEntities;

namespace LibraryAPI.DTO.BookDTOs
{
    public class BookOut
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public string? Description { get; set; }
        public DateOnly PublicationDate { get; set; }
        public int PageCount { get; set; }
        public BookGenre Genre { get; set; }
        public int NumAvailable { get; set; }
        public int NumTotal { get; set; }

        public BookOut(Book book)
        {
            Id = book.Id;
            Title = book.Title;
            Author = book.Author;
            Description = book.Description;
            PublicationDate = book.PublicationDate;
            PageCount = book.PageCount;
            Genre = book.Genre;
            NumAvailable = book.NumAvailable;
            NumTotal = book.NumTotal;
        }

    }
}
