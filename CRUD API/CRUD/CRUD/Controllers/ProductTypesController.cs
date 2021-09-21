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
    [System.Web.Http.RoutePrefix("Api/productType")]
    public class ProductTypesController : ApiController
    {
        private NdoNandiDBEntities db = new NdoNandiDBEntities();

        [System.Web.Http.Route("read")]
        // GET: api/ProductTypes
        public IQueryable<ProductType> GetProductTypes()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.ProductTypes;
        }

        [System.Web.Http.Route("getById")]
        // GET: api/ProductTypes/5
        [ResponseType(typeof(ProductType))]
        public IHttpActionResult GetProductType(int id)
        {
            ProductType productType = db.ProductTypes.Find(id);
            if (productType == null)
            {
                return NotFound();
            }

            return Ok(productType);
        }

        [System.Web.Http.Route("update")]
        // PUT: api/ProductTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProductType(int id, ProductType productType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productType.TypeID)
            {
                return BadRequest();
            }

            db.Entry(productType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductTypeExists(id))
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
        // POST: api/ProductTypes
        [ResponseType(typeof(ProductType))]
        public IHttpActionResult PostProductType(ProductType productType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductTypes.Add(productType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = productType.TypeID }, productType);
        }

        [System.Web.Http.Route("delete")]
        // DELETE: api/ProductTypes/5
        [ResponseType(typeof(ProductType))]
        public IHttpActionResult DeleteProductType(int id)
        {
            ProductType productType = db.ProductTypes.Find(id);
            if (productType == null)
            {
                return NotFound();
            }

            db.ProductTypes.Remove(productType);
            db.SaveChanges();

            return Ok(productType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductTypeExists(int id)
        {
            return db.ProductTypes.Count(e => e.TypeID == id) > 0;
        }
    }
}