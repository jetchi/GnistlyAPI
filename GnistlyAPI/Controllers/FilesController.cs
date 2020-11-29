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
    public class FilesController : ApiController
    {
        private Context db = new Context();

        // GET: api/Files
        public IQueryable<File> GetFiles()
        {
            return db.Files;
        }

        // GET: api/Files/5
        [ResponseType(typeof(File))]
        public async Task<IHttpActionResult> GetFile(string id)
        {
            File file = await db.Files.FindAsync(id);
            if (file == null)
            {
                return NotFound();
            }

            return Ok(file);
        }

        // PUT: api/Files/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFile(string id, File file)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != file.FileName)
            {
                return BadRequest();
            }

            db.Entry(file).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FileExists(id))
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

        // POST: api/Files
        [ResponseType(typeof(File))]
        public async Task<IHttpActionResult> PostFile(File file)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Files.Add(file);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = file.FileName }, file);
        }

        // DELETE: api/Files/5
        [ResponseType(typeof(File))]
        public async Task<IHttpActionResult> DeleteFile(string id)
        {
            File file = await db.Files.FindAsync(id);
            if (file == null)
            {
                return NotFound();
            }

            db.Files.Remove(file);
            await db.SaveChangesAsync();

            return Ok(file);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FileExists(string id)
        {
            return db.Files.Count(e => e.FileName == id) > 0;
        }
    }
}