using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdamPersonalCapstone.Models;
using Microsoft.AspNet.Identity;

namespace AdamPersonalCapstone.Controllers
{
    public class TicketsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tickets
        public ActionResult Index()
        {
            var tickets = db.Tickets.Include(t => t.Customer).Include(t => t.Device).Include(t => t.Employee);
            return View(tickets.ToList());
        }
        public ActionResult CreateTicket(int id)
        {
            var cuserId = User.Identity.GetUserId();
            var customer = db.Customers.Where(c => c.ApplicationId == cuserId).FirstOrDefault();
            Ticket ticket = new Ticket();
            ticket.DeviceId = id;
            ticket.CustomerId = customer.CustomerId;
            db.Tickets.Add(ticket);
            db.SaveChanges();
            return View();
        }
        public ActionResult Claim()
        {
            var eUserId = User.Identity.GetUserId();
            var currentEmployee = db.Employees.Where(e => e.ApplicationId == eUserId).FirstOrDefault();
            var employeeTickets = db.Tickets.Where(t => t.EmployeeId == currentEmployee.EmployeeId);
            return View(employeeTickets);
        }
        public ActionResult Complete()
        {
            var eUserId = User.Identity.GetUserId();
            var currentEmployee = db.Employees.Where(e => e.ApplicationId == eUserId).FirstOrDefault();
            var employeeTickets = db.Tickets.Where(t => t.EmployeeId == currentEmployee.EmployeeId);
            return View(employeeTickets);
        }

        public ActionResult Pending()
        {
            var tickets = db.Tickets.Include(t => t.Customer).Include(t => t.Device).Include(t => t.Employee);
            return View(tickets.ToList());
        }
        // GET: Tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: Tickets/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "ApplicationId");
            ViewBag.DeviceId = new SelectList(db.Devices, "DevicesId", "Name");
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "ApplicationId");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TicketId,EmployeeId,CustomerId,DeviceId,MessageSent,MessageReceived,Subject,Message")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                var cuserId = User.Identity.GetUserId();
                var customer = db.Customers.Where(c => c.ApplicationId == cuserId).FirstOrDefault();
                ticket.CustomerId = customer.CustomerId;
                db.Tickets.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "ApplicationId", ticket.CustomerId);
            ViewBag.DeviceId = new SelectList(db.Devices, "DevicesId", "Name", ticket.DeviceId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "ApplicationId", ticket.EmployeeId);
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "ApplicationId", ticket.CustomerId);
            ViewBag.DeviceId = new SelectList(db.Devices, "DevicesId", "Brand", ticket.DeviceId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "ApplicationId", ticket.EmployeeId);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TicketId,EmployeeId,CustomerId,DeviceId,MessageSent,MessageReceived,Subject,Message")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "ApplicationId", ticket.CustomerId);
            ViewBag.DeviceId = new SelectList(db.Devices, "DevicesId", "Brand", ticket.DeviceId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "ApplicationId", ticket.EmployeeId);
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = db.Tickets.Find(id);
            db.Tickets.Remove(ticket);
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
