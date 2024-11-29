using Reservation.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Core.Entities
{
    public class TripRoute
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PickUp { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public decimal Distance { get; set; }
        public int BusId { get; set; }
        public decimal Price { get; set; }

        //[ForeignKey("BusId")]
       // public virtual Bus Bus { get; set; } = new Bus();

        public RoundType Type { get; set; } // Short or long
    }
}
