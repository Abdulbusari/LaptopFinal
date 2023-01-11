using Microsoft.AspNetCore.Mvc;

namespace LaptopFinal.Controllers
{
    public class BrandsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
