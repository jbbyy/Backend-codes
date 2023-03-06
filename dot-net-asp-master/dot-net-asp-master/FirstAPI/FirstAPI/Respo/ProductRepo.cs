using FirstAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Respo
{
    public class ProductRepo : IProductRepo
    {
        private readonly DataContext db;

        public ProductRepo(DataContext db)
        {
            this.db = db;
            //dependency injection
        }
        public int AddProduct(Products product)
        {
            db.Products.Add(product);
            return db.SaveChanges();
            //returns number of records affected 
        }

        public int Deleteproduct(int id)
        {
            var p = db.Products.Where(x => x.Id == id).FirstOrDefault();
            if(p != null) 
            {
                //if p exisit, remove it
                db.Products.Remove(p); 
                return db.SaveChanges();
            }
            return 0;
        }

        public Products GetProduct(int id)
        {
            return db.Products.Where(x => x.Id == id).FirstOrDefault();
            //if found will return it, if not found will return Null
          
        }

        public List<Products> GetProducts()
        {
            return db.Products.ToList();
            //return all the products
        }

        public int Updateproduct(int id, Products product)
        {
            var p = db.Products.Where(x => x.Id == id).FirstOrDefault();
            if (p != null)
            {
                p.Name = product.Name;
                p.Price = product.Price;
                p.Brand = product.Brand;
                p.Quantity = product.Quantity;

                db.Entry<Products>(p).State = EntityState.Modified;
                //p object of type product 
                //This indicates that the Entity Framework should treat this database entry as modified
                //and update it in the database when changes are saved to the context.
                return db.SaveChanges();
            }
            return 0;
        }
    }
}
//need to call these methods in controller
