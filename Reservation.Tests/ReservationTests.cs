using Moq;
using Reservation.Core.Dto;
using Reservation.Core.Entities;
using Reservation.Core.Interfaces;
using Reservation.Core.Services.Impelmentation;

namespace Reservation.Tests
{
    public class Tests
    {
        private Mock<IReservationRepository> _mockRepository;
        private ReservationService _service;


        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IReservationRepository>();
            _service = new ReservationService(_mockRepository.Object);
        }

        


        [Test]
        public async Task AddReservation_LessThanCapacity_ShouldAddReservation()
        {
            // Arrange
            var seats = new List<int>() { 1, 2, 3 };
            var reservationRequest = new ReservationRequest {  UserEmail = "Valid@test.com", TripRouteId = 1, Seats = seats };
            Setup_Repo(seats, 0, new List<Seat>());
            // Act
            var result = await _service.CreateReservationAsync(reservationRequest);

            // Assert
            Assert.IsTrue(result.isSuccessed);
        }

        [Test]
        public async Task AddReservation_ExceededCapacity_ShouldReturnFalse()
        {
            // Arrange
            var seats = new List<int>() { 1, 2, 3 };
            var reservationRequest = new ReservationRequest { UserEmail = "Valid@test.com", TripRouteId = 1, Seats = seats };
            Setup_Repo(seats, Reservation.Core.Constants.BusCapacity, new List<Seat>());
            // Act
            var result = await _service.CreateReservationAsync(reservationRequest);

            // Assert
            Assert.IsFalse(result.isSuccessed);
        }


        [Test]
        public async Task AddReservation_AlreadySeatReserved_ShouldReturnFalse()
        {
            // Arrange
            var seats = new List<int>() { 1, 2, 3 };
            var reservedSeats = new List<Seat>() { new Seat() { Id = 1, BusId = 1 } };
            
            var reservationRequest = new ReservationRequest { UserEmail = "Valid@test.com", TripRouteId = 1, Seats = seats };
            Setup_Repo(seats,  1, reservedSeats);
            
            // Act
            var result = await _service.CreateReservationAsync(reservationRequest);

            // Assert
            Assert.IsFalse(result.isSuccessed);
        }




        private void Setup_Repo(List<int> newSeats, int reservedSeatsCount, List<Seat> reserveSeats)
        {
            var tripRoute = new TripRoute() { Id = 1, BusId = 1 };
            var reservation = new Reservation.Core.Entities.Reservation() { };
            

            _mockRepository.Setup(repo => repo.GetTripRouteByIdAsync(1)).ReturnsAsync(tripRoute);
            _mockRepository.Setup(repo => repo.GetTicketsCountByTripRouteIdAsync(1)).ReturnsAsync(reservedSeatsCount);
            _mockRepository.Setup(repo => repo.GetReservedSeatsByTripRouteIdAsync(newSeats, 1)).ReturnsAsync(reserveSeats);

            _mockRepository.Setup(repo => repo.AddAsync(reservation)).ReturnsAsync(1);

        }
    }
}