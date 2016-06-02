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
    public class SubcategoriesController : Controller
    {
        private SubcategoriesContext db = new SubcategoriesContext();

        //
        // GET: /Subcategories/
        [Authorize(Roles = "admin")]
        public ActionResult Index(string search, int? page)
        {
            var viewModel = (from o in db.Subcategories.Where(x => x.name.Contains(search) || search == null) join o2 in db.Categories on o.categoryId equals o2.categoryId select new CategorySubcategoryViewModel { Subcategories = o, Categories = o2 }).ToList().ToPagedList(page ?? 1, 3); ;
            return View(viewModel);
        }

        //
        // GET: /Subcategories/Details/5
        [Authorize(Roles = "admin")]
        public ActionResult Details(int id = 0)
        {
            Subcategories subcategories = db.Subcategories.Find(id);
            if (subcategories == null)
            {
                return HttpNotFound();
            }
            return View(subcategories);
        }

        //
        // GET: /Subcategories/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            ViewBag.categoryId = new SelectList(db.Categories, "categoryId", "name");
            return View();
        }

        //
        // POST: /Subcategories/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Create(Subcategories subcategories)
        {
            if (ModelState.IsValid)
            {
                db.Subcategories.Add(subcategories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subcategories);
        }

        //
        // GET: /Subcategories/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id = 0)
        {
            Subcategories subcategories = db.Subcategories.Find(id);
            ViewBag.categoryId = new SelectList(db.Categories, "categoryId", "name", subcategories.categoryId);

            if (subcategories == null)
            {
                return HttpNotFound();
            }
            return View(subcategories);
        }

        //
        // POST: /Subcategories/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(Subcategories subcategories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subcategories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subcategories);
        }

        //
        // GET: /Subcategories/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id = 0)
        {
            Subcategories subcategories = db.Subcategories.Find(id);
            if (subcategories == null)
            {
                return HttpNotFound();
            }
            return View(subcategories);
        }

        //
        // POST: /Subcategories/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Subcategories subcategories = db.Subcategories.Find(id);
            db.Subcategories.Remove(subcategories);
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