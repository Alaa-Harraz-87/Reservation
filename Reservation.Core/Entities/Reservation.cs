using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reservation.Core.Entities
{
    public class Reservation
    {
        [Key]
        public Guid Id { get; set; }
        [EmailAddress]
        public string UserEmail { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now; // assume the reservation for today as mentioned 
        public int TripRouteId { get; set; }
        
        [ForeignKey("TripRouteId")]
        public virtual TripRoute TripRoute { get; set; } = new TripRoute();
        public virtual ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();

    }
}
