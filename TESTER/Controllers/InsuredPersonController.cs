using Microsoft.AspNetCore.Mvc;
using TESTER.Models;
using TESTER.Data;
using TESTER.ViewModels;
using System.Collections.Generic;

namespace TESTER.Controllers
{

    public class InsuredPersonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InsuredPersonController(ApplicationDbContext context)
        {
            _context = context;
        }


        private static int _nextId = 1;


        [HttpGet]
        public IActionResult Create()
        {
            var model = new InsuredFormViewModel();
            for (int i = 0; i < 13; i++)
            {
                model.InsuredPersons.Add(new InsuredPerson());
            }
            return View(model);
        }



        [HttpPost]
        [HttpPost]
        [HttpPost]
        public IActionResult Create(InsuredFormViewModel form)
        {
            var validEntries = form.InsuredPersons
                .Where(p => !string.IsNullOrWhiteSpace(p.FirstNames) && !string.IsNullOrWhiteSpace(p.Surname))
                .ToList();

            foreach (var person in validEntries)
            {
                person.MainMemberId = form.MainMemberId;
                _context.insuredPerson.Add(person);
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }




        public IActionResult Index()
        {
            var allPersons = _context.insuredPerson.ToList();
            return View(allPersons);
        }



        [HttpGet]
        public IActionResult Update(int id)
        {
            var person = _context.insuredPerson.FirstOrDefault(p => p.Id == id);
            if (person == null) return NotFound();
            return View(person);
        }

        [HttpPost]
        public IActionResult Update(InsuredPerson updated)
        {
            var person = _context.insuredPerson.FirstOrDefault(p => p.Id == updated.Id);
            if (person == null) return NotFound();

            person.MainMemberId = updated.MainMemberId;
            person.RelationshipToPrincipalMember = updated.RelationshipToPrincipalMember;
            person.FirstNames = updated.FirstNames;
            person.Surname = updated.Surname;
            person.DateOfBirth = updated.DateOfBirth;
            person.IdNumber = updated.IdNumber;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }



        [HttpPost]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var person = _context.insuredPerson.FirstOrDefault(p => p.Id == id);
            if (person != null)
            {
                _context.insuredPerson.Remove(person);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Search(string mainMemberId)
        {
            if (string.IsNullOrWhiteSpace(mainMemberId))
            {
                // Return all records if no search term
                var allPersons = _context.insuredPerson.ToList();
                ViewBag.MainMemberId = null;
                return View("Search", allPersons);
            }

            // Use ToLower() for SQL-compatible case-insensitive comparison
            var results = _context.insuredPerson
                .Where(p => !string.IsNullOrEmpty(p.MainMemberId) &&
                            p.MainMemberId.ToLower() == mainMemberId.ToLower())
                .ToList();

            ViewBag.MainMemberId = mainMemberId;
            return View("Search", results);
        }


    }



}

