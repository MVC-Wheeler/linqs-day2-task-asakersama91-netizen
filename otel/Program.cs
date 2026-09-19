using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

using Microsoft.AspNetCore.Mvc;

namespace otel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : ControllerBase
    {
        [HttpGet("rooms")]
        public IActionResult GetRooms()
        {
            return Ok(new
            {
                Message = "Rooms retrieved successfully",
                Rooms = new[]
                {
                    new { Id = 1, Number = "101", Type = "Single", Price = 500 },
                    new { Id = 2, Number = "102", Type = "Double", Price = 800 },
                    new { Id = 3, Number = "201", Type = "Suite", Price = 1500 }
                }
            });
        }

        [HttpGet("rooms/{id}")]
        public IActionResult GetRoom(int id)
        {
            return Ok(new
            {
                Id = id,
                Number = "101",
                Type = "Double",
                Price = 800,
                Status = "Available"
            });
        }

        [HttpPost("rooms")]
        public IActionResult CreateRoom([FromBody] object room)
        {
            return Ok(new
            {
                Message = "Room created successfully",
                Room = room
            });
        }

        [HttpPut("rooms/{id}")]
        public IActionResult UpdateRoom(int id, [FromBody] object room)
        {
            return Ok(new
            {
                Message = "Room updated successfully",
                Id = id,
                Room = room
            });
        }

        [HttpDelete("rooms/{id}")]
        public IActionResult DeleteRoom(int id)
        {
            return Ok(new
            {
                Message = "Room deleted successfully",
                Id = id
            });
        }

        [HttpGet("guests")]
        public IActionResult GetGuests()
        {
            return Ok(new[]
            {
                new { Id = 1, Name = "Ahmed Ali", Phone = "01000000000" },
                new { Id = 2, Name = "Sara Mohamed", Phone = "01111111111" }
            });
        }

        [HttpGet("guests/{id}")]
        public IActionResult GetGuest(int id)
        {
            return Ok(new
            {
                Id = id,
                Name = "Ahmed Ali",
                Email = "ahmed@gmail.com",
                Phone = "01000000000"
            });
        }

        [HttpPost("guests")]
        public IActionResult CreateGuest([FromBody] object guest)
        {
            return Ok(new
            {
                Message = "Guest created successfully",
                Guest = guest
            });
        }

        [HttpPut("guests/{id}")]
        public IActionResult UpdateGuest(int id, [FromBody] object guest)
        {
            return Ok(new
            {
                Message = "Guest updated successfully",
                Id = id,
                Guest = guest
            });
        }

        [HttpDelete("guests/{id}")]
        public IActionResult DeleteGuest(int id)
        {
            return Ok(new
            {
                Message = "Guest deleted successfully",
                Id = id
            });
        }

        [HttpGet("reservations")]
        public IActionResult GetReservations()
        {
            return Ok(new[]
            {
                new
                {
                    Id = 1,
                    GuestName = "Ahmed Ali",
                    RoomNumber = "101",
                    CheckIn = "2026-09-05",
                    CheckOut = "2026-09-08",
                    Status = "Confirmed"
                },
                new
                {
                    Id = 2,
                    GuestName = "Sara Mohamed",
                    RoomNumber = "202",
                    CheckIn = "2026-09-10",
                    CheckOut = "2026-09-15",
                    Status = "Pending"
                }
            });
        }

        [HttpGet("reservations/{id}")]
        public IActionResult GetReservation(int id)
        {
            return Ok(new
            {
                Id = id,
                GuestId = 1,
                RoomId = 101,
                CheckIn = DateTime.Now,
                CheckOut = DateTime.Now.AddDays(3),
                Status = "Confirmed"
            });
        }

        [HttpPost("reservations")]
        public IActionResult CreateReservation([FromBody] object reservation)
        {
            return Ok(new
            {
                Message = "Reservation created successfully",
                Reservation = reservation
            });
        }

        [HttpPut("reservations/{id}")]
        public IActionResult UpdateReservation(
            int id,
            [FromBody] object reservation)
        {
            return Ok(new
            {
                Message = "Reservation updated successfully",
                Id = id,
                Reservation = reservation
            });
        }

        [HttpDelete("reservations/{id}")]
        public IActionResult DeleteReservation(int id)
        {
            return Ok(new
            {
                Message = "Reservation deleted successfully",
                Id = id
            });
        }

        [HttpGet("payments")]
        public IActionResult GetPayments()
        {
            return Ok(new[]
            {
                new
                {
                    Id = 1,
                    ReservationId = 1,
                    Amount = 2500,
                    Method = "Cash",
                    Status = "Paid"
                },
                new
                {
                    Id = 2,
                    ReservationId = 2,
                    Amount = 4000,
                    Method = "Card",
                    Status = "Paid"
                }
            });
        }

        [HttpPost("payments")]
        public IActionResult CreatePayment([FromBody] object payment)
        {
            return Ok(new
            {
                Message = "Payment created successfully",
                Payment = payment
            });
        }

        [HttpGet("payments/{id}")]
        public IActionResult GetPayment(int id)
        {
            return Ok(new
            {
                Id = id,
                Amount = 2500,
                Method = "Cash",
                Status = "Paid"
            });
        }

        [HttpPost("checkin/{reservationId}")]
        public IActionResult CheckIn(int reservationId)
        {
            return Ok(new
            {
                ReservationId = reservationId,
                Status = "Checked In",
                Time = DateTime.Now
            });
        }

        [HttpPost("checkout/{reservationId}")]
        public IActionResult CheckOut(int reservationId)
        {
            return Ok(new
            {
                ReservationId = reservationId,
                Status = "Checked Out",
                Time = DateTime.Now
            });
        }

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            return Ok(new
            {
                TotalRooms = 120,
                AvailableRooms = 45,
                OccupiedRooms = 65,
                TotalGuests = 350,
                TodayReservations = 18,
                TodayCheckIns = 12,
                TodayCheckOuts = 9,
                TotalRevenue = 125000
            });
        }
    }
}