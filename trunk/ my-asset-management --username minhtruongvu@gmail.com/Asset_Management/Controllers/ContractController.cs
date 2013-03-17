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

        public ViewResult Index(string sortOrder)
        {
            ViewBag.TitleSortParm = String.IsNullOrEmpty(sortOrder) ? "Title desc" : "";
            ViewBag.ContractNumberSortParm = sortOrder == "ContractNumber" ? "ContractNumber desc" : "ContractNumber";
            ViewBag.DateSignedSortParm = sortOrder == "DateSigned" ? "DateSigned desc" : "DateSigned";
            ViewBag.InputDateSortParm = sortOrder == "InputDate" ? "InputDate desc" : "InputDate";
            ViewBag.SignedBySortParm = sortOrder == "SignedBy" ? "SignedBy desc" : "SignedBy";
            ViewBag.PriceContractSortParm = sortOrder == "PriceContract" ? "PriceContract desc" : "PriceContract";

            var contr = from s in db.Contracts select s;

            switch (sortOrder)
            {
                case "Title desc": contr = contr.OrderByDescending(s => s.Title);
                    break;
                
                case "ContractNumber desc": contr = contr.OrderByDescending(s => s.ContractNumber);
                    break;
                case "ContractNumber": contr = contr.OrderBy(s => s.ContractNumber);
                    break;

                case "DateSigned desc": contr = contr.OrderByDescending(s => s.DateSigned);
                    break;
                case "DateSigned": contr = contr.OrderBy(s => s.DateSigned);
                    break;

                case "InputDate desc": contr = contr.OrderByDescending(s => s.InputDate);
                    break;
                case "InputDate": contr = contr.OrderBy(s => s.InputDate);
                    break;

                case "SignedBy desc": contr = contr.OrderByDescending(s => s.SignedBy);
                    break;
                case "SignedBy": contr = contr.OrderBy(s => s.SignedBy);
                    break;

                case "PriceContract desc": contr = contr.OrderByDescending(s => s.PriceContract);
                    break;
                case "PriceContract": contr = contr.OrderBy(s => s.PriceContract);
                    break;

                default: contr = contr.OrderBy(s => s.Title);
                    break;
            }
            return View(contr.ToList());
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