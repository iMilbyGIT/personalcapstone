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
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Employees
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users.Where(c => c.Id == userId).FirstOrDefault();
            var employee = db.Employees.Where(c => c.ApplicationId == userId).FirstOrDefault();
            return View(employee);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int id)
        {
            var employee = db.Employees.Where(a => a.EmployeeId == id).FirstOrDefault();
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            Employee employee = new Employee();
            return View(employee);
        }

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                employee.ApplicationId = userId;
                var foundEmployee = db.Users.Where(e => e.Id == employee.ApplicationId).FirstOrDefault();
                employee.Email = foundEmployee.Email;
                db.Employees.Add(employee);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [Authorize(Roles = "Employee")]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                employee.ApplicationId = userId;
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: Employees/Delete/5
        [Authorize(Roles = "Employee")]
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Employee employee)
        {
            try
            {
                var foundEmployee = db.Employees.Find(id);
                db.Employees.Remove(foundEmployee);
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
