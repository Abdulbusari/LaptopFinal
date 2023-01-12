using LaptopFinal.Models;

namespace LaptopFinal.Models
{
    public class PricesModel
    {
        Database database = new Database();
        //public Laptops Laptops { get; set; }
        public List<Laptop> results { get; set; }
        public string Price { get; set; }

        public Laptops Laptops { get; set; }
       

        
        
    }
}
