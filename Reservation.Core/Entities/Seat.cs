using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reservation.Core.Enums;

namespace Reservation.Core.Entities
{
    public class Seat
    {
        [Key]
        public int Id { get; set; } 
        public string SeatNo { get; set; } = string.Empty;   // e.g., "A1"
        public int BusId { get; set; }
        
        public virtual Bus Bus { get; set; } 
        public SeatStatus Status { get; set; }  // "free" or "reserved"

        
    }
}
