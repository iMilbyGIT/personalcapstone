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
    public class OwnersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Owners
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users.Where(c => c.Id == userId).FirstOrDefault();
            var owner = db.Owners.Where(c => c.ApplicationId == userId).FirstOrDefault();
            return View(owner);
        }

        // GET: Owners/Details/5
        public ActionResult Details(int id)
        {
            var owner = db.Owners.Where(a => a.OwnerId == id).FirstOrDefault();
            return View(owner);
        }

        // GET: Owners/Create
        public ActionResult Create()
        {
            Owner owner = new Owner();
            return View(owner);
        }

        // POST: Owners/Create
        [HttpPost]
        public ActionResult Create(Owner owner)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                owner.ApplicationId = userId;
                var foundOwner = db.Users.Where(e => e.Id == owner.ApplicationId).FirstOrDefault();
                owner.Email = foundOwner.Email;
                db.Owners.Add(owner);
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
            var owner = db.Owners.Find(id);
            if (owner == null)
            {
                return HttpNotFound();
            }
            return View(owner);
        }

        // POST: Owners/Edit/5
        [HttpPost]
        [Authorize(Roles = "Owner")]
        public ActionResult Edit(Owner owner)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                owner.ApplicationId = userId;
                db.Entry(owner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: Owners/Delete/5
        [Authorize(Roles = "Owner")]
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var owner = db.Owners.Find(id);
            if (owner == null)
            {
                return HttpNotFound();
            }
            return View(owner);
        }

        // POST: Owners/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Owner owner)
        {
            try
            {
                var foundOwner = db.Owners.Find(id);
                db.Owners.Remove(foundOwner);
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
