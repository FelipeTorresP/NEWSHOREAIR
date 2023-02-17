
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NEWSHOREAIR.Command;
using NEWSHOREAIR.Dto;

namespace NEWSHOREAIR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JourneyController : ControllerBase
    {
        private IBuildJourneyCommand _buildJourneyCommand;
        private readonly ILogger<JourneyController> _logger;

        public JourneyController(IBuildJourneyCommand buildJourneyCommand, ILogger<JourneyController> logger)
        {
            _buildJourneyCommand = buildJourneyCommand;
            _logger = logger;
        }
        
        [HttpPost]
        public async Task<List<Journey>> Post([FromBody] Dto.JourneyRequest journeyRequest)
        {
            _logger.LogInformation("the client consult {DT}", DateTime.UtcNow.ToLongTimeString());
            return await _buildJourneyCommand.GetJourneysAsync(journeyRequest);

        }
    }
}
