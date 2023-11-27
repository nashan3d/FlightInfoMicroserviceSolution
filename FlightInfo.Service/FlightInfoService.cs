using FlightInfo.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FlightInfo.Service
{
    public class FlightInfoService : IFlightInfoService
    {
        private readonly ILogger<FlightInfoService> _logger;

        public FlightInfoService(ILogger<FlightInfoService> logger)
        {
            _logger = logger;
        }

        public async Task<List<Flight>> GetAllFlightByDepartue(string departureCity)
        {
            var flights = await GetFlights();

            return flights.FlightList.Where(x => x.DepartureCity == departureCity).ToList();
        }

        public async Task<List<Flight>> GetAllFlightIno()
        {
            var flights = await GetFlights();

            return flights.FlightList.ToList();
        }

        private async Task<Flights> GetFlights()
        {
            var flights = new Flights();

            try
            {
                using var client = new HttpClient();

                _logger.LogInformation("Begin fetch from external API");

                client.BaseAddress = new Uri("https://flighttestservice.azurewebsites.net/flights");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("");
                if (response.IsSuccessStatusCode)
                {
                    var xml = response.Content.ReadAsStringAsync().Result;
                    XmlSerializer serializer = new XmlSerializer(typeof(Flights));

                    using StringReader reader = new StringReader(xml);
                    flights = (Flights)serializer.Deserialize(reader);


                }

                _logger.LogInformation("Complete read  response from external API");
            }
            catch (Exception ex)
            {

                _logger.LogError("Error occured", ex.Message);
            }

            return flights;

        }
    }
}
