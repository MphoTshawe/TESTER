using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TESTER.Data;
using TESTER.Models;

namespace TESTER.Controllers
{
    public class BeneficiariesController : Controller
    {

        public static List<Beneficiaries> beneficiaries = new List<Beneficiaries>();

        private readonly ApplicationDbContext dbContext;

        public BeneficiariesController(ApplicationDbContext dBD)
        {
            dbContext = dBD;
        }


        public IActionResult Index()
        {
            IEnumerable<Beneficiaries> objList = dbContext.beneficiaries;
            return View(objList);
        }
        public IActionResult Create()
        {

            var model = new Beneficiaries();
            model.RelatedPersons = new List<RelatedPersonViewModel>();
            for (int i = 0; i < 1; i++)
            {
                model.RelatedPersons.Add(new RelatedPersonViewModel());
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Beneficiaries beneficiaries)
        {
           


            if (ModelState.IsValid)
            {
                dbContext.beneficiaries.Add(beneficiaries);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(beneficiaries);



        }


        public IActionResult Update(int? ID)
        {
            if (ID == null || ID == 0)
            {
                return NotFound();
            }
            var obj = dbContext.beneficiaries.Find(ID);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);

        }

        //POST-Update updating the current data we have 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Beneficiaries beneficiaries)
        {
            dbContext.beneficiaries.Update(beneficiaries);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? ID)
        {
            var obj = dbContext.beneficiaries.Find(ID);
            if (obj == null)
            {
                return NotFound();
            }

            dbContext.beneficiaries.Remove(obj);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Search(string searchTerm)
        {
            var items = await dbContext.beneficiaries
                .Where(i => i.FirstNames.Contains(searchTerm) || i.IDNumber.Contains(searchTerm))
                .ToListAsync();

            return View(items);
        }
    }
}
