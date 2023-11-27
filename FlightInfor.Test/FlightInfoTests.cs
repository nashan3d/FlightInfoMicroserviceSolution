using FlightInfo.Service;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;

namespace FlightInfor.Test
{
    public class FlightInfoTests
    {
        [Fact]
        public async Task ShouldReturnAllFlights()
        {
            //Arrange
            var log = new Mock<ILogger<FlightInfoService>>();
            var flightInfoService = new FlightInfoService(log.Object);

            //act 
            var flights = await flightInfoService.GetAllFlightIno();

            //Assert
            flights.Count().ShouldBeGreaterThan(0);

        }

        [Fact]
        public async Task ShouldReturnAllFlightsForProvideDestination()
        {
            //Arrange
            var log = new Mock<ILogger<FlightInfoService>>();
            var flightInfoService = new FlightInfoService(log.Object);

            //act 
            var departureCity = "New York";
            var flights = await flightInfoService.GetAllFlightByDepartue(departureCity);

            //Assert
            flights.Count().ShouldBeGreaterThan(0);

        }
    }
}