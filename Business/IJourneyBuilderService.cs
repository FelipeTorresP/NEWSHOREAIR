using Business.Models;

namespace Business
{
    public interface IJourneyBuilderService
    {
        Task<List<Journey>> GetJourney(string origin, string destination, int maxFlights);
    }
}