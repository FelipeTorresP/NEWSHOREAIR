using Business.Models;
using Newtonsoft.Json;

namespace Business.Utils
{
    public static class Mapper
    {
        public static List<FlightRecruiting> MapResponseToObject(string response)
        {
            return JsonConvert.DeserializeObject<List<FlightRecruiting>>(response);
        }
    }
}
