using Business.Models;
using Newtonsoft.Json;

namespace Utils
{
    public class Mapper
    {
        public static List<FlightRecruiting> MapResponseToObject(string response)
        {
            return JsonConvert.DeserializeObject<List<FlightRecruiting>>(response);
        }
    }
}
