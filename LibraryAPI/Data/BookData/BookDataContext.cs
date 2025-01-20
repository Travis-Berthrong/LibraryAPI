using System;
using System.Collections.Generic;
using LibraryAPI.DTO.ReservationDTOs;
using LibraryAPI.Entities.BookDataEntities;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Data.BookData;

public partial class BookDataContext : DbContext
{
    public BookDataContext()
    {
    }

    public BookDataContext(DbContextOptions<BookDataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Books__3214EC0788E13B52");

            entity.Property(e => e.Author).HasMaxLength(255);
            entity.Property(e => e.Genre).HasMaxLength(50);
            entity.Property(e => e.NumAvailable).HasColumnName("numAvailable");
            entity.Property(e => e.NumTotal).HasColumnName("numTotal");
            entity.Property(e => e.Title).HasMaxLength(100);
            entity.OwnsMany(e => e.Reservations, entity =>
            {
                entity.ToTable("Reservations");
                entity.HasKey(e => e.Id).HasName("PK__Reservat__3214EC07F7BF1BAA");

                entity.Property(e => e.ReservationStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.UserId)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Book).WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientCascade)
                    .HasConstraintName("FK_Reservations_Books");

            });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
