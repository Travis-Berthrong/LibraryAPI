using System.ComponentModel.DataAnnotations;
using LibraryAPI.Data.Enums;

namespace LibraryAPI.Data
{
    public class Book
    {
        public int Id { get; set; }
        [MaxLength(100), Required]
        public required string Title { get; set; }
        public required string Author { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateOnly PublicationDate { get; set; }

        public int PageCount { get; set; }

        public BookGenre Genre { get; set; }

        public override string ToString()
        {
            return $"Id: {Id},\nTitle: {Title},\nAuthor: {Author},\nDescription: {Description},\nPublication Date: {PublicationDate},\nPage Count: {PageCount},\nGenre: {Genre}";
        }

    }
}
