using Microsoft.AspNetCore.Mvc;

namespace TESTER.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
