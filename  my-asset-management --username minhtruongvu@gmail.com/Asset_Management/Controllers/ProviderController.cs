using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Asset_Management.Models;
using Asset_Management.DAL;

namespace Asset_Management.Controllers
{ 
    public class ProviderController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Provider/

        public ViewResult Index(string SortOrder, string searchstring)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(SortOrder) ? "ProviderName desc" : "";
            ViewBag.AdressSortParm = SortOrder == "Address" ? "Address desc" : "Address";
            ViewBag.PhoneSortParm = SortOrder == "Phone" ? "Phone desc" : "Phone";
            ViewBag.ManagerSortParm = SortOrder == "Manager" ? "Manager desc" : "Manager";

            var prov = from s in db.Providers select s;
//            var item = from s in db.Providers select s;

            switch (SortOrder)
            {
                case "ProviderName desc": prov = prov.OrderByDescending(s => s.ProviderName);
                    break;

                case "Address desc": prov = prov.OrderByDescending(s => s.Address);
                    break;
                case "Address": prov = prov.OrderBy(s => s.Address);
                    break;

                case "Phone desc": prov = prov.OrderByDescending(s => s.Phone);
                    break;
                case "Phone": prov = prov.OrderBy(s => s.Phone);
                    break;

                case "Manager desc": prov = prov.OrderByDescending(s => s.Manager);
                    break;
                case "Manager": prov = prov.OrderBy(s => s.Manager);
                    break;

                default : prov = prov.OrderBy(s => s.ProviderName);
                    break;
            }

            if (!String.IsNullOrEmpty(searchstring))
            { 
            
            }

            return View(prov.ToList());
        }

        //
        // GET: /Provider/Details/5

        public ViewResult Details(int id)
        {
            Provider provider = db.Providers.Find(id);
            return View(provider);
        }

        //
        // GET: /Provider/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Provider/Create

        [HttpPost]
        public ActionResult Create(Provider provider)
        {
            if (ModelState.IsValid)
            {
                db.Providers.Add(provider);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(provider);
        }
        
        //
        // GET: /Provider/Edit/5
 
        public ActionResult Edit(int id)
        {
            Provider provider = db.Providers.Find(id);
            return View(provider);
        }

        //
        // POST: /Provider/Edit/5

        [HttpPost]
        public ActionResult Edit(Provider provider)
        {
            if (ModelState.IsValid)
            {
                db.Entry(provider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(provider);
        }

        //
        // GET: /Provider/Delete/5
 
        public ActionResult Delete(int id)
        {
            Provider provider = db.Providers.Find(id);
            return View(provider);
        }

        //
        // POST: /Provider/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Provider provider = db.Providers.Find(id);
            db.Providers.Remove(provider);
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