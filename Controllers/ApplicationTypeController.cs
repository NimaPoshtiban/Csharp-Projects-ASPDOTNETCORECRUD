using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rocky.Data;
using Rocky.Models;

namespace Rocky.Controllers
{
    public class ApplicationTypeController : Controller
    {
        private readonly ApplicationDbContext _db;
        // getting data from DI Container
        public ApplicationTypeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<ApplicationType> objList = _db.ApplicationTypes;
            return View(objList);
        }
        // GET - CREATE
        public IActionResult Create()
        {
            return View();
        }
        // POST - CREATE
        // Preventing ForgeryToken
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationType obj)
        {
            if (ModelState.IsValid)
            {
                _db.ApplicationTypes.Add(obj);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }

        // GET - EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.ApplicationTypes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        // POST - EDIT
        // preventForgeryToken
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicationType obj)
        {
            if (ModelState.IsValid)
            {
                _db.ApplicationTypes.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }
        // GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.ApplicationTypes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        // POST - DELETE
        // preventForgeryToken
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.ApplicationTypes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.ApplicationTypes.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
