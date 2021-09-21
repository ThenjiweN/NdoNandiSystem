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
    [System.Web.Http.RoutePrefix("Api/condition")]
    public class HairConditionsController : ApiController
    {
        private NdoNandiDBEntities db = new NdoNandiDBEntities();

        [System.Web.Http.Route("read")]
        // GET: api/HairConditions
        public IQueryable<HairCondition> GetHairConditions()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.HairConditions;
        }

        [System.Web.Http.Route("getById")]
        // GET: api/HairConditions/5
        [ResponseType(typeof(HairCondition))]
        public IHttpActionResult GetHairCondition(int id)
        {
            HairCondition hairCondition = db.HairConditions.Find(id);
            if (hairCondition == null)
            {
                return NotFound();
            }

            return Ok(hairCondition);
        }

        [System.Web.Http.Route("update")]
        // PUT: api/HairConditions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHairCondition(int id, HairCondition hairCondition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hairCondition.ID)
            {
                return BadRequest();
            }

            db.Entry(hairCondition).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HairConditionExists(id))
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
        // POST: api/HairConditions
        [ResponseType(typeof(HairCondition))]
        public IHttpActionResult PostHairCondition(HairCondition hairCondition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HairConditions.Add(hairCondition);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hairCondition.ID }, hairCondition);
        }

        [System.Web.Http.Route("delete")]
        // DELETE: api/HairConditions/5
        [ResponseType(typeof(HairCondition))]
        public IHttpActionResult DeleteHairCondition(int id)
        {
            HairCondition hairCondition = db.HairConditions.Find(id);
            if (hairCondition == null)
            {
                return NotFound();
            }

            db.HairConditions.Remove(hairCondition);
            db.SaveChanges();

            return Ok(hairCondition);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HairConditionExists(int id)
        {
            return db.HairConditions.Count(e => e.ID == id) > 0;
        }
    }
}