using AdamPersonalCapstone.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace AdamPersonalCapstone.Controllers
{
    public class RatingController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        Employee employee;
        Customer customer;
        public ActionResult eRate(int rating, string id)
        {
            employee = db.Employees.Where(c => c.ApplicationId == id).SingleOrDefault();
            employee.employeeRating += rating;
            employee.rateCount += 1;
            employee.averageRate = (employee.employeeRating / employee.rateCount);
            db.Entry(employee).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
        // GET: Rating
        public ActionResult Index()
        {
            return View();
        }
    }
}