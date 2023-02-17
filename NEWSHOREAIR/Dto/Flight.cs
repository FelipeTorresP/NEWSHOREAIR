using System.ComponentModel.DataAnnotations;

namespace NEWSHOREAIR.Dto
{
    public class Flight
    {
        required public Transport Transport { get; set; }
        required public string Origin { get; set; }
        required public string Destination { get; set; }
        required public double Price { get; set; }

    }
}
