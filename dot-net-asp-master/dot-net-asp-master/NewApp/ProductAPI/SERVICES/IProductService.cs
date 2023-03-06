using ProductAPI.Models;

namespace ProductAPI.SERVICES
{
    public interface IProductService
    {
        
            List<Product> GetProduct();
            Product GetProduct(int id);

            int AddProduct(Product x);

            int DeleteProduct(int id);

            int UpdateProduct(int id, Product x);

        
    }
}
