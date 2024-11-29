using Reservation.Core.Dto;
using Reservation.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Core.Interfaces
{
    public interface IReservationRepository
    {
        Task<int> GetTicketsCountByTripRouteIdAsync(int tripRouteId);
        Task<List<Seat>> GetReservedSeatsByTripRouteIdAsync(List<int> seatsIds, int tripRouteId);
        Task<int> AddAsync(Reservation.Core.Entities.Reservation reservation);

        Task<TripRoute> GetTripRouteByIdAsync(int id);

        Task<List<Reservation.Core.Entities.Reservation>> GetAllReservationAsync();

        Task<List<FrequentTripResponse>> GetFrequentTripByUserAsync();
    }
}
