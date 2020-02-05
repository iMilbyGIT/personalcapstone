using AdamPersonalCapstone.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

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
        public ActionResult Payment()
        {
            ViewBag.PayPal = PrivateKeys.paypalURL;
            return View();
        }
        public ActionResult Map()
        {
            ViewBag.MapUrl = PrivateKeys.googleMap;
            return View();
        }
        public ActionResult CreateTicket()
        {
            var userID = User.Identity.GetUserId();
            var customer = db.Customers.Where(c => c.ApplicationId == userID).FirstOrDefault();
            return RedirectToAction("Create", "Ticket", customer);
        }
        public ActionResult OwnedDevices()
        {
            return View();
        }

        [ChildActionOnly]
        public void MapClick()
        {
            const string accountSid = PrivateKeys.twilioAccountSid;
            const string authToken = PrivateKeys.twilioToken;
            TwilioClient.Init(accountSid, authToken);
            var message = MessageResource.Create(
            body: "There is a local customer in need of Nerd assistance! Please log into NeighborNerd to address the request.",
            from: new Twilio.Types.PhoneNumber("+17867890420"),
            to: new Twilio.Types.PhoneNumber("+16084210953")
            );
            Console.WriteLine(message.Sid);
        }

        // GET: Owners/Details/5
        public ActionResult Details(int id)
        {
            var customer = db.Customers.Where(a => a.CustomerId == id).FirstOrDefault();
            return View(customer);
        }

        // GET: Owners/Create
        public ActionResult Create()
        {
            Customer customer = new Customer();
            return View(customer);
        }

        // POST: Owners/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
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
        [Authorize(Roles = "Customer")]
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
        [Authorize(Roles = "Customer")]
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
        [Authorize(Roles = "Customer")]
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
        [Authorize(Roles = "Customer")]
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
