using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Web.Security;
using WebMatrix.WebData;
using System.Transactions;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;

using applicationproject.Filters;
using applicationproject.Models;

using PagedList;
using PagedList.Mvc;


namespace applicationproject.Controllers
{
    [InitializeSimpleMembership]
    public class DocsmController : Controller
    {
        private DocsContext db = new DocsContext();

        //
        // GET: /Docsm/

        public ActionResult Index(string search, int? page)
        {
            var viewModel = (from o in db.Documents.Where(x => x.name.Contains(search) || search == null) join o2 in db.Documentrels on o.documentId equals o2.documentId join o3 in db.Languages on o2.languageId equals o3.languageId join o4 in db.Categories on o2.categoryId equals o4.categoryId join o5 in db.Subcategories on o2.subcategoryId equals o5.subcategoryId join o6 in db.Country on o2.countryId equals o6.countryId join o7 in db.States on o2.stateId equals o7.stateId join o8 in db.Districts on o2.districtId equals o8.districtId join o9 in db.Departments on o2.departmentId equals o9.departmentId select new Docsandrel { Docs = o, Documentrels = o2, Languages = o3, Categories = o4, Subcategories = o5, Country = o6, States = o7, Districts = o8, Departments = o9 }).ToList().ToPagedList(page ?? 1, 3); ;
            return View(viewModel);
            //return View(db.Documents.ToList());
        }


        public ActionResult Test()
        {
          /*  var result = "";

            var firstName = "aaa";// Request["FirstName"];
            var lastName = "bbb";// Request["LastName"];
            var email = "cccc";// Request["Email"];

        var userData = firstName + "," + lastName +
            "," + email + Environment.NewLine;

        var dataFile = Server.MapPath("~/App_Data/data.txt");
        File.WriteAllText(@dataFile, userData);
        result = "Information saved.";
            
            return Content("Hi there!");*/
            return View();
        }

        //
        // GET: /Docsm/Details/5

        public ActionResult Details(int id = 0)
        {
            Docs docs = db.Documents.Find(id);
            if (docs == null)
            {
                return HttpNotFound();
            }
            return View(docs);
        }

        //
        // GET: /Docsm/Create

        public ActionResult Create()
        {
            ViewBag.pageContentData = "nothing";
            ViewBag.countryId = new SelectList(db.Country, "countryId", "name");
            ViewBag.categoryId = new SelectList(db.Categories, "categoryId", "name");
            ViewBag.languageId = new SelectList(db.Languages, "languageId", "name");
            
            List<SelectListItem> states = new List<SelectListItem>();
            states.Add(new SelectListItem { Text = "Select State", Value = "0" });
            ViewBag.stateId = new SelectList(states, "Value", "Text");
            
            List<SelectListItem> districts = new List<SelectListItem>();
            districts.Add(new SelectListItem { Text = "Select Districts", Value = "0" });
            ViewBag.districtId = new SelectList(districts, "Value", "Text");
            
            List<SelectListItem> departments = new List<SelectListItem>();
            departments.Add(new SelectListItem { Text = "Select Departments", Value = "0" });
            ViewBag.departmentId = new SelectList(departments, "Value", "Text");

            List<SelectListItem> subcategories = new List<SelectListItem>();
            subcategories.Add(new SelectListItem { Text = "Select Subcategories", Value = "0" });
            ViewBag.subcategoryId = new SelectList(subcategories, "Value", "Text");

            
            return View();
        }

        //
        // POST: /Docsm/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Docviewmodel docs)
        {
            ViewBag.pageContentData = "nothing";
            if (ModelState.IsValid)
            {
                var path = "nothing";
                var filename = "nothing";
                if (docs.file != null && docs.file.ContentLength > 0)
                {
                    filename = Path.GetFileName(docs.file.FileName);
                    path = Path.Combine(Server.MapPath("~/Content/htmlfiles/"), filename);
                    docs.file.SaveAs(path);
                }
                Docs documentsnew = new Docs();

                documentsnew.name = docs.name;
                documentsnew.config = docs.config;
                documentsnew.comments = docs.comments;
                documentsnew.filepath = path;
                db.Documents.Add(documentsnew);
                db.SaveChanges();

                Documentrels docrel = new Documentrels();
                docrel.documentId = documentsnew.documentId;
                docrel.countryId = docs.countryId;
                docrel.stateId = docs.stateId;
                docrel.departmentId = docs.departmentId;
                docrel.districtId = docs.districtId;
                docrel.userId = (int)WebSecurity.GetUserId(User.Identity.Name);
                docrel.subcategoryId = docs.subcategoryId;
                docrel.categoryId = docs.categoryId;
                docrel.languageId = docs.languageId;
                docrel.fileId = 9878;
                docrel.filename = filename;

                db.Documentrels.Add(docrel);
               
/*
                DocumentrelsContext dbnew = new DocumentrelsContext();
                //string sql = "INSERT INTO Documentrels(documentId,countryId,stateId,districtId,departmentId,userId,subcategoryId,languageId,fileId) VALUES(@P0,@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9)";
                string sql = "INSERT INTO Documentrels(documentId,countryId,stateId,districtId,departmentId,userId,subcategoryId,languageId,fileId,filename) VALUES(@P0,@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9)";
                //string sql = "INSERT INTO Documentrels(documentId,countryId,stateId,districtId,departmentId,userId,subcategoryId,languageId,fileId) VALUES(23,34,52,63,74,85,96,87,78)";
List<object> parameterList = new List<object>();

parameterList.Add(77);
parameterList.Add(22);
parameterList.Add(55);
parameterList.Add(66);
parameterList.Add(88);
parameterList.Add(99);
parameterList.Add(333);
parameterList.Add(1111);
parameterList.Add(33333);
parameterList.Add("DSSDS");
object[] parameters = parameterList.ToArray();
int result = dbnew.Database.ExecuteSqlCommand(sql, parameters);
               // int result = dbnew.Database.ExecuteSqlCommand(sql);
                */
                db.SaveChanges();
                ViewBag.docId = documentsnew.documentId;
                ViewBag.pageContentData = docs.pageContent;           

                //return RedirectToAction("Index");
            }

            return View(docs);
        }


        public JsonResult GetStates(int id)
        {
            var data = db.States.Where(o => o.countryId == id).ToList();
            var states = new SelectList(data, "stateId", "name");

            return Json(states);
        }

        public JsonResult GetDistricts(int id)
        {
            var data = db.Districts.Where(o => o.stateId == id).ToList();
            var districts = new SelectList(data, "districtId", "name");

            return Json(districts);
        }

        public JsonResult GetDepartments(int id)
        {
            var data = db.Departments.Where(o => o.districtId == id).ToList();
            var departments = new SelectList(data, "departmentId", "name");

            return Json(departments);
        }

        public JsonResult GetSubcategories(int id)
        {
            var data = db.Subcategories.Where(o => o.categoryId == id).ToList();
            var subcategories = new SelectList(data, "subcategoryId", "name");

            return Json(subcategories);
        }

        //
        // GET: /Docsm/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Docs docs = db.Documents.Find(id);
            if (docs == null)
            {
                return HttpNotFound();
            }
            return View(docs);
        }

        //
        // POST: /Docsm/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Docs docs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(docs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(docs);
        }

        //
        // GET: /Docsm/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Docs docs = db.Documents.Find(id);
            if (docs == null)
            {
                return HttpNotFound();
            }
            return View(docs);
        }

        //
        // POST: /Docsm/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Docs docs = db.Documents.Find(id);
            db.Documents.Remove(docs);
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