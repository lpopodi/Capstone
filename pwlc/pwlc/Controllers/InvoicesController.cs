using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using pwlc.Models;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;

namespace pwlc.Controllers
{
    public class InvoicesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly object price;

        public IEnumerable Items { get; private set; }

        // GET: Invoices
        [Authorize(Roles = "Admin,Employee,Manager,Doctor")]
        public ActionResult Index()
        {
            return View(db.Invoices.ToList());
            //return View(await db.Items.ToListAsync());
        }

        // GET: Invoices/Details/5
        [Authorize(Roles = "Admin,Employee,Manager,Doctor")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // GET: Invoices/Create
        [Authorize(Roles = "Admin,Employee,Manager,Doctor")]
        public ActionResult Create(int cid)
        {
            Checkup checkup = db.Checkups.Find(cid);
            Patient patient = db.Patients.Where(p => p.PatientId == checkup.Patient.PatientId).First();
            Invoice invoice = new Invoice();
            invoice.Patient = patient;
           
            return View(invoice);
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Invoice invoice, Checkup checkup, Patient patient, Item item)
        {
            if (ModelState.IsValid)
            {
                invoice.InvoiceDate = DateTime.Now;
                patient.Invoices.Add(invoice);
                db.Invoices.Add(invoice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(invoice);
        }

        // GET: Invoices/Edit/5
        [Authorize(Roles = "Admin,Employee,Manager,Doctor")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InvoiceId,InvoiceDate")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(invoice);
        }

        // GET: Invoices/Delete/5
        [Authorize(Roles = "Admin,Employee,Manager,Doctor")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Invoice invoice = db.Invoices.Find(id);
            db.Invoices.Remove(invoice);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult CreateInvoice()
        {
            var itemList = db.Items.Select(m => new SelectListItem { Value = m.ItemId, Text = m.ItemName });

            return View(itemList);
        }

        public JsonResult getItems()
        {
            List<Item> items = new List<Item>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                items = db.Items.OrderBy(a => a.ItemName).ToList();
            }
            return new JsonResult { Data = items, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


        public JsonResult getPrices(int itemID)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var price = db.Items.Where(a => a.ItemId.Equals(itemID)).Select(p => p.ItemPrice);
            }
            return new JsonResult { Data = price, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


        [HttpPost]
        public JsonResult save(Invoice invoice)
        {
            bool status = false;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Invoices.Add(invoice);
                db.SaveChanges();
                status = true;
            }

            return new JsonResult { Data = new { status = status } };
        }

        //[HttpPost]
        //public JsonResult save(OrderMaster order)
        //{
        //    bool status = false;
        //    DateTime dateOrg;
        //    var isValidDate = DateTime.TryParseExact(order.OrderDateString, "mm-dd-yyyy", null, System.Globalization.DateTimeStyles.None, out dateOrg);
        //    if (isValidDate)
        //    {
        //        order.OrderDate = dateOrg;
        //    }

        //    var isValidModel = TryUpdateModel(order);
        //    if (isValidModel)
        //    {
        //        using (MyDatabaseEntities dc = new MyDatabaseEntities())
        //        {
        //            dc.OrderMasters.Add(order);
        //            dc.SaveChanges();
        //            status = true;
        //        }
        //    }
        //    return new JsonResult { Data = new { status = status } };
        //}

    }
}
