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
    public class DepartmentsController : Controller
    {
        private DepartmentsContext db = new DepartmentsContext();

        //
        // GET: /Departments/
        [Authorize(Roles = "admin")]
        public ActionResult Index(string search, int? page)
        {
            var viewModel = (from o in db.Departments.Where(x => x.name.Contains(search) || search == null) join o2 in db.Districts on o.districtId equals o2.districtId select new DepartmentDistrictViewModel { Departments = o, Districts = o2 }).ToList().ToPagedList(page ?? 1, 3); ;
            
            
            return View(viewModel);
        }

        //
        // GET: /Departments/Details/5
        [Authorize(Roles = "admin")]
        public ActionResult Details(int id = 0)
        {
            Departments departments = db.Departments.Find(id);
            if (departments == null)
            {
                return HttpNotFound();
            }
            return View(departments);
        }

        //
        // GET: /Departments/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            ViewBag.districtId = new SelectList(db.Districts, "districtId", "name");
            return View();
        }

        //
        // POST: /Departments/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Create(Departments departments)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(departments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(departments);
        }

        //
        // GET: /Departments/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id = 0)
        {
            Departments departments = db.Departments.Find(id);
            ViewBag.districtId = new SelectList(db.Districts, "districtId", "name", departments.districtId);
            if (departments == null)
            {
                return HttpNotFound();
            }
            return View(departments);
        }

        //
        // POST: /Departments/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(Departments departments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(departments);
        }

        //
        // GET: /Departments/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id = 0)
        {
            Departments departments = db.Departments.Find(id);
            if (departments == null)
            {
                return HttpNotFound();
            }
            return View(departments);
        }

        //
        // POST: /Departments/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Departments departments = db.Departments.Find(id);
            db.Departments.Remove(departments);
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