using Microsoft.AspNetCore.Mvc;

namespace TESTER.Controllers
{
    public class PlansController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
