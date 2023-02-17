namespace Business.Models
{
    public class Transport
    {
        public Transport(string flightCarrier, string flightNumber)
        {
            FlightCarrier = flightCarrier;
            FlightNumber = flightNumber;
        }
        public string? FlightCarrier { get; private set; }
        public string? FlightNumber { get; private set; }
    }
}