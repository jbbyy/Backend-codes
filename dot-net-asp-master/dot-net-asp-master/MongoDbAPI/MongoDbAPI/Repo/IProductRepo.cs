using MongoDbAPI.Models;
namespace MongoDbAPI.Repo
{
    public interface IProductRepo
    {
       void AddProduct(Product products);

        List<Product> GetProducts();

        Product GetProduct(int id);

       void DeleteProduct(int id);

       void UpdateProduct(int id, Product product);


    }
}
