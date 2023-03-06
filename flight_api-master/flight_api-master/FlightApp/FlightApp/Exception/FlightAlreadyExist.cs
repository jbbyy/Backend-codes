namespace FlightApp.Exceptions
{
    public class FlightAlreadyExist :Exception
    {
        public FlightAlreadyExist() { }
        public FlightAlreadyExist(string message) : base(message) { }   
    }
}

