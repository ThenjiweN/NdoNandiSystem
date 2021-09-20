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
    [System.Web.Http.RoutePrefix("Api/allergen")]
    public class AllergensController : ApiController
    {
        private NdoNandiDBEntities db = new NdoNandiDBEntities();

        [System.Web.Http.Route("read")]
        // GET: api/Allergens
        public IQueryable<Allergen> GetAllergens()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Allergens;
        }

        [System.Web.Http.Route("getById")]
        // GET: api/Allergens/5
        [ResponseType(typeof(Allergen))]
        public IHttpActionResult GetAllergen(int id)
        {
            Allergen allergen = db.Allergens.Find(id);
            if (allergen == null)
            {
                return NotFound();
            }

            return Ok(allergen);
        }

        [System.Web.Http.Route("update")]
        // PUT: api/Allergens/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAllergen(int id, Allergen allergen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != allergen.ID)
            {
                return BadRequest();
            }

            db.Entry(allergen).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AllergenExists(id))
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
        // POST: api/Allergens
        [ResponseType(typeof(Allergen))]
        public IHttpActionResult PostAllergen(Allergen allergen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Allergens.Add(allergen);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = allergen.ID }, allergen);
        }

        [System.Web.Http.Route("delete")]
        // DELETE: api/Allergens/5
        [ResponseType(typeof(Allergen))]
        public IHttpActionResult DeleteAllergen(int id)
        {
            Allergen allergen = db.Allergens.Find(id);
            if (allergen == null)
            {
                return NotFound();
            }

            db.Allergens.Remove(allergen);
            db.SaveChanges();

            return Ok(allergen);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AllergenExists(int id)
        {
            return db.Allergens.Count(e => e.ID == id) > 0;
        }
    }
}