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
    public class DistrictsController : Controller
    {
        private DistrictsContext db = new DistrictsContext();

        //
        // GET: /Districts/
        [Authorize(Roles = "admin")]
        public ActionResult Index(string search, int? page)
        {
            var viewModel = (from o in db.Districts.Where(x => x.name.Contains(search) || search == null) join o2 in db.States on o.stateId equals o2.stateId select new StateDisctrictViewModel { Districts = o, States = o2 }).ToList().ToPagedList(page ?? 1, 3); ;
            return View(viewModel);
        }

        //
        // GET: /Districts/Details/5
        [Authorize(Roles = "admin")]
        public ActionResult Details(int id = 0)
        {
            Districts districts = db.Districts.Find(id);
            if (districts == null)
            {
                return HttpNotFound();
            }
            return View(districts);
        }

        //
        // GET: /Districts/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            ViewBag.stateId = new SelectList(db.States, "stateId", "name");
            return View();
        }

        //
        // POST: /Districts/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Create(Districts districts)
        {
            if (ModelState.IsValid)
            {
                db.Districts.Add(districts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(districts);
        }

        //
        // GET: /Districts/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id = 0)
        {
            Districts districts = db.Districts.Find(id);
            ViewBag.stateId = new SelectList(db.States, "stateId", "name",districts.stateId);
            if (districts == null)
            {
                return HttpNotFound();
            }
            return View(districts);
        }

        //
        // POST: /Districts/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(Districts districts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(districts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(districts);
        }

        //
        // GET: /Districts/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id = 0)
        {
            Districts districts = db.Districts.Find(id);
            if (districts == null)
            {
                return HttpNotFound();
            }
            return View(districts);
        }

        //
        // POST: /Districts/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Districts districts = db.Districts.Find(id);
            db.Districts.Remove(districts);
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