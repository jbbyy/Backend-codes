namespace LayeredApp.Exceptions
{
    public class CustNotFoundException :Exception
    {
        public CustNotFoundException () { }
        public CustNotFoundException(string message) : base(message) { }

    }
}
