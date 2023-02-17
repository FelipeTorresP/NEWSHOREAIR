namespace Business.Models
{
    public class Flight
    {
        public Flight(FlightRecruiting flightRecruiting)
        {
            Transport = new Transport(flightRecruiting.FlightCarrier, flightRecruiting.FlightNumber);
            Origin = flightRecruiting.DepartureStation;
            Destination = flightRecruiting.ArrivalStation;
            Price = flightRecruiting.Price;

        }
        public Transport Transport { get; private set; }
        public string? Origin { get; private set; }
        public string? Destination { get; private set; }
        public double Price { get; private set; }

    }
}
