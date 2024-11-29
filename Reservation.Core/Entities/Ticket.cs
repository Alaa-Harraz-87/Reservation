using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Reservation.Core.Entities
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        
        public int SeatId { get; set; }
        public Guid ReservationId { get; set; }


        [ForeignKey("SeatId")]
        public Seat Seat { get; set; } 

        [JsonIgnore]
        [ForeignKey("ReservationId")]
        public virtual Reservation Reservation { get; set; } = new Reservation();

    }
}
