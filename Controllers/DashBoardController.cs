using Microsoft.AspNetCore.Mvc;
using  Microsoft.AspNetCore.Authorization;
using TESTER.Models;
using System.Diagnostics;

namespace TESTER.Controllers
{
    public class DashBoardController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
