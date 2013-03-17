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
    public class ProductController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Product/

        public ViewResult Index(string sortOrder)
        {
            ViewBag.ProductNameSortParm = String.IsNullOrEmpty(sortOrder) ? "ProductName desc" : "";
            ViewBag.SerialNumberSortParm = sortOrder == "SerialNumber" ? "SerialNumber desc" : "SerialNumber";
            ViewBag.OfficeIDSortParm = sortOrder == "OfficeID" ? "OfficeID desc" : "OfficeID";
            ViewBag.DateBuyedSortParm = sortOrder == "DateBuyed" ? "DateBuyed desc" : "DateBuyed";
            ViewBag.InputBySortParm = sortOrder == "InputBy" ? "InputBy desc" : "InputBy";
            ViewBag.AcceptBySortParm = sortOrder == "AcceptBy" ? "AcceptBy desc" : "AcceptBy";
            ViewBag.PriceUnitSortParm = sortOrder == "PriceUnit" ? "PriceUnit desc" : "PriceUnit";
            ViewBag.StatusSortParm = sortOrder == "Status" ? "Status desc" : "Status";
            ViewBag.DateExpireMaintenanceSortParm = sortOrder == "DateExpireMaintenance" ? "DateExpireMaintenance desc" : "DateExpireMaintenance";

            var prod = from s in db.Products select s;

            switch (sortOrder)
            {
                case "ProductName desc": prod = prod.OrderByDescending(s => s.ProductName);
                    break;

                case "SerialNumber desc": prod = prod.OrderByDescending(s => s.SerialNumber);
                    break;
                case "SerialNumber": prod = prod.OrderBy(s => s.SerialNumber);
                    break;
                
                case "OfficeID desc": prod = prod.OrderByDescending(s => s.OfficeID);
                    break;
                case "OfficeID": prod = prod.OrderBy(s => s.OfficeID);
                    break;
                
                case "DateBuyed desc": prod = prod.OrderByDescending(s => s.DateBuyed);
                    break;
                case "DateBuyed": prod = prod.OrderBy(s => s.DateBuyed);
                    break;
                
                case "InputBy desc": prod = prod.OrderByDescending(s => s.InputBy);
                    break;
                case "InputBy": prod = prod.OrderBy(s => s.InputBy);
                    break;

                case "AcceptBy desc": prod = prod.OrderByDescending(s => s.AcceptBy);
                    break;
                case "AcceptBy": prod = prod.OrderBy(s => s.AcceptBy);
                    break;

                case "PriceUnit desc": prod = prod.OrderByDescending(s => s.PriceUnit);
                    break;
                case "PriceUnit": prod = prod.OrderBy(s => s.PriceUnit);
                    break;

                case "Status desc": prod = prod.OrderByDescending(s => s.Status);
                    break;
                case "Status": prod = prod.OrderBy(s => s.Status);
                    break;

                case "DateExpireMaintenance desc": prod = prod.OrderByDescending(s => s.DateExpireMaintenance);
                    break;
                case "DateExpireMaintenance": prod = prod.OrderBy(s => s.DateExpireMaintenance);
                    break;

                default: prod = prod.OrderBy(s => s.ProductName);
                    break;
            }

            return View(prod.ToList());
        }

        //
        // GET: /Product/Details/5

        public ViewResult Details(int id)
        {
            Product product = db.Products.Find(id);
            return View(product);
        }

        //
        // GET: /Product/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Product/Create

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(product);
        }
        
        //
        // GET: /Product/Edit/5
 
        public ActionResult Edit(int id)
        {
            Product product = db.Products.Find(id);
            return View(product);
        }

        //
        // POST: /Product/Edit/5

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        //
        // GET: /Product/Delete/5
 
        public ActionResult Delete(int id)
        {
            Product product = db.Products.Find(id);
            return View(product);
        }

        //
        // POST: /Product/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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