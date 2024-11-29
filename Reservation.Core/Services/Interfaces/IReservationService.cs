using Reservation.Core.Dto;
using Reservation.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Core.Services.Interfaces
{
    public interface IReservationService
    {
        Task<ReservationResponse> CreateReservationAsync(ReservationRequest reservationRequest);
        Task<List<Reservation.Core.Entities.Reservation>> GetAllReservationAsync();

        Task<List<FrequentTripResponse>> GetFrequentTripsAsync();

    }
}
