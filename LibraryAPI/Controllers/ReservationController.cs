using System.ComponentModel.DataAnnotations;
using LibraryAPI.DTO.ReservationDTOs;
using LibraryAPI.Entities.BookDataEntities;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController(ReservationService _service) : ControllerBase
    {
        // GET: api/<ReservationController>
        [HttpGet("{bookId}")]
        public async Task<IActionResult> GetReservations([Required] int bookId)
        {
            IEnumerable<Reservation>? reservations = await _service.GetReservations(bookId);
            if (reservations == null)
            {
                return NotFound();
            }
            List<ReservationOut> reservationOuts = new List<ReservationOut>();
            foreach (Reservation reservation in reservations)
            {
                reservationOuts.Add(new ReservationOut(reservation));
            }
            return Ok(reservationOuts);
        }

        // GET api/<ReservationController>/5
        [HttpGet("{bookId}/{reservationId}")]
        public async Task<IActionResult> Get([Required] int bookId, [Required] int reservationId)
        {

            Reservation? reservation = await _service.GetReservation(bookId, reservationId);
            if (reservation != null)
            {
                return Ok(new ReservationOut(reservation));
            }
            return NotFound();
        }

            // POST api/<ReservationController>
            [HttpPost]
        public async Task<IActionResult> Post([FromBody] ReservationIn reservationIn)
        {
            Reservation reservation = new Reservation
            {
                BookId = reservationIn.BookId,
                UserId = reservationIn.UserId,
                CheckoutDate = reservationIn.CheckoutDate
            };
            if (reservationIn.DueDate != null)
            {
                reservation.DueDate = reservationIn.DueDate;
            }
            if (reservationIn.ReturnDate != null)
            {
                reservation.ReturnDate = reservationIn.ReturnDate;
            }
            reservation.setReservationStatus(reservationIn.ReservationStatus);
            bool res = await _service.CreateReservation(reservation);
            if (!res)
            {
                return BadRequest("Reservation could not be created!");
            }
            return Ok("Reservation created successfully!");
        }

        // PUT api/<ReservationController>/5
        [HttpPut("{bookId}/{reservationId}")]
        public async Task<IActionResult> Put([Required] int bookId, [Required] int reservationId, [FromBody] ReservationIn reservationIn)
        {
            Reservation? reservation = await _service.GetReservation(bookId, reservationId);
            if (reservation == null)
            {
                return NotFound();
            }
            reservation.BookId = reservationIn.BookId;
            reservation.UserId = reservationIn.UserId;
            reservation.CheckoutDate = reservationIn.CheckoutDate;
            if (reservationIn.DueDate != null)
            {
                reservation.DueDate = reservationIn.DueDate;
            }
            if (reservationIn.ReturnDate != null)
            {
                reservation.ReturnDate = reservationIn.ReturnDate;
            }
            reservation.setReservationStatus(reservationIn.ReservationStatus);
            bool res = await _service.UpdateReservation(reservation);
            if (!res)
            {
                return BadRequest("Reservation could not be updated!");
            }
            return Ok("Reservation updated successfully!");
        }

        // DELETE api/<ReservationController>/5
        [HttpDelete("{bookId}/{reservationId}")]
        public async Task<IActionResult> Delete([Required] int bookId, [Required] int reservationId)
        {
            Reservation? reservation = await _service.GetReservation(bookId, reservationId);
            if (reservation == null)
            {
                return NotFound();
            }
            bool res = await _service.DeleteReservation(reservation);
            if (!res)
            {
                return BadRequest("Reservation could not be deleted!");
            }
            return Ok("Reservation deleted successfully!");
        }
    }
}
