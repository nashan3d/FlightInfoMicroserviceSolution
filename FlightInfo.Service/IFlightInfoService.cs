using FlightInfo.Domain;


namespace FlightInfo.Service
{
    public interface IFlightInfoService
    {
        Task<List<Flight>> GetAllFlightIno();

        Task<List<Flight>> GetAllFlightByDepartue(string destination);
    }
}
