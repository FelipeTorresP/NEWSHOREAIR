using NEWSHOREAIR.Dto;

namespace NEWSHOREAIR.Command
{
    public interface IBuildJourneyCommand
    {
        Task<List<Journey>> GetJourneysAsync(JourneyRequest journeyRequest);
    }
}