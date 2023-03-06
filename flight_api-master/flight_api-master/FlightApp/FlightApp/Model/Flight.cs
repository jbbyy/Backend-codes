using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace FlightApp.Model
{
    public class Flight
    {
        [Key]
        public string FlightNumber { get; set; }
        public string FlightSource { get; set; }
        public string FlightDestination { get; set; }
        public DateTime FlightDateTime { get; set; }
    }
}
