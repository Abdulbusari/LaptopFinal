using LaptopFinal.Models;


namespace LaptopFinal.Models
{
    public class PricesModel
    {
        Database database = new Database();
        //public Laptops Laptops { get; set; }
        
        public List<Laptop> results { get; set; }
        public Brands Brands { get; set; }
        //change this to "filter string" and fix all errors
        public string filterString { get; set; }
        public string Ordering { get; set; }
        public string filterType { get; set; }

        public Laptops Laptops { get; set; }

        public Laptops laptopA { get; set; }
        public Laptops laptopB { get; set; }
       

        
        
    }
}
