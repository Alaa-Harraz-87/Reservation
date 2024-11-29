using Reservation.Core.Dto;
using Reservation.Core.Entities;
using Reservation.Core.Interfaces;
using Reservation.Core.Services.Interfaces;
using System.ComponentModel;

namespace Reservation.Core.Services.Impelmentation
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _repo;
        public ReservationService(IReservationRepository repo)
        {

            this._repo = repo;
        }


        public async Task<ReservationResponse> CreateReservationAsync(ReservationRequest reservationRequest)
        {

            // Validation 

            var tripRoute =  await _repo.GetTripRouteByIdAsync(reservationRequest.TripRouteId);

            if(tripRoute == null)
            {
                return new ReservationResponse()
                {
                    isSuccessed = false,
                    Message = "Invalid trip route"
                };
            }



            //User should get discount if he booked more than 5 seats
            if(reservationRequest.Seats.Count >  5 ) { 
             
                // calculate the discount 
            }

            //Number for reserved tickets should not exceed the bus capacity

            var bookedSeats = await  _repo.GetTicketsCountByTripRouteIdAsync(reservationRequest.TripRouteId);

            if(bookedSeats >= Constants.BusCapacity)
            {
                return new ReservationResponse()
                {
                    isSuccessed = false,
                    Message = "no capacity in the bus"
                };
            }

            // this validation is enough to check the capacity in the bus           
            var reservedSeats = await _repo.GetReservedSeatsByTripRouteIdAsync(reservationRequest.Seats, reservationRequest.TripRouteId);

            if(reservedSeats.Any() )
            {
                return new ReservationResponse()
                {
                    isSuccessed = false,
                    Message = $"seat  {string.Join(", ", reservedSeats.Select(s => s.SeatNo))} is already reserved "
                };
            }

            // TODO : use automapper 
           
            var reservation = new Reservation.Core.Entities.Reservation()
            {
           
                TripRoute = tripRoute,
                UserEmail = reservationRequest.UserEmail,
                Tickets = reservationRequest.Seats.Select(s => new Reservation.Core.Entities.Ticket()
                {
                    SeatId = s
                }).ToList()
            };

            await _repo.AddAsync(reservation);

            return new ReservationResponse()
            {
                isSuccessed = true,
                Message = "Your reservation Completed",
                ResevationData = new ResevationData()
                {
                    Email = reservationRequest.UserEmail,
                    BusId = Convert.ToString(tripRoute.BusId),
                    Price = tripRoute.Price,
                    Seats = reservationRequest.Seats.Select(s => Convert.ToString(s)).ToList()
                }
            };

        }




        public async Task<List<Reservation.Core.Entities.Reservation>> GetAllReservationAsync()
        {
            return await _repo.GetAllReservationAsync();
        }


        public async Task<List<FrequentTripResponse>> GetFrequentTripsAsync()
        {
            return await _repo.GetFrequentTripByUserAsync();
        }

    }
}
