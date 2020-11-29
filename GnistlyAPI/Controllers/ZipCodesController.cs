using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using GnistlyAPI.Models;

namespace GnistlyAPI.Controllers
{
    public class ZipCodesController : ApiController
    {
        private Context db = new Context();

        // GET: api/ZipCodes
        public IQueryable<ZipCode> GetZipCodes()
        {
            return db.ZipCodes;
        }

        // GET: api/ZipCodes/5
        [ResponseType(typeof(ZipCode))]
        public async Task<IHttpActionResult> GetZipCode(string id)
        {
            ZipCode zipCode = await db.ZipCodes.FindAsync(id);
            if (zipCode == null)
            {
                return NotFound();
            }

            return Ok(zipCode);
        }

        // PUT: api/ZipCodes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutZipCode(string id, ZipCode zipCode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != zipCode.Zip)
            {
                return BadRequest();
            }

            db.Entry(zipCode).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZipCodeExists(id))
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

        // POST: api/ZipCodes
        [ResponseType(typeof(ZipCode))]
        public async Task<IHttpActionResult> PostZipCode(ZipCode zipCode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ZipCodes.Add(zipCode);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ZipCodeExists(zipCode.Zip))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = zipCode.Zip }, zipCode);
        }

        // DELETE: api/ZipCodes/5
        [ResponseType(typeof(ZipCode))]
        public async Task<IHttpActionResult> DeleteZipCode(string id)
        {
            ZipCode zipCode = await db.ZipCodes.FindAsync(id);
            if (zipCode == null)
            {
                return NotFound();
            }

            db.ZipCodes.Remove(zipCode);
            await db.SaveChangesAsync();

            return Ok(zipCode);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ZipCodeExists(string id)
        {
            return db.ZipCodes.Count(e => e.Zip == id) > 0;
        }
    }
}