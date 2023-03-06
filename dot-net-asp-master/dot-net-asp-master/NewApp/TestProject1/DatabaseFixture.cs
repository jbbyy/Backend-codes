using Microsoft.EntityFrameworkCore;
using ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    internal class DatabaseFixture : IDisposable
    {//inherit IDisposable

        public DataContext db;  //Able to use DataContext from model of proudctAPI 

        public DatabaseFixture()
        {
            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase("ProductDB").Options;
            db = new DataContext(options);
            //passing the options as instance of DataContext is created 
            
        }
        public void Dispose()
        {
            db = null;
        }
    }
}
