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
    public class HashtagsController : ApiController
    {
        private Context db = new Context();

        // GET: api/Hashtags
        public IQueryable<Hashtag> GetHashtags()
        {
            return db.Hashtags;
        }

        // GET: api/Hashtags/5
        [ResponseType(typeof(Hashtag))]
        public async Task<IHttpActionResult> GetHashtag(int id)
        {
            Hashtag hashtag = await db.Hashtags.FindAsync(id);
            if (hashtag == null)
            {
                return NotFound();
            }

            return Ok(hashtag);
        }

        // PUT: api/Hashtags/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHashtag(int id, Hashtag hashtag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hashtag.HashtagID)
            {
                return BadRequest();
            }

            db.Entry(hashtag).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HashtagExists(id))
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

        // POST: api/Hashtags
        [ResponseType(typeof(Hashtag))]
        public async Task<IHttpActionResult> PostHashtag(Hashtag hashtag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Hashtags.Add(hashtag);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = hashtag.HashtagID }, hashtag);
        }

        // DELETE: api/Hashtags/5
        [ResponseType(typeof(Hashtag))]
        public async Task<IHttpActionResult> DeleteHashtag(int id)
        {
            Hashtag hashtag = await db.Hashtags.FindAsync(id);
            if (hashtag == null)
            {
                return NotFound();
            }

            db.Hashtags.Remove(hashtag);
            await db.SaveChangesAsync();

            return Ok(hashtag);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HashtagExists(int id)
        {
            return db.Hashtags.Count(e => e.HashtagID == id) > 0;
        }
    }
}