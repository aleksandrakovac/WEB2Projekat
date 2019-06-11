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
using WebApp.Models;
using WebApp.Persistence;

namespace WebApp.Controllers
{
    public class TimetableTypesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/TimetableTypes
        public IQueryable<TimetableType> GetTimetableType()
        {
            return db.TimetableType;
        }

        // GET: api/TimetableTypes/5
        [ResponseType(typeof(TimetableType))]
        public IHttpActionResult GetTimetableType(int id)
        {
            TimetableType timetableType = db.TimetableType.Find(id);
            if (timetableType == null)
            {
                return NotFound();
            }

            return Ok(timetableType);
        }

        // PUT: api/TimetableTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTimetableType(int id, TimetableType timetableType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != timetableType.Id)
            {
                return BadRequest();
            }

            db.Entry(timetableType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimetableTypeExists(id))
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

        // POST: api/TimetableTypes
        [ResponseType(typeof(TimetableType))]
        public IHttpActionResult PostTimetableType(TimetableType timetableType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TimetableType.Add(timetableType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = timetableType.Id }, timetableType);
        }

        // DELETE: api/TimetableTypes/5
        [ResponseType(typeof(TimetableType))]
        public IHttpActionResult DeleteTimetableType(int id)
        {
            TimetableType timetableType = db.TimetableType.Find(id);
            if (timetableType == null)
            {
                return NotFound();
            }

            db.TimetableType.Remove(timetableType);
            db.SaveChanges();

            return Ok(timetableType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TimetableTypeExists(int id)
        {
            return db.TimetableType.Count(e => e.Id == id) > 0;
        }
    }
}