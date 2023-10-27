using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdvancedBootcamp1.Models;
using AdvancedBootcamp1.Models.Dtos;
using AdvancedBootcamp1.MyDatabase;

namespace AdvancedBootcamp1.Controllers
{
    public class UniversityController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpPost]
        public ActionResult SaveUni(   UniversityDto universityDto         )
        {
            //Mapping                           --AutoMapper
            University u1 = new University();
            u1.Name = universityDto.Name;
            u1.Country = universityDto.Country;
            u1.Province = universityDto.Province;
            u1.Alpha_two_code = universityDto.Alpha_two_code;

            u1.Domains = new List<Domain>();

            foreach (var str in universityDto.Domains)
            {
                Domain d = new Domain() { Name = str };
                u1.Domains.Add(d);
            }

            u1.WebPages = new List<WebPage>();

            foreach (var str in universityDto.WebPages)
            {
                WebPage w = new WebPage() { Name = str };
                u1.WebPages.Add(w);
            }

            db.Entry(u1).State = EntityState.Added;
            db.SaveChanges();


            return Json(new { status = "All data saved to database" });
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
