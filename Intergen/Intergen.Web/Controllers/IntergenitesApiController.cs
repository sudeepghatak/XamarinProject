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
using MyIntergenites.Web.Models;

namespace MyIntergenites.Web.Controllers
{
    public class IntergenitesApiController : ApiController
    {
        private MyIntergenitesContext db = new MyIntergenitesContext();

        // GET: api/IntergenitesApi
        public IQueryable<Intergenite> GetIntergenites()
        {
            return db.Intergenites;
        }

        // GET: api/IntergenitesApi/5
        [ResponseType(typeof(Intergenite))]
        public IHttpActionResult GetIntergenite(int id)
        {
            Intergenite Intergenite = db.Intergenites.Find(id);
            if (Intergenite == null)
            {
                return NotFound();
            }

            return Ok(Intergenite);
        }

        // PUT: api/IntergenitesApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIntergenite(int id, Intergenite Intergenite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Intergenite.Id)
            {
                return BadRequest();
            }

            db.Entry(Intergenite).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IntergeniteExists(id))
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

        // POST: api/IntergenitesApi
        [ResponseType(typeof(Intergenite))]
        public IHttpActionResult PostIntergenite(Intergenite Intergenite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Intergenites.Add(Intergenite);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = Intergenite.Id }, Intergenite);
        }

        // DELETE: api/IntergenitesApi/5
        [ResponseType(typeof(Intergenite))]
        public IHttpActionResult DeleteIntergenite(int id)
        {
            Intergenite Intergenite = db.Intergenites.Find(id);
            if (Intergenite == null)
            {
                return NotFound();
            }

            db.Intergenites.Remove(Intergenite);
            db.SaveChanges();

            return Ok(Intergenite);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IntergeniteExists(int id)
        {
            return db.Intergenites.Count(e => e.Id == id) > 0;
        }
    }
}