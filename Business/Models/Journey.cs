namespace Business.Models
{
    public class Journey
    {
        public Journey(List<Flight> flights)
        {
            Flights = flights;
            Origin = flights.First().Origin;
            Destination = flights.Last().Destination;
            Price = flights.Sum(x => x.Price);
        }

        public List<Flight> Flights { get; private set; }
        public string? Origin { get; private set; }
        public string? Destination { get; private set; }
        public double Price { get; private set; }

    }
}
