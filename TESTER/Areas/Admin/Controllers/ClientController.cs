using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
using TESTER.Data;
using TESTER.Models;

namespace TESTER.Areas.Admin.Controllers
{
        [Area("Admin")]
        [Authorize(Roles = "Admin")]
        public class ClientController : Controller
        {
            private readonly ApplicationDbContext _context;

            // Let dependency injection supply the context
            public ClientController(ApplicationDbContext context)
            {
                _context = context;
            }

            public ActionResult Index()
            {
                var clients = _context.Clients.ToList();
                return View(clients);
            }

            public ActionResult Create()
            {
                return View();
            }

            [HttpPost]
            public ActionResult Create(Client client)
            {
                if (ModelState.IsValid)
                {
                    _context.Clients.Add(client);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(client);
            }

            public ActionResult Edit(int id)
            {
                var client = _context.Clients.Find(id);
                return View(client);
            }

            [HttpPost]
            public ActionResult Edit(Client client)
            {
                if (ModelState.IsValid)
                {
                    _context.Entry(client).State = EntityState.Modified;
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(client);
            }

            public ActionResult Delete(int id)
            {
                var client = _context.Clients.Find(id);
                return View(client);
            }

            [HttpPost, ActionName("Delete")]
            public ActionResult DeleteConfirmed(int id)
            {
                var client = _context.Clients.Find(id);
                _context.Clients.Remove(client);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

}

