using System.ComponentModel.DataAnnotations;
using System.Resources;

namespace NEWSHOREAIR.Dto
{
    public class JourneyRequest : IValidatableObject
    {
        required public string Origin { get; set; }
        required public string Destination { get; set; }
        public int MaxFlights { get; set; } = 0;
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            if (Origin == Destination)
            {
                ResourceManager resxManager = new("RecruitingExternalSource.Messages", typeof(RecruitingExternalSource.Messages).Assembly);                
                results.Add(new ValidationResult(resxManager.GetString("OriginDestinationAreSame")));
            }
            if (Origin.Length > 3 || Destination.Length > 3)
            {
                ResourceManager resxManager = new("RecruitingExternalSource.Messages", typeof(RecruitingExternalSource.Messages).Assembly);
                results.Add(new ValidationResult(resxManager.GetString("ManualyModified")));
            }
            return results;
        }
    }
}
