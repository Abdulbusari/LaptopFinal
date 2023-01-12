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
            return View(new Database());
        }

        [HttpPost]
        public IActionResult MostExpensive(Database db)
        {
           
         db.results = db.Laptops.OrderByDescending(x => x.Price).ToList();
            
           
            return View(db);
        }

        public IActionResult LeastExpensive()
        {
            return View(new Database());
        }

        [HttpPost]
        public IActionResult LeastExpensive(Database db)
        {
            db.Laptops.OrderBy(x => x.Price).ToList();

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

            return View();
        }


    }
}
