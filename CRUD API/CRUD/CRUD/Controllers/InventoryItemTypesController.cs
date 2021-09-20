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
    [System.Web.Http.RoutePrefix("Api/inventoryType")]
    public class InventoryItemTypesController : ApiController
    {
        private NdoNandiDBEntities db = new NdoNandiDBEntities();

        [System.Web.Http.Route("read")]
        // GET: api/InventoryItemTypes
        public IQueryable<InventoryItemType> GetInventoryItemTypes()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.InventoryItemTypes;
        }

        [System.Web.Http.Route("getById")]
        // GET: api/InventoryItemTypes/5
        [ResponseType(typeof(InventoryItemType))]
        public IHttpActionResult GetInventoryItemType(int id)
        {
            InventoryItemType inventoryItemType = db.InventoryItemTypes.Find(id);
            if (inventoryItemType == null)
            {
                return NotFound();
            }

            return Ok(inventoryItemType);
        }

        [System.Web.Http.Route("update")]
        // PUT: api/InventoryItemTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInventoryItemType(int id, InventoryItemType inventoryItemType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inventoryItemType.TypeID)
            {
                return BadRequest();
            }

            db.Entry(inventoryItemType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryItemTypeExists(id))
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
        // POST: api/InventoryItemTypes
        [ResponseType(typeof(InventoryItemType))]
        public IHttpActionResult PostInventoryItemType(InventoryItemType inventoryItemType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.InventoryItemTypes.Add(inventoryItemType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = inventoryItemType.TypeID }, inventoryItemType);
        }

        [System.Web.Http.Route("delete")]
        // DELETE: api/InventoryItemTypes/5
        [ResponseType(typeof(InventoryItemType))]
        public IHttpActionResult DeleteInventoryItemType(int id)
        {
            InventoryItemType inventoryItemType = db.InventoryItemTypes.Find(id);
            if (inventoryItemType == null)
            {
                return NotFound();
            }

            db.InventoryItemTypes.Remove(inventoryItemType);
            db.SaveChanges();

            return Ok(inventoryItemType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InventoryItemTypeExists(int id)
        {
            return db.InventoryItemTypes.Count(e => e.TypeID == id) > 0;
        }
    }
}