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
using CRUD.Models;
using System.Web.Mvc;

namespace CRUD.Controllers
{
    [System.Web.Http.RoutePrefix("Api/suburb")]
    public class SuburbsController : ApiController
    {
        private NdoNandiDBEntities db = new NdoNandiDBEntities();

        [System.Web.Http.Route("read")]
        // GET: api/Suburbs
        public IQueryable<Suburb> GetSuburbs()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Suburbs;
        }

        [System.Web.Http.Route("getById")]
        // GET: api/Suburbs/5
        [ResponseType(typeof(Suburb))]
        public IHttpActionResult GetSuburb(int id)
        {
            Suburb suburb = db.Suburbs.Find(id);
            if (suburb == null)
            {
                return NotFound();
            }

            return Ok(suburb);
        }

        [System.Web.Http.Route("update")]
        // PUT: api/Suburbs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSuburb(int id, Suburb suburb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != suburb.SuburbID)
            {
                return BadRequest();
            }

            db.Entry(suburb).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuburbExists(id))
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

        [System.Web.Http.Route("create")]
        // POST: api/Suburbs
        [ResponseType(typeof(Suburb))]
        public IHttpActionResult PostSuburb(Suburb suburb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Suburbs.Add(suburb);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = suburb.SuburbID }, suburb);
        }

        [System.Web.Http.Route("delete")]
        // DELETE: api/Suburbs/5
        [ResponseType(typeof(Suburb))]
        public IHttpActionResult DeleteSuburb(int id)
        {
            Suburb suburb = db.Suburbs.Find(id);
            if (suburb == null)
            {
                return NotFound();
            }

            db.Suburbs.Remove(suburb);
            db.SaveChanges();

            return Ok(suburb);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SuburbExists(int id)
        {
            return db.Suburbs.Count(e => e.SuburbID == id) > 0;
        }
    }
}