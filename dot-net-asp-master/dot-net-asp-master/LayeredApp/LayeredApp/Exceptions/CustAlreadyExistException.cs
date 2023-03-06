namespace LayeredApp.Exceptions
{
    public class CustAlreadyExistException :Exception //inherit exception class
    {
        public CustAlreadyExistException() { }

        public CustAlreadyExistException(string message) : base(message) { }

    }
}
