using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbAPI.Models
{
    public class Product
    {
        //no concept of primary key, but have a property of _id which is unique.
        //to map this id to _id in mongoDB have to use this attribute 
        [BsonId]
        public int id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }   

        public int Quantity { get; set; }


        public int Price { get; set; }
    }
}
