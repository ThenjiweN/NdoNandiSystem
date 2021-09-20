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
    [System.Web.Http.RoutePrefix("Api/inventoryItem")]
    public class InventoryItemsController : ApiController
    {
        private NdoNandiDBEntities db = new NdoNandiDBEntities();

        [System.Web.Http.Route("read")]
        // GET: api/InventoryItems
        public IQueryable<InventoryItem> GetInventoryItems()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.InventoryItems;
        }

        [System.Web.Http.Route("getById")]
        // GET: api/InventoryItems/5
        [ResponseType(typeof(InventoryItem))]
        public IHttpActionResult GetInventoryItem(int id)
        {
            InventoryItem inventoryItem = db.InventoryItems.Find(id);
            if (inventoryItem == null)
            {
                return NotFound();
            }

            return Ok(inventoryItem);
        }

        [System.Web.Http.Route("update")]
        // PUT: api/InventoryItems/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInventoryItem(int id, InventoryItem inventoryItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inventoryItem.ID)
            {
                return BadRequest();
            }

            db.Entry(inventoryItem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryItemExists(id))
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
        // POST: api/InventoryItems
        [ResponseType(typeof(InventoryItem))]
        public IHttpActionResult PostInventoryItem(InventoryItem inventoryItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.InventoryItems.Add(inventoryItem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = inventoryItem.ID }, inventoryItem);
        }

        [System.Web.Http.Route("delete")]
        // DELETE: api/InventoryItems/5
        [ResponseType(typeof(InventoryItem))]
        public IHttpActionResult DeleteInventoryItem(int id)
        {
            InventoryItem inventoryItem = db.InventoryItems.Find(id);
            if (inventoryItem == null)
            {
                return NotFound();
            }

            db.InventoryItems.Remove(inventoryItem);
            db.SaveChanges();

            return Ok(inventoryItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InventoryItemExists(int id)
        {
            return db.InventoryItems.Count(e => e.ID == id) > 0;
        }
    }
}