using ProductAPI.REPO;
using ProductAPI.Models;

namespace TestProject1 {

    public class Tests
    {

        IProductRepo repo;
        public Tests()
        {
            DatabaseFixture fixture = new DatabaseFixture();
            //directly creating instance of fixture because no dependency injection for testing 
            repo = new ProductRepo(fixture.db);
            repo.AddProduct(new Product { Id = 1, Name = "laptop", Brand = "dell", Quantity = 5, Price = 500 });
            repo.AddProduct(new Product { Id = 1, Name = "computer", Brand = "apple", Quantity = 5, Price = 1500 });
            //seed data to be kept in constructor

        }
    
        //if there is a [Setup] attribute on top of method, it will as a setup method.
        //runs before each test case
        //if add product statement is included below, before each testcase, it will keep adding the same product into the database
        //will result in test cases failing 
        [OneTimeSetUp]
        public void Setup()
        {
            repo.AddProduct(new Product { Id = 1, Name = "laptop", Brand = "dell", Quantity = 5, Price = 500 });
            repo.AddProduct(new Product { Id = 1, Name = "computer", Brand = "apple", Quantity = 5, Price = 1500 });
        }

        [Test, Order(1)]
        //decorate with [test] attribute
        public void GetProductTest()
        {
            var product = repo.GetProduct();
            //GetProduct returns a list of products
            Assert.Greater(product.Count, 0);
            //2 parameters, first should be actual, Second is excepted. Greater than 0
            //if able to get products, count will be greater than 0
            //product.Count will be actual value 

        }

        [Test]
        public void GetproductByIdTest()
        {
            var product = repo.GetProduct(1);
            //pass value of id = 1
            Assert.AreEqual(product.Name, "laptop");

        }

        //able to set order of test running 

        [Test, Order(2)]
        public void AddProductShouldSucceed()
        {
            int res = repo.AddProduct(new Product { Id = 1, Name = "mouse", Brand = "dell", Quantity = 5, Price = 100 });
            //insert 1 so expected 1
            Assert.AreEqual(1, res);

        }

        [Test, Order(3)]
        public void GetProductsShouldReturnList()
        {
            var res = repo.GetProduct();
            Assert.IsAssignableFrom<List<Product>>(res);
            //check if it wll be a list of type product

        }
    }
}