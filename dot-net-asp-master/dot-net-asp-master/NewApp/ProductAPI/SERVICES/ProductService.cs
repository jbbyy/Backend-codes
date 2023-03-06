using ProductAPI.Models;
using ProductAPI.REPO;

namespace ProductAPI.SERVICES
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo repo;
        public ProductService(IProductRepo repo)
        {
            this.repo = repo;
        }
        public int AddProduct(Product x)
        {
            var p = repo.GetProduct(x.Id);
            if (p == null)
            {
                repo.AddProduct(x);

            }
            else throw new Exception(); // already exist exception
        }

        public int DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProduct()
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public int UpdateProduct(int id, Product x)
        {
            throw new NotImplementedException();
        }
    }
}
