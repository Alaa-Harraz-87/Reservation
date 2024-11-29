using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Reservation.Core.Entities
{
    public class Bus
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // e.g., "Bus 1"
        public int Capacity { get; set; } = Constants.BusCapacity;

    }
}
