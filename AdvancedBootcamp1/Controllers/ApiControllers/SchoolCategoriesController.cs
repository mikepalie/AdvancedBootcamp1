using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AdvancedBootcamp1.Models;
using AdvancedBootcamp1.MyDatabase;

namespace AdvancedBootcamp1.Controllers.ApiControllers
{
    public class SchoolCategoriesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/SchoolCategories
        public IQueryable<SchoolCategory> GetSchoolCategories()
        {
          
            return db.SchoolCategories;
        }

        // GET: api/SchoolCategories/5
        [ResponseType(typeof(SchoolCategory))]
        public IHttpActionResult GetSchoolCategory(int id)
        {
            SchoolCategory schoolCategory = db.SchoolCategories.Find(id);
            if (schoolCategory == null)
            {
                return NotFound();
            }

            return Ok(schoolCategory);
        }

        // PUT: api/SchoolCategories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSchoolCategory(int id, SchoolCategory schoolCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != schoolCategory.SchoolCategoryId)
            {
                return BadRequest();
            }

            db.Entry(schoolCategory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchoolCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/SchoolCategories
        [ResponseType(typeof(SchoolCategory))]
        public IHttpActionResult PostSchoolCategory(SchoolCategory schoolCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SchoolCategories.Add(schoolCategory);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = schoolCategory.SchoolCategoryId }, schoolCategory);
        }

        // DELETE: api/SchoolCategories/5
        [ResponseType(typeof(SchoolCategory))]
        public IHttpActionResult DeleteSchoolCategory(int id)
        {
            SchoolCategory schoolCategory = db.SchoolCategories.Find(id);
            if (schoolCategory == null)
            {
                return NotFound();
            }

            db.SchoolCategories.Remove(schoolCategory);
            db.SaveChanges();

            return Ok(schoolCategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SchoolCategoryExists(int id)
        {
            return db.SchoolCategories.Count(e => e.SchoolCategoryId == id) > 0;
        }
    }
}