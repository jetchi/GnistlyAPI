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
using System.Web.Http.Cors;
using System.Web.Http.Description;
using GnistlyAPI.Models;

namespace GnistlyAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UrlsController : ApiController
    {
        private Context db = new Context();

        // GET: api/Urls
        public IQueryable<Url> GetUrls()
        {
            return db.Urls;
        }

        // GET: api/Urls/5
        [ResponseType(typeof(Url))]
        public async Task<IHttpActionResult> GetUrl(int id)
        {
            Url url = await db.Urls.FindAsync(id);
            if (url == null)
            {
                return NotFound();
            }

            return Ok(url);
        }

        // PUT: api/Urls/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUrl(int id, Url url)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != url.UrlID)
            {
                return BadRequest();
            }

            db.Entry(url).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UrlExists(id))
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

        // POST: api/Urls
        [ResponseType(typeof(Url))]
        public async Task<IHttpActionResult> PostUrl(Url url)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Urls.Add(url);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = url.UrlID }, url);
        }

        // DELETE: api/Urls/5
        [ResponseType(typeof(Url))]
        public async Task<IHttpActionResult> DeleteUrl(int id)
        {
            Url url = await db.Urls.FindAsync(id);
            if (url == null)
            {
                return NotFound();
            }

            db.Urls.Remove(url);
            await db.SaveChangesAsync();

            return Ok(url);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UrlExists(int id)
        {
            return db.Urls.Count(e => e.UrlID == id) > 0;
        }
    }
}