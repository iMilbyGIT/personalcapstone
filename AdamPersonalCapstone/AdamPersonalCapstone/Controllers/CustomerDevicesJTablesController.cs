using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdamPersonalCapstone.Models;

namespace AdamPersonalCapstone.Controllers
{
    public class CustomerDevicesJTablesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CustomerDevicesJTables
        public ActionResult Index()
        {
            var customerDevices = db.CustomerDevices.Include(c => c.Customer).Include(c => c.Device);
            return View(customerDevices.ToList());
        }

        // GET: CustomerDevicesJTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerDevicesJTable customerDevicesJTable = db.CustomerDevices.Find(id);
            if (customerDevicesJTable == null)
            {
                return HttpNotFound();
            }
            return View(customerDevicesJTable);
        }

        // GET: CustomerDevicesJTables/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "ApplicationId");
            ViewBag.DevicesId = new SelectList(db.Devices, "DevicesId", "Brand");
            return View();
        }

        // POST: CustomerDevicesJTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerDevicesJTableId,DevicesId,CustomerId")] CustomerDevicesJTable customerDevicesJTable)
        {
            if (ModelState.IsValid)
            {
                db.CustomerDevices.Add(customerDevicesJTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "ApplicationId", customerDevicesJTable.CustomerId);
            ViewBag.DevicesId = new SelectList(db.Devices, "DevicesId", "Brand", customerDevicesJTable.DevicesId);
            return View(customerDevicesJTable);
        }

        // GET: CustomerDevicesJTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerDevicesJTable customerDevicesJTable = db.CustomerDevices.Find(id);
            if (customerDevicesJTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "ApplicationId", customerDevicesJTable.CustomerId);
            ViewBag.DevicesId = new SelectList(db.Devices, "DevicesId", "Brand", customerDevicesJTable.DevicesId);
            return View(customerDevicesJTable);
        }

        // POST: CustomerDevicesJTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerDevicesJTableId,DevicesId,CustomerId")] CustomerDevicesJTable customerDevicesJTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerDevicesJTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "ApplicationId", customerDevicesJTable.CustomerId);
            ViewBag.DevicesId = new SelectList(db.Devices, "DevicesId", "Brand", customerDevicesJTable.DevicesId);
            return View(customerDevicesJTable);
        }

        // GET: CustomerDevicesJTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerDevicesJTable customerDevicesJTable = db.CustomerDevices.Find(id);
            if (customerDevicesJTable == null)
            {
                return HttpNotFound();
            }
            return View(customerDevicesJTable);
        }

        // POST: CustomerDevicesJTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerDevicesJTable customerDevicesJTable = db.CustomerDevices.Find(id);
            db.CustomerDevices.Remove(customerDevicesJTable);
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
    }
}
