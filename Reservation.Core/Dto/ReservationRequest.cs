using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Core.Dto
{
    public class ReservationRequest
    {
        [EmailAddress]
        [Required]
        public string UserEmail { get; set; } = string.Empty;
        [Required]
        public int TripRouteId { get; set; }
        [Required]
        public List<int> Seats { get; set; } = new List<int>();
    }
}
