using AdvancedBootcamp1.Models;
using AdvancedBootcamp1.MyDatabase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdvancedBootcamp1.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Mas dinei tin selida poy tha probaloume tous Employees oxi tous employees!!
        public ActionResult Index()
        {
            return View();
        }

        //1 - HTTPGET (tha mas dinei dedomena)

        [HttpGet]
        public ActionResult GetEmployees()
        {
            return Json(db.Employees.ToList(),JsonRequestBehavior.AllowGet); 
        }

        //2 - HTTPPOST (tha kanoyme create dedomena)

        [HttpPost]
        public ActionResult CreateEmployee(Employee employee)
        {
            db.Entry(employee).State = EntityState.Added;
            db.SaveChanges();

            return Json(new { message = "Employee Created" }, JsonRequestBehavior.AllowGet);
        }


        //3 - HTTPPUT (tha kanoyme edit dedomena)


        [HttpPut]
        public ActionResult EditEmployee(Employee employee)
        {
            var emp = db.Employees.Find(employee.EmployeeId);
            if(emp == null)
            {
                return Json(new { message = "Not Found" }, JsonRequestBehavior.AllowGet);
            }
            emp.Name = employee.Name;

            db.Entry(emp).State = EntityState.Modified;
            db.SaveChanges();

            return Json(new { message = "Employee Modified" }, JsonRequestBehavior.AllowGet);
        }

        //2 - HTTPDELETE(tha kanoyme delete dedomena)

        [HttpDelete]
        public ActionResult DeleteEmployee(int? id)
        {
            var emp = db.Employees.Find(id);
            if (emp == null)
            {
                return Json(new { message = "Not Found" }, JsonRequestBehavior.AllowGet);
            }

            db.Entry(emp).State = EntityState.Deleted;
            db.SaveChanges();

            return Json(new { message = "Employee Deleted" }, JsonRequestBehavior.AllowGet);
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