using AdamPersonalCapstone.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AdamPersonalCapstone.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Owners
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users.Where(c => c.Id == userId).FirstOrDefault();
            var customer = db.Customers.Where(c => c.ApplicationId == userId).FirstOrDefault();
            return View(customer);
        }

        public ActionResult CreateOwnedDeviceList()
        {
            return View();
        }

        // GET: Owners/Details/5
        public ActionResult Details(int id)
        {
            var customerDetails = db.Customers.Where(a => a.CustomerId == id).FirstOrDefault();
            return View(customerDetails);
        }

        // GET: Owners/Create
        public ActionResult Create()
        {
            Customer customer = new Customer();
            return View(customer);
        }

        // POST: Owners/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                customer.ApplicationId = userId;
                var foundCustomer = db.Users.Where(e => e.Id == customer.ApplicationId).FirstOrDefault();
                customer.Email = foundCustomer.Email;
                db.Customers.Add(customer);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Owners/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Owners/Edit/5
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                customer.ApplicationId = userId;
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: Owners/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Owners/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Customer customer)
        {
            try
            {
                var foundCustomer = db.Customers.Find(id);
                db.Customers.Remove(foundCustomer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
