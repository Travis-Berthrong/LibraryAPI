using LibraryAPI.Data.Enums;
using LibraryAPI.DTO.BookDTOs;
using LibraryAPI.Entities.BookDataEntities;

namespace LibraryAPI.DTO.ReservationDTOs
{
    public class ReservationOut
    {
        public int Id { get; set; }

        public string UserId { get; set; } = null!;

        public int BookId { get; set; }

        public DateOnly CheckoutDate { get; set; }

        public DateOnly? DueDate { get; set; }

        public DateOnly? ReturnDate { get; set; }

        public String ReservationStatus { get; set; } = null!;

        public virtual BookOut Book { get; set; } = null!;

        public ReservationOut(Reservation reservation)
        {
            Id = reservation.Id;
            UserId = reservation.UserId;
            BookId = reservation.BookId;
            CheckoutDate = reservation.CheckoutDate;
            DueDate = reservation.DueDate;
            ReturnDate = reservation.ReturnDate;
            ReservationStatus = reservation.getReservationStatus();
            Book = new BookOut(reservation.Book);
        }
    }
}
