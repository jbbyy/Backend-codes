using ProductAPI.Models;

namespace ProductAPI.REPO
{
    public class ProductRepo : IProductRepo
    {
        private readonly DataContext db;

        public ProductRepo(DataContext db)
        {
            this.db = db;
        }
        public int AddProduct(Product x)
        {
            db.Products.Add(x);
            return db.SaveChanges();
        }

        public int DeleteProduct(int id)
        {
            var p = db.Products.Where(x=>x.Id == id).FirstOrDefault();
            db.Products.Remove(p);
            return db.SaveChanges();
        }

        public List<Product> GetProduct()
        {
            return db.Products.ToList();
        }

        public Product GetProduct(int id)
        {
            var p = db.Products.Where(x => x.Id == id).FirstOrDefault();
            return p;
        }

        public int UpdateProduct(int id, Product x)
        {
            var p = db.Products.Where(x => x.Id == id).FirstOrDefault();
            p.Id = x.Id;
            p.Name = x.Name;
            p.Brand = x.Brand;
            p.Price = x.Price;
            p.Quantity = x.Quantity;


        }
    }
}
