using MongoDB.Driver; 
    namespace MongoDbAPI.Models
{
    public class DataContext
    {
        MongoClient client;
        IMongoDatabase db;
        //2 reference variables

        //constructor
        public DataContext()
        {
            client = new MongoClient("mongodb://localhost:27017");
            //by default on our system, mongodb runs on port number 27017. Address of the server
            //cybershop (name of db) -> able to take any name 
            db = client.GetDatabase("CyberShop");
        }

        public IMongoCollection<Product> Products => db.GetCollection<Product>("ProductDetails");
        //Product is the name of the model , "ProductDetails" will be the name of the table created 
        //mapping product model with ProductDetails in MongoD

    }
}
