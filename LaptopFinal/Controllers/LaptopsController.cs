using LaptopFinal.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaptopFinal.Controllers
{
    public class LaptopsController : Controller
    {
        Database database = new Database();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MostExpensive()
        {
            Database db = new Database();
            db.results = db.Laptops.OrderByDescending(x => x.Price).Take(2).ToList();
            return View(db);
        }

       
        public IActionResult LeastExpensive()
        {
            Database db = new Database();
            db.results = db.Laptops.OrderBy(x => x.Price).Take(2).ToList();
            return View(db);
        }

        

        public IActionResult Budget()
        {
            return View(new PricesModel());
        }

        [HttpPost]
        public IActionResult Budget(PricesModel pricesModel)
        {
            pricesModel.results = database.Laptops.ToList();

            if (!string.IsNullOrWhiteSpace(pricesModel.Price))
            {
                if (pricesModel.Price.Contains("<"))
                {
                    pricesModel.Price = pricesModel.Price.Replace('<', ' ');
                    pricesModel.results = pricesModel.results.Where(s => s.Price <= int.Parse(pricesModel.Price)).ToList();
                }
                else if (pricesModel.Price.Contains(">"))
                {
                    pricesModel.Price = pricesModel.Price.Replace('>', ' ');
                    pricesModel.results = pricesModel.results.Where(s => s.Price >= int.Parse(pricesModel.Price)).ToList();
                }
                else if (pricesModel.Price.Contains("-"))
                {
                    pricesModel.Price = pricesModel.Price.Replace('-', ' ');
                    List<string> prices = pricesModel.Price.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                    pricesModel.results = pricesModel.results.Where(s => s.Price >= int.Parse(prices[0]) && s.Price <= int.Parse(prices[1])).ToList();
                }
            }

            return View(pricesModel);
        }

        public IActionResult Compare()
        {
            return View(new PricesModel());
        }

        [HttpPost]
        public IActionResult Compare(PricesModel prices)
        {
            prices.results = database.Laptops.Where(x => (
            x.Model.Replace(" ", string.Empty) == prices.laptopA.ToString()
            || x.Model.Replace(" ", string.Empty) == prices.laptopB.ToString()))
            .Take(2).
            OrderByDescending(x => (x.Model.Replace(" ", string.Empty) == prices.laptopA.ToString()))
            .ToList();
           
            return View(prices);
        }

        public IActionResult Brand()
        {
            return View(new PricesModel());
        }


        [HttpPost]
        public IActionResult Brand(PricesModel prices)
        {
            prices.results = database.Laptops.Where(x => (
            x.Brand.Replace(" ", string.Empty) == prices.Brands.ToString()
            )).ToList();

            return View(prices);
        }


    }
}
