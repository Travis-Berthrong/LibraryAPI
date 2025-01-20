using LibraryAPI.Data.Enums;

namespace LibraryAPI.Entities.BookDataEntities;

public partial class Reservation
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public int BookId { get; set; }

    public DateOnly CheckoutDate { get; set; }

    public DateOnly? DueDate { get; set; }

    public DateOnly? ReturnDate { get; set; }

    public ReservationStatus ReservationStatus;

    public virtual Book Book { get; set; } = null!;

    public String getReservationStatus()
    {
        return ReservationStatus.ToString();
    }
    public void setReservationStatus(String status)
    {
        ReservationStatus = (ReservationStatus)Enum.Parse(typeof(ReservationStatus), status);
    }

}
