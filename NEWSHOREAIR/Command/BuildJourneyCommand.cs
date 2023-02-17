using AutoMapper;
using Business;
using NEWSHOREAIR.Dto;

namespace NEWSHOREAIR.Command
{
    public class BuildJourneyCommand : IBuildJourneyCommand
    {
        IJourneyBuilderService _journeyBuilderService;
        IMapper _mapper;

        public BuildJourneyCommand(IJourneyBuilderService journeyBuilderService, IMapper mapper)
        {
            _journeyBuilderService = journeyBuilderService;
            _mapper = mapper;
        }

        public async Task<List<Journey>> GetJourneysAsync(JourneyRequest journeyRequest)
        {
            List<Business.Models.Journey> journeys = await _journeyBuilderService.GetJourney(journeyRequest.Origin, journeyRequest.Destination, journeyRequest.MaxFlights);
            return _mapper.Map<List<Journey>>(journeys);
        }
    }
}