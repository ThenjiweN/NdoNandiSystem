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
    [System.Web.Http.RoutePrefix("Api/density")]
    public class HairDensitiesController : ApiController
    {
        private NdoNandiDBEntities db = new NdoNandiDBEntities();

        [System.Web.Http.Route("read")]
        [System.Web.Mvc.HttpGet]
        // GET: api/HairDensities
        public IQueryable<HairDensity> GetHairDensities()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.HairDensities;
        }

        [System.Web.Http.Route("getById")]
        [System.Web.Mvc.HttpGet]
        // GET: api/HairDensities/5
        [ResponseType(typeof(HairDensity))]
        public IHttpActionResult GetHairDensity(int id)
        {
            HairDensity hairDensity = db.HairDensities.Find(id);
            if (hairDensity == null)
            {
                return NotFound();
            }

            return Ok(hairDensity);
        }

        [System.Web.Http.Route("update")]
        [System.Web.Mvc.HttpPut]
        // PUT: api/HairDensities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHairDensity(int id, HairDensity hairDensity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hairDensity.ID)
            {
                return BadRequest();
            }

            db.Entry(hairDensity).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HairDensityExists(id))
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
        // POST: api/HairDensities
        [ResponseType(typeof(HairDensity))]
        public IHttpActionResult PostHairDensity(HairDensity hairDensity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HairDensities.Add(hairDensity);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hairDensity.ID }, hairDensity);
        }

        [System.Web.Http.Route("delete")]
        [System.Web.Mvc.HttpDelete]
        // DELETE: api/HairDensities/5
        [ResponseType(typeof(HairDensity))]
        public IHttpActionResult DeleteHairDensity(int id)
        {
            HairDensity hairDensity = db.HairDensities.Find(id);
            if (hairDensity == null)
            {
                return NotFound();
            }

            db.HairDensities.Remove(hairDensity);
            db.SaveChanges();

            return Ok(hairDensity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HairDensityExists(int id)
        {
            return db.HairDensities.Count(e => e.ID == id) > 0;
        }
    }
}