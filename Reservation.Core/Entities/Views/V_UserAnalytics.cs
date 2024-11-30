using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Core.Entities.Views
{
    public class V_UserAnalytics
    {
        public string UserEmail { get; set; }
        public string Pickup { get; set; }
        public string Destination { get; set; }
        public int DaysBetweenTrips { get; set; }
        
    }
}
