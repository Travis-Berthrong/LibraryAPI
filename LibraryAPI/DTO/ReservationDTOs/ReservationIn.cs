using System.ComponentModel.DataAnnotations;
using LibraryAPI.Data.Enums;
using LibraryAPI.Data.Validators;
using LibraryAPI.Entities.BookDataEntities;

namespace LibraryAPI.DTO.ReservationDTOs
{
    public class ReservationIn
    {
        [Required]
        public string UserId { get; set; } = null!;

        [Required]
        public int BookId { get; set; }

        [Required]
        public DateOnly CheckoutDate { get; set; }

        public DateOnly? DueDate { get; set; }

        public DateOnly? ReturnDate { get; set; }

        [Required, ReservationStatusValidator]
        public String ReservationStatus { get; set; } = null!;

    }
}
