using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TESTER.Data;
using TESTER.Models;

namespace TESTER.Controllers
{
    public class GetQuoteController : Controller
    {
        public static List<GetQuote> patients = new List<GetQuote>();

        private readonly ApplicationDbContext dbContext;

        public GetQuoteController(ApplicationDbContext dBD)
        {
            dbContext = dBD;
        }

       
        public IActionResult Success()
        {
            return View();
        }
        public IActionResult Index()
        {
            IEnumerable<GetQuote> objList = dbContext.getquote;
            return View(objList);
        }



        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(GetQuote getquote)
        {
            if (ModelState.IsValid)
            {
                dbContext.getquote.Add(getquote);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(getquote);



        }


        public IActionResult Update(int? ID)
        {
            if (ID == null || ID == 0)
            {
                return NotFound();
            }
            var obj = dbContext.getquote.Find(ID);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);

        }

        //POST-Update updating the current data we have 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(GetQuote getquote)
        {
            dbContext.getquote.Update(getquote);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? ID)
        {
            var obj = dbContext.getquote.Find(ID);
            if (obj == null)
            {
                return NotFound();
            }

            dbContext.getquote.Remove(obj);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Search(string searchTerm)
        {
            var items = await dbContext.getquote
                .Where(i => i.Name.Contains(searchTerm) || i.ID.Contains(searchTerm))
                .ToListAsync();

            return View(items);
        }

    }
}
