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
    [System.Web.Http.RoutePrefix("Api/province")]
    public class ProvincesController : ApiController
    {
        private NdoNandiDBEntities db = new NdoNandiDBEntities();

        [System.Web.Http.Route("read")]
        // GET: api/Provinces
        public IQueryable<Province> GetProvinces()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Provinces;
        }

        [System.Web.Http.Route("getById")]
        // GET: api/Provinces/5
        [ResponseType(typeof(Province))]
        public IHttpActionResult GetProvince(int id)
        {
            Province province = db.Provinces.Find(id);
            if (province == null)
            {
                return NotFound();
            }

            return Ok(province);
        }

        [System.Web.Http.Route("update")]
        // PUT: api/Provinces/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProvince(int id, Province province)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != province.ProvinceID)
            {
                return BadRequest();
            }

            db.Entry(province).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProvinceExists(id))
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
        // POST: api/Provinces
        [ResponseType(typeof(Province))]
        public IHttpActionResult PostProvince(Province province)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Provinces.Add(province);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = province.ProvinceID }, province);
        }

        [System.Web.Http.Route("delete")]
        // DELETE: api/Provinces/5
        [ResponseType(typeof(Province))]
        public IHttpActionResult DeleteProvince(int id)
        {
            Province province = db.Provinces.Find(id);
            if (province == null)
            {
                return NotFound();
            }

            db.Provinces.Remove(province);
            db.SaveChanges();

            return Ok(province);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProvinceExists(int id)
        {
            return db.Provinces.Count(e => e.ProvinceID == id) > 0;
        }
    }
}