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

namespace pwlc.Controllers
{
    public class InvoicesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Invoices
        public ActionResult Index()
        {
            return View(db.Invoices.ToList());
            //return View(await db.Items.ToListAsync());
        }

        // GET: Invoices/Details/5
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
                //List<Item> lineItems = new List<Item>();
                //var officeVisit = checkup.VisitType.ToString();
                //switch (officeVisit)
                //{
                //    case "New":
                //        var newVisit = db.AppointmentTypes.Where(a => a.AppointmentTypeID == 1).First();
                //        lineItems.Add("NEWVISIT", newVisit.ApptType.ToString(), newVisit.ApptCharge, 1, null);
                //        break;
                //    case "Checkup":
                //        var checkupVisit = db.AppointmentTypes.Where(a => a.AppointmentTypeID == 2).First();
                //        lineItems.Add("WKLYVISIT", checkupVisit.ApptType.ToString(), checkupVisit.ApptCharge, 1, null);
                //        break;
                //    case "Restart":
                //        var restartVisit = db.AppointmentTypes.Where(a => a.AppointmentTypeID == 3).First();
                //        lineItems.Add("RESTART", restartVisit.ApptType.ToString(), restartVisit.ApptCharge, 1, null);
                //        break;
                //    default:
                //        break;
                //}

                db.Invoices.Add(invoice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(invoice);
        }

        // GET: Invoices/Edit/5
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

        public ActionResult InvoiceAccount(int invId)
        {
            var thisInvoice = db.Invoices.Where(i => i.InvoiceId == invId).First();
            return View(thisInvoice);
        }



        public ActionResult IndexItems()
        {
            var itemIndex = db.Items.Select(i => i).ToList();

            return View(itemIndex);
        }

        public void AddToInvoice(int id, int quantity)
        {
            
        }

        public ActionResult CreateInvoice()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SaveOrder(Invoice In)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext dc = new ApplicationDbContext())
                {
                    Invoice invoice = new Invoice { InvoiceId = In.InvoiceId, InvoiceDate = In.InvoiceDate };
                    foreach (var i in In.Items)
                    {
                        //
                        // i.TotalAmount = 
                        invoice.Items.Add(i);
                    }
                    dc.Invoices.Add(invoice);
                    dc.SaveChanges();
                    status = true;
                }
            }
            else
            {
                status = false;
            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpGet]
        public JsonResult SelectJSON()
        {
            var getItemList = db.Items.ToList();

            List<object> jsonList = new List<object>();
            //foreach (var item in searchList)
            foreach (var item in getItemList)
            {
                jsonList.Add(new
                {
                    Id = item.ItemId,
                    Name = item.ItemName,
                    Price = item.ItemPrice,
                });
            }

            return this.Json(jsonList, JsonRequestBehavior.AllowGet);
        }

        public static SelectList GetDropDownList()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var getItemList = db.Items.ToList();
            SelectList myItemList = new SelectList(getItemList, "Id", "name");
            //ViewBag.itemListName = myItemList;
            return new SelectList(myItemList);
        }

    }
}
