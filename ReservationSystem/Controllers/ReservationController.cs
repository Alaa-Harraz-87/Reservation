using Microsoft.AspNetCore.Mvc;
using Reservation.Core.Dto;
using Reservation.Core.Services.Interfaces;

namespace ReservationSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : ControllerBase
    {


        private readonly IReservationService _reservationService;

        public ReservationController(ILogger<ReservationController> logger, IReservationService reservationService)
        {
            this._reservationService = reservationService;

        }

        [HttpPost]
        public async Task<ActionResult> CreateReservation([FromBody] ReservationRequest reservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _reservationService.CreateReservationAsync(reservation);


            if (!result.isSuccessed)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }

        [HttpGet]
        public async Task<ActionResult> GetAllReservation()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _reservationService.GetAllReservationAsync();

            return Ok(result);

        }


        [HttpGet("GetFrequentTrip")]
        public async Task<ActionResult> GetFrequentTrip()
        {

            var result = await _reservationService.GetFrequentTripsAsync();

            return Ok(result);

        }
    }
}
