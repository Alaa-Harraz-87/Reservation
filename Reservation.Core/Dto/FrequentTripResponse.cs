using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Core.Dto
{
    public class FrequentTripResponse
    {
        public string  UserEmail { get; set; } = string.Empty;

        public int TripRoute { get; set; } 
    }
}
