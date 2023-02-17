using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    using Business.Models;
    using RecruitingExternalSource;
    using System.Data;
    using System.Resources;
    using Utils;
    public class JourneyBuilderService: IJourneyBuilderService
    {
        private readonly IAppVariables _appVariables;
        private readonly IHttpClient _httpClient;

        public JourneyBuilderService(IAppVariables appVariables, IHttpClient httpClient)
        {
            _appVariables = appVariables;
            _httpClient = httpClient;
        }
        public async Task<List<Journey>> GetJourney(string origin, string destination, int maxFlights)
        {
            int flightCount = 1;
            var url = _appVariables.GetAppSettingsVariable();
            string response = await _httpClient.GetAsync(url);
            List<FlightRecruiting> flightRecruitings = Mapper.MapResponseToObject(response);
            List<FlightRecruiting> initialPosibleFlights = flightRecruitings.Where(x => x.DepartureStation == origin).ToList();
            List<Journey> journeys = new();
            flightCount = BuildJourney(destination, maxFlights, flightCount, flightRecruitings, initialPosibleFlights, journeys);
            if (!journeys.Any())
            {
                ResourceManager resxManager = new("RecruitingExternalSource.Messages", typeof(RecruitingExternalSource.Messages).Assembly);
                throw new Exception(resxManager.GetString("JourneyNotPosible"));
            }

            return journeys;
        }

        private static int BuildJourney(string destination, int maxFlights, int flightCount, List<FlightRecruiting> flightRecruitings, List<FlightRecruiting> initialPosibleFlights, List<Journey> journeys)
        {
            foreach (var initialPosibleFlight in initialPosibleFlights)
            {
                List<Flight> flights = new()
                {
                    new Flight(initialPosibleFlight)
                };
                List<FlightRecruiting> flightRecruit = flightRecruitings;
                while (flights.Last().Destination != destination && (flightCount <= maxFlights || maxFlights == 0))
                {
                    var nextFlight = flightRecruit.Where(x => x.DepartureStation == flights.Last().Destination).FirstOrDefault();
                    if (nextFlight != null)
                    {
                        flightRecruit.Remove(nextFlight);
                        flights.Add(new Flight(nextFlight));
                        flightCount++;
                    }
                    else
                    {
                        break;
                    }

                }
                if (flights.Last().Destination == destination)
                {
                    journeys.Add(new Journey(flights));
                }

            }

            return flightCount;
        }
    }
}
