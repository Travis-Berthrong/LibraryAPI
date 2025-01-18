using System;
using System.Collections.Generic;

namespace LibraryAPI.Entities.BookDataEntities;

public partial class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly PublicationDate { get; set; }

    public int PageCount { get; set; }

    public string Genre { get; set; } = null!;

    public int? NumAvailable { get; set; }

    public int? NumTotal { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
