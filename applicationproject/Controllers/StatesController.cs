using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using applicationproject.Models;
using PagedList;
using PagedList.Mvc;

namespace applicationproject.Controllers
{
    public class StatesController : Controller
    {
        private StatesContext db = new StatesContext();

        //
        // GET: /States/
        [Authorize(Roles = "admin")]
        public ActionResult Index(string search, int? page)
        {
            var viewModel = (from o in db.States.Where(x => x.name.Contains(search) || search == null) join o2 in db.Country on o.countryId equals o2.countryId select new StateViewModel { States = o, Country = o2 }).ToList().ToPagedList(page ?? 1, 3);
            return View(viewModel);
        }

        //
        // GET: /States/Details/5
        [Authorize(Roles = "admin")]
        public ActionResult Details(int id = 0)
        {
            States states = db.States.Find(id);
            if (states == null)
            {
                return HttpNotFound();
            }
            return View(states);
        }

        //
        // GET: /States/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            ViewBag.countryId = new SelectList(db.Country, "countryId", "name");
            return View();
        }

        //
        // POST: /States/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Create(States states)
        {
            if (ModelState.IsValid)
            {
                db.States.Add(states);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(states);
        }

        //
        // GET: /States/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id = 0)
        {
            States states = db.States.Find(id);
            ViewBag.countryId = new SelectList(db.Country, "countryId", "name",states.countryId);
            if (states == null)
            {
                return HttpNotFound();
            }
            return View(states);
        }

        //
        // POST: /States/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(States states)
        {
            if (ModelState.IsValid)
            {
                db.Entry(states).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(states);
        }

        //
        // GET: /States/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id = 0)
        {
            States states = db.States.Find(id);
            if (states == null)
            {
                return HttpNotFound();
            }
            return View(states);
        }

        //
        // POST: /States/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            States states = db.States.Find(id);
            db.States.Remove(states);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}