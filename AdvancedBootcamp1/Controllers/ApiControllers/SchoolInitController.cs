using AdvancedBootcamp1.MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdvancedBootcamp1.Controllers.ApiControllers
{
    public class SchoolInitController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public object GetData()
        {
            var obj = new {
                Departments = db.Departments.Select(x => new {x.DepartmentId,x.Name}),
                SchoolCategories = db.SchoolCategories.Select(x=> new { x.SchoolCategoryId, x.Name })
            };

            return Json(obj);
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
