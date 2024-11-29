using Microsoft.EntityFrameworkCore;
using Reservation.Core.Entities;
using Reservation.Core.Interfaces;

namespace Reservation.InfraStructure
{
    public class ReservationContext : DbContext , IReservationContext
    {
        public ReservationContext(DbContextOptions<ReservationContext> options) : base(options) { }



        public DbSet<Reservation.Core.Entities.Reservation> Reservations {  get; set; }  
        public DbSet<Reservation.Core.Entities.Seat> Seats { get; set; }
        public DbSet<Reservation.Core.Entities.TripRoute> TripRoutes { get; set; }
        public DbSet<Reservation.Core.Entities.Ticket> Tickets { get; set; }
        public DbSet<Reservation.Core.Entities.Bus> Buses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            // Configure Bus entity
            modelBuilder.Entity<Bus>(entity =>
            {
                entity.HasKey(b => b.Id); 
                entity.Property(b => b.Name)
                      .IsRequired()
                      .HasMaxLength(100); 
                entity.Property(b => b.Capacity)
                      .IsRequired(); 
                
            });

            // Configure Seat entity
            modelBuilder.Entity<Seat>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(b => b.SeatNo)
                      .IsRequired()
                      .HasMaxLength(50);
               

            });

            // Configure Ticket entity
            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(t => t.Id); 
                entity.HasOne(t => t.Reservation)
                      .WithMany(r => r.Tickets)
                      .HasForeignKey(t => t.ReservationId);

               
            });

            // Configure Reservation entity
            modelBuilder.Entity<Reservation.Core.Entities.Reservation>(entity =>
            {
                entity.HasKey(r => r.Id); // Primary key
                entity.Property(r => r.UserEmail)
                      .IsRequired()
                      .HasMaxLength(255); // Required and max length
                entity.HasMany(r => r.Tickets)
                      .WithOne(t => t.Reservation)
                      .HasForeignKey(t => t.ReservationId);

            });


            // Seed initial data for buses and seats
            modelBuilder.Entity<Bus>().HasData(
                new Bus { Id = 1, Name = "Bus 1",  Capacity = 20 },
                new Bus { Id = 2, Name = "Bus 2",  Capacity = 20 }
            );

            var seats = new List<Seat>();
            for (int i = 1; i <= 20; i++)
            {
                seats.Add(new Seat {Id = i, SeatNo = $"A{i}", BusId = 1, Status = Core.Enums.SeatStatus.free });
                seats.Add(new Seat {Id = i + 20, SeatNo = $"A{i}", BusId =  2 , Status = Core.Enums.SeatStatus.free });
            }
            modelBuilder.Entity<Seat>().HasData(seats);

            modelBuilder.Entity<TripRoute>().HasData(
                new TripRoute { Id = 1, PickUp = "Cairo", Destination = "Aswan", Distance = 150, Name = "Cairo-Aswan", Type = Core.Enums.RoundType.Long, BusId = 1, Price = 10 },
                new TripRoute { Id = 2, PickUp = "Cairo", Destination = "Alexandria ", Distance = 90, Name = "Cairo-Alexandria ", Type = Core.Enums.RoundType.Short, BusId = 2, Price = 10 }
                );
        }
    }
}
