using System.Runtime.Serialization;

namespace Business.Models
{
    [DataContract]
    public class FlightRecruiting
    {
        [DataMember]
        public string? FlightNumber { get; private set; }
        [DataMember]
        public string? FlightCarrier { get; private set; }
        [DataMember]
        public string? DepartureStation { get; private set; }
        [DataMember]
        public string? ArrivalStation { get; private set; }
        [DataMember]
        public double Price { get; private set; }
    }
}
