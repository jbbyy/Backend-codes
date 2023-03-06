using FlightApp.Model ;
using FlightApp.Repo;
using FlightApp.Exceptions;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.VisualBasic;

namespace FlightApp.Services
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepo repo;

        //DI, injecting repo into services
        public FlightService(IFlightRepo repo)
        {
            this.repo = repo;
        }

        //if flight is added, will return a 1 row affected. Hence if it is equal to 0, means no flight was added due to exisiting flight with same flight number 
        public bool AddFlight(Flight flight)
        {
            var x = repo.AddFlight(flight);
            if(x == 0)
            {
                throw new FlightAlreadyExist($"Flight with flight number {flight.FlightNumber} already exist");
            }
            return true;
        }

        //if flight is deleted will return 1 row affected. Hence if it is equal to 0, means no flight was deleted absence of flight with that flight number. 
        public bool DeleteFlight(string flightnumber)
        {
            var x = repo.DeleteFlight(flightnumber);
            if (x == 0)
            {
                throw new NotFoundException($"Unable to deleted flight with flight number :{flightnumber} as it could not be found");
            }
            return true;
        }

        //if list of flight by date empty, throw not found exception
        public List<Flight> GetFlightByDate(DateTime date)
        {
            var x = repo.GetFlightByDate(date);
            if(x == null)
            {
                throw new NotFoundException($"Unable to find flights scheduled on date and time : {date} ");
            }
            return x;
        }

        //if list of flight by flight number is empty, throw not found exception
        public Flight GetFlightByNum(string flightnumber)
        {
            var x = repo.GetFlightByNum(flightnumber);
            if (x == null)
            {
                throw new NotFoundException($"Unable to find flight with flight number : {flightnumber} ");
            }
            return x;
        }

        //if unable to get count, throw not found exception
        public int GetFlightCount(DateTime date)
        {
            var x = repo.GetFlightCount(date);
            if (x == 0)
            {
                throw new NotFoundException($"There are zero flights for date and time :{date} ");
            }
            return x;
        }

        //if list of flight by source and destination is empty, throw not found exception
        public List<Flight> GetFlightSourceDest(string source, string destination)
        {
            var x = repo.GetFlightSourceDest(source, destination);
            if(x == null)
            {
                throw new NotFoundException($"Unable to get flights from {source} to {destination} ");
            }
            return x;
        }

        //if flight is updated will return 1 row affected. Hence if it is equal to 0, means no flight was update due to absence of flight with that flight number. 
        public bool ModifyFlight(Flight flight, string flightnumber)
        {
            var x = repo.ModifyFlight(flight, flightnumber);
            if(x == 0)
            {
                throw new NotFoundException($"Unable to update flight details for flight number: {flightnumber}");
            }
            return true;
        }
    }
}
