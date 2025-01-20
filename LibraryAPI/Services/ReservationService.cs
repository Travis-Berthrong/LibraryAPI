using LibraryAPI.Data.BookData;
using LibraryAPI.Data.Enums;
using LibraryAPI.Entities.BookDataEntities;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Services
{
    public class ReservationService(BookDataContext _context) 
    {
        private int updateBookNumAvailable(int currNumAvailable, ReservationStatus status)
        {
            switch (status)
            {
                case ReservationStatus.OnHold:
                    break;
                case ReservationStatus.Returned:
                    currNumAvailable++;
                    break;
                default:
                    currNumAvailable--;
                    return currNumAvailable;
            }
            return currNumAvailable;
        }
        public async Task<ICollection<Reservation>?> GetReservations(int bookId)
        {
            Book? book = await _context.Books.Include(a => a.Reservations).FirstOrDefaultAsync(a => a.Id == bookId);
            if (book == null)
            {
                return null;
            }
            return book.Reservations;

        }

        public async Task<Reservation?> GetReservation(int bookId, int reservationId)
        {
            Book? book = await _context.Books.Include(a => a.Reservations).FirstOrDefaultAsync(a => a.Id == bookId);
            if (book == null)
            {
                return null;
            }
            
            Reservation? reservation = book.Reservations.FirstOrDefault(a => a.Id == reservationId);
            return reservation;

        }
        public async Task<bool> CreateReservation(Reservation reservation)
        {
            Book? book = await _context.Books.FindAsync(reservation.BookId);
            if (book == null)
            {
                return false;
            }
            book.NumAvailable = updateBookNumAvailable(book.NumAvailable, reservation.ReservationStatus);
            if (book.NumAvailable < 0)
            {
                return false;
            }

            book.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateReservation(Reservation reservation)
        {
            Book? book = await _context.Books.FindAsync(reservation.BookId);
            if (book == null)
            {
                return false;
            }
            Reservation? oldReservation = book.Reservations.FirstOrDefault(a => a.Id == reservation.Id);
            if (oldReservation == null)
            {
                return false;
            }
            book.NumAvailable = updateBookNumAvailable(book.NumAvailable, reservation.ReservationStatus);
            if (book.NumAvailable < 0)
            {
                return false;
            }
            book.Reservations.Remove(oldReservation);
            book.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteReservation(Reservation reservation)
        {
            Book? book = await _context.Books.FindAsync(reservation.BookId);
            if (book == null)
            {
                return false;
            }
            book.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
