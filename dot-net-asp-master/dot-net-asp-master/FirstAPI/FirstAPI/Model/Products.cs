using System.ComponentModel.DataAnnotations.Schema;

namespace FirstAPI.Model
{
    public class Products
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)] //int ID will not be indentity -> running order, able to specify ourselves
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }

        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
