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
    public class EditsController : ApiController
    {
        private Context db = new Context();

        // GET: api/Edits
        public IQueryable<Edit> GetEdits()
        {
            return db.Edits;
        }

        // GET: api/Edits/5
        [ResponseType(typeof(Edit))]
        public async Task<IHttpActionResult> GetEdit(int id)
        {
            Edit edit = await db.Edits.FindAsync(id);
            if (edit == null)
            {
                return NotFound();
            }

            return Ok(edit);
        }

        // PUT: api/Edits/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEdit(int id, Edit edit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != edit.EditID)
            {
                return BadRequest();
            }

            db.Entry(edit).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EditExists(id))
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

        // POST: api/Edits
        [ResponseType(typeof(Edit))]
        public async Task<IHttpActionResult> PostEdit(Edit edit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Edits.Add(edit);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = edit.EditID }, edit);
        }

        // DELETE: api/Edits/5
        [ResponseType(typeof(Edit))]
        public async Task<IHttpActionResult> DeleteEdit(int id)
        {
            Edit edit = await db.Edits.FindAsync(id);
            if (edit == null)
            {
                return NotFound();
            }

            db.Edits.Remove(edit);
            await db.SaveChangesAsync();

            return Ok(edit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EditExists(int id)
        {
            return db.Edits.Count(e => e.EditID == id) > 0;
        }
    }
}