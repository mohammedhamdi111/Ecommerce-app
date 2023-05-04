using Microsoft.AspNetCore.Mvc;

namespace EcommerceApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
