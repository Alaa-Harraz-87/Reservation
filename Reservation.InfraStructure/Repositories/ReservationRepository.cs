using Microsoft.EntityFrameworkCore;
using Reservation.Core.Entities;
using Reservation.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reservation.Core.Entities;
using Reservation.Core.Dto;
using System.ComponentModel.DataAnnotations;

namespace Reservation.InfraStructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {

        private readonly ReservationContext _context;
        public ReservationRepository(ReservationContext reservationContext)
        {

            this._context = reservationContext;
        }

        public async Task<int>  GetTicketsCountByTripRouteIdAsync(int tripRouteId)
        {
             return await _context.Tickets.Include(r => r.Reservation)
                                            .Where(r => r.Reservation.TripRouteId == tripRouteId).CountAsync();
        }


        public async Task<List<Seat>> GetReservedSeatsByTripRouteIdAsync(List<int> seatsIds, int tripRouteId)
        {


           return  await _context.Tickets.Include(r => r.Reservation)
                                               .Where(r => r.Reservation.TripRouteId == tripRouteId && seatsIds.Contains(r.Seat.Id)).Select(r => r.Seat).ToListAsync();
            


            
        }



        public async Task<int> AddAsync(Reservation.Core.Entities.Reservation reservation)
        {
            await _context.Reservations.AddAsync(reservation);
            return await _context.SaveChangesAsync();
        }


        public async Task<TripRoute> GetTripRouteByIdAsync(int id)
        {
            return await _context.TripRoutes.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<FrequentTripResponse>> GetFrequentTripByUserAsync()
        {
            var result = await _context.Reservations.GroupBy(r => new { r.UserEmail, r.TripRouteId })
                                                     .Select(g => new
                                                     {
                                                         g.Key.UserEmail,
                                                         g.Key.TripRouteId,
                                                         Count = g.Count()
                                                     }).GroupBy(x => x.UserEmail)
            
                                                    .Select(g => new FrequentTripResponse
                                                    {
                                                        UserEmail = g.Key,
                                                        TripRoute = g.OrderByDescending(x => x.Count).First().TripRouteId
                                                    }).ToListAsync();


            return result;
          
        }

        // This Method just for test 
        public async Task<List<Reservation.Core.Entities.Reservation>> GetAllReservationAsync()
        {

            return await _context.Reservations.Include(r => r.Tickets)
                                                    .ThenInclude(t => t.Seat)
                                                     .ThenInclude(s => s.Bus)
                                                .Include(t => t.TripRoute).ToListAsync();
        }


    }
}
