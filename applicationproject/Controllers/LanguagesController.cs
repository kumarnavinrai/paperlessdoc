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
    public class LanguagesController : Controller
    {
        private LanguagesContext db = new LanguagesContext();

        //
        // GET: /Languages/
        [Authorize(Roles = "admin")]
        public ActionResult Index(string search, int? page)
        {
           return View(db.Languages.Where(x => x.name.Contains(search) || search == null).ToList().ToPagedList(page ?? 1, 3));

        }

        //
        // GET: /Languages/Details/5
        [Authorize(Roles = "admin")]
        public ActionResult Details(int id = 0)
        {
            Languages languages = db.Languages.Find(id);
            if (languages == null)
            {
                return HttpNotFound();
            }
            return View(languages);
        }

        //
        // GET: /Languages/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Languages/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Create(Languages languages)
        {
            if (ModelState.IsValid)
            {
                db.Languages.Add(languages);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(languages);
        }

        //
        // GET: /Languages/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id = 0)
        {
            Languages languages = db.Languages.Find(id);
            if (languages == null)
            {
                return HttpNotFound();
            }
            return View(languages);
        }

        //
        // POST: /Languages/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(Languages languages)
        {
            if (ModelState.IsValid)
            {
                db.Entry(languages).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(languages);
        }

        //
        // GET: /Languages/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id = 0)
        {
            Languages languages = db.Languages.Find(id);
            if (languages == null)
            {
                return HttpNotFound();
            }
            return View(languages);
        }

        //
        // POST: /Languages/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Languages languages = db.Languages.Find(id);
            db.Languages.Remove(languages);
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