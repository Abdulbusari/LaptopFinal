using LaptopFinal.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaptopFinal.Controllers
{
    public class BrandsController : Controller
    {
        Database database = new Database();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Brand()
        {
            return View(new PricesModel());
        }


        [HttpPost]
        public IActionResult Brand(PricesModel pricesModel)
        {
            pricesModel.results = database.Laptops.Where(x => (
            x.Brand.Name.Replace(" ", string.Empty) == pricesModel.Brands.ToString()
            )).ToList();

            switch (pricesModel.Ordering)
            {
                case "Price Ascending":
                    pricesModel.results = pricesModel.results.OrderBy(x => x.Price).ToList();
                    break;
                case "Price Descending":
                    pricesModel.results = pricesModel.results.OrderByDescending(x => x.Price).ToList();
                    break;
                case "Year Ascending":
                    pricesModel.results = pricesModel.results.OrderBy(x => x.Year).ToList();
                    break;
                case "Year Descending":
                    pricesModel.results = pricesModel.results.OrderByDescending(x => x.Year).ToList();
                    break;
            }

            

            if (!string.IsNullOrWhiteSpace(pricesModel.filterString))
            {
                if(pricesModel.filterType == "Price")
                {
                    if (pricesModel.filterString.Contains("<"))
                    {
                        pricesModel.filterString = pricesModel.filterString.Replace('<', ' ');
                        pricesModel.results = pricesModel.results.Where(s => s.Price <= int.Parse(pricesModel.filterString)).ToList();
                    }
                    else if (pricesModel.filterString.Contains(">"))
                    {
                        pricesModel.filterString = pricesModel.filterString.Replace('>', ' ');
                        pricesModel.results = pricesModel.results.Where(s => s.Price >= int.Parse(pricesModel.filterString)).ToList();
                    }
                    else if (pricesModel.filterString.Contains("-"))
                    {
                        pricesModel.filterString = pricesModel.filterString.Replace('-', ' ');
                        List<string> prices = pricesModel.filterString.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                        pricesModel.results = pricesModel.results.Where(s => s.Price >= int.Parse(prices[0]) && s.Price <= int.Parse(prices[1])).ToList();
                    }
                } 
                else if (pricesModel.filterType == "Year")
                {
                    if (pricesModel.filterString.Contains("<"))
                    {
                        pricesModel.filterString = pricesModel.filterString.Replace('<', ' ');
                        pricesModel.results = pricesModel.results.Where(s => s.Year <= int.Parse(pricesModel.filterString)).ToList();
                    }
                    else if (pricesModel.filterString.Contains(">"))
                    {
                        pricesModel.filterString = pricesModel.filterString.Replace('>', ' ');
                        pricesModel.results = pricesModel.results.Where(s => s.Year >= int.Parse(pricesModel.filterString)).ToList();
                    }
                    else if (pricesModel.filterString.Contains("-"))
                    {
                        pricesModel.filterString = pricesModel.filterString.Replace('-', ' ');
                        List<string> prices = pricesModel.filterString.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                        pricesModel.results = pricesModel.results.Where(s => s.Year >= int.Parse(prices[0]) && s.Year <= int.Parse(prices[1])).ToList();
                    }
                }

                
            }

            return View(pricesModel);
        }

        public IActionResult NewBrand()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BrandConfirmation(Brand brand)
        {
            

            return View(brand);
        }

        public IActionResult ViewAll()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ViewAll(Dictionary<Brand, List<Laptop>> all)
        {


            return View(all);
        }

    }
}
