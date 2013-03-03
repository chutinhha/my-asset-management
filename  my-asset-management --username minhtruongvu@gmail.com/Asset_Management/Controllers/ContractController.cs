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
    public class ContractController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Contract/

        public ViewResult Index()
        {
            return View(db.Contracts.ToList());
        }

        //
        // GET: /Contract/Details/5

        public ViewResult Details(int id)
        {
            Contract contract = db.Contracts.Find(id);
            return View(contract);
        }

        //
        // GET: /Contract/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Contract/Create

        [HttpPost]
        public ActionResult Create(Contract contract)
        {
            if (ModelState.IsValid)
            {
                db.Contracts.Add(contract);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(contract);
        }
        
        //
        // GET: /Contract/Edit/5
 
        public ActionResult Edit(int id)
        {
            Contract contract = db.Contracts.Find(id);
            return View(contract);
        }

        //
        // POST: /Contract/Edit/5

        [HttpPost]
        public ActionResult Edit(Contract contract)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contract).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contract);
        }

        //
        // GET: /Contract/Delete/5
 
        public ActionResult Delete(int id)
        {
            Contract contract = db.Contracts.Find(id);
            return View(contract);
        }

        //
        // POST: /Contract/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Contract contract = db.Contracts.Find(id);
            db.Contracts.Remove(contract);
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