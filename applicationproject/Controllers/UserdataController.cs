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
using System.Text.RegularExpressions;

namespace applicationproject.Controllers
{
    [InitializeSimpleMembership]
    public class UserdataController : Controller
    {
        private UserdataContext db = new UserdataContext();

        //
        // GET: /Userdata/

        public ActionResult Index()
        {
            return View(db.Userdata.ToList());
        }

        public ActionResult Test12()
        {
            Response.Write("Hello how are you?");
            var ST = "this <keyword>pattern</keyword> captures all <keyword>outermost</keyword> balanced span <keyword>tags</keyword>, so if we leave a span tag open, <span>it won't be captured";
            Regex RX = new Regex("(((?<open><keyword>)[^<]*)+([^<]*(?<close-open></keyword>))+)+(?(open)(?!))");

            if (RX.IsMatch(ST))
            {
                Response.Write("Match found");
            }
            else
            {
                Response.Write("Match not found");
            }


            //List<string> list = new List<string>();
            //list.Add(1);
            //list.Add(10);
            //list.Add(4);
            //list.Add(0);


            MatchCollection matchList = RX.Matches(ST);

            foreach (Match m in matchList)
            {
                Response.Write("-----");
                Response.Write(m);
                
                Response.Write("-----");
            }

            var list = matchList.Cast<Match>().Select(match => match.Value).ToList();
            
            int size = list.Count;
            for (int i = 0; i < list.Count; i++)
            {
                Response.Write("-----");
                Response.Write(list[i]);
            }
            list.Sort();
            Response.Write("Sorted list values");
            for (int i = 0; i < list.Count; i++)
            {
                Response.Write("-----");
                Response.Write(list[i]);
            }
            //Response.ReadKey();
            const string input = "_::_pagitica";
            Console.WriteLine(input);

            // Call Replace on the string.
            // ... We must assign the result of the Replace call.
            string output = input.Replace("_::_", "Areo");
            Console.WriteLine(output);
            //DirectoryInfo directory = new DirectoryInfo(Server.MapPath(@"~\Content\htmlfiles\"));
            //var files = directory.GetFiles().ToList();
            //return files;
            Response.End();
            return View(db.Userdata.ToList());
        }


        public ActionResult Indexlanguages()
        {
            LanguagesContext dbnew = new LanguagesContext();

            return View(dbnew.Languages.ToList());
        }

        public ActionResult Indexcountry(string languagename = "")
        {
            CountryContext dbnew = new CountryContext();
            ViewBag.languageid = HttpContext.Request.Params.Get("languageid");
            ViewBag.languagename = languagename;
            
            return View(dbnew.Country.ToList());
        }

        public ActionResult Indexstate(int id = 0, string name = "", string languagename = "")
        {
            StatesContext dbnewstate = new StatesContext();
            ViewBag.countryName = name;
            ViewBag.languagename = languagename;
            ViewBag.languageid = HttpContext.Request.Params.Get("languageid");
            ViewBag.countryid = HttpContext.Request.Params.Get("countryid");
            return View(dbnewstate.States.Where(o => o.countryId == id).ToList());
        }

        public ActionResult Indexdistricts(int id = 0, string countryname = "", string statename = "", string languagename = "")
        {
            DistrictsContext dbnewdistritcs = new DistrictsContext();
            ViewBag.countryName = countryname;
            ViewBag.stateName = statename;
            ViewBag.languagename = languagename;
            ViewBag.languageid = HttpContext.Request.Params.Get("languageid");
            ViewBag.countryid = HttpContext.Request.Params.Get("countryid");
            ViewBag.stateid = id;
            return View(dbnewdistritcs.Districts.Where(o => o.stateId == id).ToList());
        }

        public ActionResult Indexcategory(int id = 0, string countryname = "", string statename = "", string districtname = "", string departmentname = "", string languagename = "")
        {
            CategoriesContext dbnewcategory = new CategoriesContext();
            ViewBag.countryName = countryname;
            ViewBag.stateName = statename;
            ViewBag.districtname = districtname;
            ViewBag.departmentname = departmentname;
            ViewBag.languagename = languagename;
            ViewBag.languageid = HttpContext.Request.Params.Get("languageid");
            ViewBag.countryid = HttpContext.Request.Params.Get("countryid");
            ViewBag.stateid = HttpContext.Request.Params.Get("stateid");
            ViewBag.districtid = HttpContext.Request.Params.Get("districtid");
            ViewBag.departmentid = id;
           
            return View(dbnewcategory.Categories.ToList());
        }

