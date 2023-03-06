using FirstAPI.Model;

namespace FirstAPI.Respo
{
    public interface IProductRepo
    {
        List<Products> GetProducts();
        Products GetProduct(int id);

        int AddProduct (Products product);

        int Updateproduct (int id, Products product);

        int Deleteproduct (int id);

        //use this because we dont wnat to create tight coupling between class and controller.
        //Will use dependency injection to inject inside controller 
    }
}
