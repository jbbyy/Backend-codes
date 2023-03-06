using MongoDbAPI.Models;
using MongoDB.Driver;
namespace MongoDbAPI.Repo
{
    public class ProductRepo : IProductRepo
    {
        private readonly DataContext db;

        public ProductRepo(DataContext db)
        {
            this.db = db;
        }
        public void AddProduct(Product products)
        {
             db.Products.InsertOne(products);
        }

        public void DeleteProduct(int id)
        {
             db.Products.DeleteOne(x => x.id == id);
        }

        public Product GetProduct(int id)
        {

            return db.Products.Find(x => x.id == id).FirstOrDefault();
        }

        public List<Product> GetProducts()
        {
            return db.Products.Find(x => true).ToList();
        }

 

        public void UpdateProduct(int id, Product product)
        {
            var filter = Builders<Product>.Filter.Where(x => x.id == id);
            //creating filter for query, condition
            var update = Builders<Product>.Update.Set(x => x.Name, product.Name)
            .Set(x => x.Brand, product.Brand)
            .Set(x => x.Price, product.Price)
            .Set(x => x.Quantity, product.Quantity);

            db.Products.UpdateOne(filter, update);
        }
    }
}