        public ActionResult Indexsubcategory(int id = 0, string countryname = "", string statename = "", string districtname = "", string departmentname = "", string categoryname = "", string languagename = "")
        {
            SubcategoriesContext dbnewsubcategory = new SubcategoriesContext();
            ViewBag.countryName = countryname;
            ViewBag.stateName = statename;
            ViewBag.districtname = districtname;
            ViewBag.departmentname = departmentname;
            ViewBag.categoryname = categoryname;
            ViewBag.languagename = languagename;
            ViewBag.languageid = HttpContext.Request.Params.Get("languageid");
            ViewBag.countryid = HttpContext.Request.Params.Get("countryid");
            ViewBag.stateid = HttpContext.Request.Params.Get("stateid");
            ViewBag.districtid = HttpContext.Request.Params.Get("districtid");
            ViewBag.departmentid = HttpContext.Request.Params.Get("departmentid");
            ViewBag.categoryid = id;

            return View(dbnewsubcategory.Subcategories.ToList());
        }

        public ActionResult Indexdepartment(int id = 0, string countryname = "", string statename = "", string districtname = "", string languagename = "")
        {
            DepartmentsContext dbnewdepartments = new DepartmentsContext();
            ViewBag.countryName = countryname;
            ViewBag.stateName = statename;
            ViewBag.districtname = districtname;
            ViewBag.languagename = languagename;
            ViewBag.languageid = HttpContext.Request.Params.Get("languageid");
            ViewBag.countryid = HttpContext.Request.Params.Get("countryid");
            ViewBag.stateid = HttpContext.Request.Params.Get("stateid");
            ViewBag.districtid = id;

            return View(dbnewdepartments.Departments.Where(o => o.districtId == id).ToList());
        }


        public ActionResult Indexdocument(int id = 0, string countryname = "", string statename = "", string districtname = "", string departmentname = "", string categoryname = "", string languagename = "", string subcategoryname = "")
        {
            DocumentrelsContext dbnew = new DocumentrelsContext();
            ViewBag.countryName = countryname;
            ViewBag.stateName = statename;
            ViewBag.districtname = districtname;
            ViewBag.departmentname = departmentname;
            ViewBag.categoryname = categoryname;
            ViewBag.subcategoryname = subcategoryname;
            ViewBag.languagename = languagename;
            var languageid = Int32.Parse(HttpContext.Request.Params.Get("languageid"));
            var countryid = Int32.Parse(HttpContext.Request.Params.Get("countryid"));
            var stateid = Int32.Parse(HttpContext.Request.Params.Get("stateid"));
            var districtid = Int32.Parse(HttpContext.Request.Params.Get("districtid"));
            var departmentid = Int32.Parse(HttpContext.Request.Params.Get("departmentid"));
            var categoryid = Int32.Parse(HttpContext.Request.Params.Get("categoryid"));
            var subcategoryid = id;

            var res = dbnew.Documentrels.Where(o => o.languageId == languageid && o.countryId == countryid && o.stateId == stateid && o.districtId == districtid && o.departmentId == departmentid && o.categoryId == categoryid && o.subcategoryId == subcategoryid).Select( o => o.documentId).ToList();
            DocsContext dbn = new DocsContext();

            var response = dbn.Documents.Where(r => res.Contains(r.documentId)).ToList();
            return View(response);
        }

        //Docselected
        public ActionResult Docselected(int id = 0)
        {
            var path = Server.MapPath(@"~\Content\htmlfiles\");
            path = path + id + ".html";
            string html = System.IO.File.ReadAllText(path);

            return new FilePathResult(path, "text/html");
        }

        //
        // GET: /Userdata/Details/5

        public ActionResult Details(int id = 0)
        {
            Userdata userdata = db.Userdata.Find(id);
            if (userdata == null)
            {
                return HttpNotFound();
            }
            return View(userdata);
        }

        //
        // GET: /Userdata/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Userdata/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Userdata userdata)
        {
            if (ModelState.IsValid)
            {
                userdata.userId = (int)WebSecurity.GetUserId(User.Identity.Name);
                db.Userdata.Add(userdata);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userdata);
        }

        //
        // GET: /Userdata/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Userdata userdata = db.Userdata.Find(id);
            if (userdata == null)
            {
                return HttpNotFound();
            }
            return View(userdata);
        }

        //
        // POST: /Userdata/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Userdata userdata)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userdata).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userdata);
        }

        //
        // GET: /Userdata/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Userdata userdata = db.Userdata.Find(id);
            if (userdata == null)
            {
                return HttpNotFound();
            }
            return View(userdata);
        }

        //
        // POST: /Userdata/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Userdata userdata = db.Userdata.Find(id);
            db.Userdata.Remove(userdata);
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