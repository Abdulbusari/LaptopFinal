using LaptopFinal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LaptopFinal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        private readonly LaptopVendorDbContext _dbContext;

        public HomeController(LaptopVendorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Laptop laptop)
        {
            _dbContext.Laptops.Add(laptop);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var laptop = _dbContext.Laptops.FirstOrDefault(l => l.Id == id);

            if (laptop == null)
            {
                return NotFound();
            }

            return View(laptop);
        }

        [HttpPost]
        public IActionResult Edit(Laptop laptop)
        {
            var existingLaptop = _dbContext.Laptops.FirstOrDefault(l => l.Id == laptop.Id);

            if (existingLaptop == null)
            {
                return NotFound();
            }

            existingLaptop.Brand = laptop.Brand;
            existingLaptop.Model = laptop.Model;
            existingLaptop.Price = laptop.Price;
            existingLaptop.Year = laptop.Year;

            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var laptop = _dbContext.Laptops.FirstOrDefault(l => l.Id == id);

            if (laptop == null)
            {
                return NotFound();
            }

            return View(laptop);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var laptop = _dbContext.Laptops.FirstOrDefault(l => l.Id == id);

            if (laptop == null)
            {
                return NotFound();
            }

            _dbContext.Laptops.Remove(laptop);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}