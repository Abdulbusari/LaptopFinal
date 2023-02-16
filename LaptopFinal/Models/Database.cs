using System.Diagnostics.Metrics;

namespace LaptopFinal.Models
{
    public class Database
    {
        public List<Brand> Brands;
        public List<Laptop> Laptops;
        public List<Laptop> results { get; set;}
        public Database()
        {
            results = new List<Laptop>();

            Brand Microsoft = new Brand(1, "Microsoft");
            Brand Apple = new Brand(2, "Apple");
            Brand Dell = new Brand(3, "Dell");


            Laptop Laptop1 = new Laptop("Macbook Air", 1, Apple, 1500, 2022);
            Laptop Laptop2 = new Laptop("Surface Pro", 2, Microsoft, 1000, 2020);
            Laptop Laptop3 = new Laptop("Latitude", 3, Dell, 900, 2021);
            Laptop Laptop4 = new Laptop("Precision", 4, Dell, 4000, 2022);
            Laptop Laptop5 = new Laptop("Macbook Pro", 5, Apple, 1700, 2020);

           
           

            Brands = new List<Brand> 
            {   
                Microsoft,
                Apple,
                Dell
            };

            Laptops = new List<Laptop>
            {
                Laptop1,
                Laptop2,
                Laptop3,
                Laptop4,
                Laptop5
            };

            

        }



    }
}

