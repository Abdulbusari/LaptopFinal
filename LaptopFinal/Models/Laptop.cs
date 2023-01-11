namespace LaptopFinal.Models
{
    public class Laptop
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }
        public int Year { get; set; }

        public Laptop(string model, int id, string brand, int price, int year)
        {
            Model = model;
            Id = id;
            Brand = brand;
            Price = price;
            Year = year;
        }
    }
}
