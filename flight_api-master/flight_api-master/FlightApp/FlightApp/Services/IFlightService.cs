using FlightApp.Model;
using Microsoft.VisualBasic;

namespace FlightApp.Services
{
    public interface IFlightService
    {
        public bool AddFlight(Flight flight);
        public bool ModifyFlight(Flight flight, string flightnumber);

        public bool DeleteFlight(string flightnumber);
        public Flight GetFlightByNum(string flightnumber);

        public List<Flight> GetFlightByDate(DateTime date);
        public int GetFlightCount(DateTime date);

        public List<Flight> GetFlightSourceDest(string source, string destination);
    }
}
