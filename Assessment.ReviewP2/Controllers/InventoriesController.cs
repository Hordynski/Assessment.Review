﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Assessment.ReviewP2.DAL;
using Assessment.ReviewP2.Models;

namespace Assessment.ReviewP2.Controllers
{
    [EnableCors("*", "*", "*")]
    public class InventoriesController : ApiController
    {
        private InventoryDBContext db = new InventoryDBContext();

        // GET: api/Inventories
        public IQueryable<Inventory> GetInventories()
        {
            return db.Inventories;
        }

        // GET: api/Inventories/5
        [ResponseType(typeof(Inventory))]
        public async Task<IHttpActionResult> GetInventory(int id)
        {
            Inventory inventory = await db.Inventories.FindAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }

            return Ok(inventory);
        }

        // PUT: api/Inventories/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutInventory(int id, Inventory inventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var request = db.Inventories.Find(id);
            request.Quantity -= inventory.Quantity;

            if (id != inventory.ID)
            {
                return BadRequest();
            }

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryExists(id))
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

        // POST: api/Inventories
        [ResponseType(typeof(Inventory))]
        public async Task<IHttpActionResult> PostInventory(Inventory inventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Inventories.Add(inventory);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = inventory.ID }, inventory);
        }

        // DELETE: api/Inventories/5
        [ResponseType(typeof(Inventory))]
        public async Task<IHttpActionResult> DeleteInventory(int id)
        {
            Inventory inventory = await db.Inventories.FindAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }

            db.Inventories.Remove(inventory);
            await db.SaveChangesAsync();

            return Ok(inventory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InventoryExists(int id)
        {
            return db.Inventories.Count(e => e.ID == id) > 0;
        }
    }
}