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
    public class NamesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Names
        public IEnumerable<Name> GetNames()
        {
            return db.Names.ToList();
        }

        // GET: api/Names/5
        [ResponseType(typeof(Name))]
        public IHttpActionResult GetName(int id)
        {
            Name name = db.Names.Find(id);
            if (name == null)
            {
                return NotFound();
            }

            return Ok(name);
        }

        // PUT: api/Names/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutName(int id, Name name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != name.Id)
            {
                return BadRequest();
            }

            db.Entry(name).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NameExists(id))
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

        // POST: api/Names
        [ResponseType(typeof(Name))]
        public IHttpActionResult PostName(Name name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Names.Add(name);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = name.Id }, name);
        }

        // DELETE: api/Names/5
        [ResponseType(typeof(Name))]
        public IHttpActionResult DeleteName(int id)
        {
            Name name = db.Names.Find(id);
            if (name == null)
            {
                return NotFound();
            }

            db.Names.Remove(name);
            db.SaveChanges();

            return Ok(name);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NameExists(int id)
        {
            return db.Names.Count(e => e.Id == id) > 0;
        }
    }
}