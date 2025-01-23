using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
    [NotMapped]

    public BookGenre Genre;

    public int NumAvailable { get; set; }

    public int NumTotal { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public string getGenre()
    {
        return Genre.ToString();
    }

    public void setGenre(string genre)
    {
        if (Enum.TryParse(genre, out BookGenre bookGenre))
        {
            Genre = bookGenre;
        }
    }
}
