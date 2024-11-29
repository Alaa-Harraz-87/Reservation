using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Core.Dto
{
    public class ReservationResponse
    {

        public ReservationResponse() { }
        public bool isSuccessed { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public ResevationData ResevationData { get; set; } = new ResevationData();
    }


    public class ResevationData
    {
         
        public ResevationData() { }

        public string Email { get; set; } = string.Empty;
        public string BusId { get; set; } = string.Empty ;
        public decimal Price { get; set; }
        public List<string> Seats { get; set; } = new List<string>();
    }
}
