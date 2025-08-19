using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TESTER.Data;
using TESTER.Models;

namespace TESTER.Controllers
{
    public class ClaimsController : Controller
    {

        public static List<Claims> claims = new List<Claims>();

        private readonly ApplicationDbContext dbContext;

        public ClaimsController(ApplicationDbContext dBD)
        {
            dbContext = dBD;
        }


        public IActionResult Success()
        {
            return View();
        }
        public IActionResult Index()
        {
            IEnumerable<Claims> objList = dbContext.claims;
            return View(objList);
        }



        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Claims claims)
        {
            if (ModelState.IsValid)
            {
                dbContext.claims.Add(claims);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(claims);



        }


        public IActionResult Update(int? ID)
        {
            if (ID == null || ID == 0)
            {
                return NotFound();
            }
            var obj = dbContext.claims.Find(ID);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);

        }

        //POST-Update updating the current data we have 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Claims claims)
        {
            dbContext.claims.Update(claims);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? ID)
        {
            var obj = dbContext.claims.Find(ID);
            if (obj == null)
            {
                return NotFound();
            }

            dbContext.claims.Remove(obj);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Search(string searchTerm)
        {
            var items = await dbContext.claims
                .Where(i => i.MainMember.Contains(searchTerm) || i.NameOfDeceased.Contains(searchTerm))
                .ToListAsync();

            return View(items);
        }

    }
}
