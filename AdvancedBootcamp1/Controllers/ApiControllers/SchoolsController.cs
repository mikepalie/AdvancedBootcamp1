﻿using System;
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
using AdvancedBootcamp1.Models.Dtos;
using AdvancedBootcamp1.MyDatabase;

namespace AdvancedBootcamp1.Controllers.ApiControllers
{
    public class SchoolsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Schools
        public IHttpActionResult GetSchools()
        {
            var schools = db.Schools.Include(x => x.SchoolCategory).Include(x => x.Departments)
                .Select(x => new
                {
                    x.SchoolId,
                    x.Name,
                    x.Description,
                    Departments = x.Departments.Select(y=>new { y.Name, y.DepartmentId }),
                    SchoolCategory = new { x.SchoolCategory.Name, x.SchoolCategory.SchoolCategoryId}
                });



            return Json(new {data = schools });
        }

        // GET: api/Schools/5
        [ResponseType(typeof(School))]
        public IHttpActionResult GetSchool(int id)
        {
            School school = db.Schools.Find(id);
            if (school == null)
            {
                return NotFound();
            }

            return Ok(school);
        }

        // PUT: api/Schools/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSchool(int id, School school)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != school.SchoolId)
            {
                return BadRequest();
            }

            db.Entry(school).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchoolExists(id))
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

        // POST: api/Schools
        [ResponseType(typeof(SchoolDTO))]
        public IHttpActionResult PostSchool(SchoolDTO schoolDTO)
        {
            //Mapping
            School school = new School();

            school.Name = schoolDTO.Name;
            school.Description = schoolDTO.Description;
            school.SchoolCategoryId = schoolDTO.CatId;

            List<Department> departments = new List<Department>();
            foreach (var id in schoolDTO.DepsId)
            {
               var dep = db.Departments.Find(id);
                departments.Add(dep);
            }

            school.Departments = departments;

            db.Entry(school).State = EntityState.Added;
            db.SaveChanges();

            return Json(schoolDTO);
        }

        // DELETE: api/Schools/5
        [ResponseType(typeof(School))]
        public IHttpActionResult DeleteSchool(int id)
        {
            var school = db.Schools
                       .Where(s => s.SchoolId == id)
                       .Include(s => s.Departments)
                       .FirstOrDefault();

            //school.Departments = null;
            if (school == null)
            {
                return NotFound();
            }

            db.Schools.Remove(school);
            db.SaveChanges();

            return Ok(school);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SchoolExists(int id)
        {
            return db.Schools.Count(e => e.SchoolId == id) > 0;
        }
    }
}