using System.ComponentModel.DataAnnotations;
using LibraryAPI.Data.Enums;

namespace LibraryAPI.DTO.BookDTOs
{
    public class BookIn
    {
        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Author { get; set; } = null!;

        public string Description { get; set; } = "";

        [Required]
        public DateOnly PublicationDate { get; set; }

        [Required]
        public int PageCount { get; set; }

        [Required]
        public BookGenre Genre { get; set; }

        [Required]
        public uint NumAvailable { get; set; }

        [Required]
        public uint NumTotal { get; set; }
    }
}
