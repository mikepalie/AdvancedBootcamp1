using AdvancedBootcamp1.MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.Http;
using AdvancedBootcamp1.Models;




namespace AdvancedBootcamp1.Controllers
{
    public class DevsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Devs
        public ActionResult Index()
        {
           

            return View();
        }

        public ActionResult CatchThem()
        {
            var developers = db.Developers
               .Select(d => new
               {
                   d.DeveloperId,
                   d.Name,
                   d.Salary,
                   d.Birthday,
                   Categories = d.Categories.Select(cat => new
                   {
                       cat.CategoryId,
                       cat.Name
                   })
               }).ToList();
            return Json(new {data = developers },JsonRequestBehavior.AllowGet) ;
        }

        public Object PostDeveloper(Developer developer)
        {


            db.Developers.Add(developer);
            db.SaveChanges();


            return Json(new { data = developer }, JsonRequestBehavior.AllowGet);
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