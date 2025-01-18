using System;
using System.Collections.Generic;

namespace LibraryAPI.Entities.BookDataEntities;

public partial class Reservation
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public int BookId { get; set; }

    public DateOnly CheckoutDate { get; set; }

    public DateOnly? DueDate { get; set; }

    public DateOnly? ReturnDate { get; set; }

    public string ReservationStatus { get; set; } = null!;

    public virtual Book Book { get; set; } = null!;
}
