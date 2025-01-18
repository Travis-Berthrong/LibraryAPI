using System;
using System.Collections.Generic;
using LibraryAPI.Data.Enums;

namespace LibraryAPI.Entities.BookDataEntities;

public partial class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly PublicationDate { get; set; }

    public int PageCount { get; set; }

    public BookGenre Genre { get; set; }

    public int NumAvailable { get; set; }

    public int NumTotal { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
