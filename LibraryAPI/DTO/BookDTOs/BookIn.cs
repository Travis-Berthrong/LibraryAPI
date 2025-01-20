using System.ComponentModel.DataAnnotations;
using LibraryAPI.Data.Validators;

namespace LibraryAPI.DTO.BookDTOs
{
    [BookCountValidator, PageCountValidator]
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

        [Required, BookGenreValidator]
        public string Genre { get; set; } = null!;

        [Required]
        public int NumAvailable { get; set; }

        [Required]
        public int NumTotal { get; set; }
    }
}
