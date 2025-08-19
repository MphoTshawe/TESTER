using Microsoft.AspNetCore.Mvc;

namespace TESTER.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
