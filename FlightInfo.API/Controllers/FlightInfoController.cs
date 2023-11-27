using FlightInfo.Domain;
using FlightInfo.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http.Headers;
using System.Xml.Serialization;

namespace FlightInfo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightInfoController : ControllerBase
    {
        private readonly IFlightInfoService _flightService;
        private readonly ILogger<FlightInfoController> _logger;
        public FlightInfoController(IFlightInfoService flightService, ILogger<FlightInfoController> logger)
        {
            _flightService = flightService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFlightInfo()
        {
            _logger.LogInformation("Start the getting flight inof");
            var flights = await _flightService.GetAllFlightIno();

            _logger.LogInformation($"Fetched Flight details {flights}");
            
            return Ok(flights);
        }

        [HttpGet("GetAllFlightsByDeparture")]
        public async Task<IActionResult> GetAllFlightsByDeparture(string departureCity)
        {
            _logger.LogInformation("Start the getting flight inof");
            var flights = await _flightService.GetAllFlightByDepartue(departureCity);

            _logger.LogInformation($"Fetched Flight details {flights}");

            return Ok(flights);
        }
    }
}
