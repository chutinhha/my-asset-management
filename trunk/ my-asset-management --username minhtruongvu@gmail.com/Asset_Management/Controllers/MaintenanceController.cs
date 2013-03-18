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
    public class MaintenanceController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Maintenance/

        public ViewResult Index(string sortOrder)
        {
            ViewBag.PriceMaintenanceSortParm = String.IsNullOrEmpty(sortOrder) ? "PriceMaintenance desc" : "";
            ViewBag.DateMaintenanceSortParm = sortOrder == "DateMaintenance" ? "DateMaintenance desc" : "DateMaintenance";
            ViewBag.NextDateMaintenanceSortParm = sortOrder == "NextDateMaintenance" ? "NextDateMaintenance desc" : "NextDateMaintenance";

            var maint = from s in db.Maintenances select s;

            switch (sortOrder)
            {
                case "PriceMaintenance desc": maint = maint.OrderByDescending(s => s.PriceMaintenance);
                    break;

                case "DateMaintenance desc": maint = maint.OrderByDescending(s => s.DateMaintenance);
                    break;
                case "DateMaintenance": maint = maint.OrderBy(s => s.DateMaintenance);
                    break;

                case "NextDateMaintenance desc": maint = maint.OrderByDescending(s => s.NextDateMaintenance);
                    break;
                case "NextDateMaintenance": maint = maint.OrderBy(s => s.NextDateMaintenance);
                    break;

                default: maint = maint.OrderBy(s => s.PriceMaintenance);
                    break;            
            }

            return View(maint.ToList());
        }

        //
        // GET: /Maintenance/Details/5

        public ViewResult Details(int id)
        {
            Maintenance maintenance = db.Maintenances.Find(id);
            return View(maintenance);
        }

        //
        // GET: /Maintenance/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Maintenance/Create

        [HttpPost]
        public ActionResult Create(Maintenance maintenance)
        {
            if (ModelState.IsValid)
            {
                db.Maintenances.Add(maintenance);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(maintenance);
        }
        
        //
        // GET: /Maintenance/Edit/5
 
        public ActionResult Edit(int id)
        {
            Maintenance maintenance = db.Maintenances.Find(id);
            return View(maintenance);
        }

        //
        // POST: /Maintenance/Edit/5

        [HttpPost]
        public ActionResult Edit(Maintenance maintenance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maintenance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(maintenance);
        }

        //
        // GET: /Maintenance/Delete/5
 
        public ActionResult Delete(int id)
        {
            Maintenance maintenance = db.Maintenances.Find(id);
            return View(maintenance);
        }

        //
        // POST: /Maintenance/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Maintenance maintenance = db.Maintenances.Find(id);
            db.Maintenances.Remove(maintenance);
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