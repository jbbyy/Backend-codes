using FlightApp.Model;
using Microsoft.VisualBasic;

namespace FlightApp.Repo
{
    public interface IFlightRepo
    {
        public int AddFlight(Flight flight);
        public int ModifyFlight(Flight flight, string flightnumber);

        public int DeleteFlight(string flightnumber);
        public Flight GetFlightByNum(string flightnumber);

        public List<Flight> GetFlightByDate(DateTime date);
        public int GetFlightCount(DateTime date);

        public List<Flight> GetFlightSourceDest(string source, string destination);
    }
}
