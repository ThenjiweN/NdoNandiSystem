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
using System.Dynamic;
using System.Web.Mvc;

namespace CRUD.Controllers
{
    [System.Web.Http.RoutePrefix("Api/length")]
    public class HairLengthsController : ApiController
    {
        private NdoNandiDBEntities db = new NdoNandiDBEntities();

        [System.Web.Http.Route("read")]
        [System.Web.Mvc.HttpGet]
        // GET: api/HairLengths
        public IQueryable<HairLength> GetHairLengths()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.HairLengths;
        }

        [System.Web.Http.Route("getById")]
        [System.Web.Mvc.HttpGet]
        // GET: api/HairLengths/5
        [ResponseType(typeof(HairLength))]
        public IHttpActionResult GetHairLength(int id)
        {
            HairLength hairLength = db.HairLengths.Find(id);
            if (hairLength == null)
            {
                return NotFound();
            }

            return Ok(hairLength);
        }

        [System.Web.Http.Route("update")]
        [System.Web.Mvc.HttpPut]
        // PUT: api/HairLengths/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHairLength(int id, HairLength hairLength)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hairLength.ID)
            {
                return BadRequest();
            }

            db.Entry(hairLength).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HairLengthExists(id))
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
        [System.Web.Mvc.HttpPost]
        // POST: api/HairLengths
        [ResponseType(typeof(HairLength))]
        public IHttpActionResult PostHairLength(HairLength hairLength)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HairLengths.Add(hairLength);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hairLength.ID }, hairLength);
        }

        [System.Web.Http.Route("delete")]
        [System.Web.Mvc.HttpDelete]
        // DELETE: api/HairLengths/5
        [ResponseType(typeof(HairLength))]
        public IHttpActionResult DeleteHairLength(int id)
        {
            HairLength hairLength = db.HairLengths.Find(id);
            if (hairLength == null)
            {
                return NotFound();
            }

            db.HairLengths.Remove(hairLength);
            db.SaveChanges();

            return Ok(hairLength);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HairLengthExists(int id)
        {
            return db.HairLengths.Count(e => e.ID == id) > 0;
        }
    }
}