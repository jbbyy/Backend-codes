using FlightApp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Runtime.CompilerServices;

namespace FlightApp.Repo
{
    public class FlightRepo : IFlightRepo
        //inherit IFlightRepo
    {

        //Dependency injection of DataCOntext into Flightrepo
        private readonly DataContext db;

        public FlightRepo(DataContext db)
        {
            this.db = db;
        }

        //this method adds a new flight to the database
          public int AddFlight(Flight flight)
        {
           db.Flights.Add(flight);
           return db.SaveChanges();
        }

        //This method will delete flight with specific flight number from the database
        public int DeleteFlight(string flightnumber)
        {
            var y = db.Flights.Find(flightnumber);
            db.Flights.Remove(y);
            return db.SaveChanges();
        }

        public List<Flight> GetFlightByDate(DateTime date)
        {
            var y = db.Flights.Where(x => x.FlightDateTime == date).ToList();
            
            return y;
        }
        //This method is getting details of flights of specific flight number from the database
        public Flight GetFlightByNum(string flightnumber)
        {

            var y = db.Flights.Find(flightnumber);
            return y;
        }
        //This method is getting the count of flights that depart on a specific date and time from the database
        public int GetFlightCount(DateTime date)
        {
            var y = db.Flights.Where(x => x.FlightDateTime == date).ToList().Count();
            return y;
        }

        //this method is getting flights by both source and destination from the database
        public List<Flight> GetFlightSourceDest(string source, string destination)
        {
            var y = db.Flights.Where(x => x.FlightSource == source && x.FlightDestination == destination).ToList();
            return y;
        }

        //This method modifies flight details in the database
        public int ModifyFlight(Flight flights, string flightnumber)
        {
            var x = db.Flights.Find(flightnumber);
            x.FlightSource = flights.FlightSource;
            x.FlightDateTime = flights.FlightDateTime;
            x.FlightDestination = flights.FlightDestination;
            db.Entry<Flight>(x).State = EntityState.Modified;
            return db.SaveChanges();
        }
    }
}
