namespace NEWSHOREAIR.Dto
{
    public class Journey
    {
        required public List<Flight> Flights { get; set; }
        required public string Origin { get; set; }
        required public string Destination { get; set; }
        required public double Price { get; set; }
    }
}
