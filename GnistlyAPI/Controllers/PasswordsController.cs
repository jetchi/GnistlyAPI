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
    public class PasswordsController : ApiController
    {
        private Context db = new Context();

        // GET: api/Passwords
        public IQueryable<Password> GetPasswords()
        {
            return db.Passwords;
        }

        // GET: api/Passwords/5
        [ResponseType(typeof(Password))]
        public async Task<IHttpActionResult> GetPassword(string id)
        {
            Password password = await db.Passwords.FindAsync(id);
            if (password == null)
            {
                return NotFound();
            }

            return Ok(password);
        }

        // PUT: api/Passwords/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPassword(string id, Password password)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != password.PasswordChars)
            {
                return BadRequest();
            }

            db.Entry(password).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PasswordExists(id))
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

        // POST: api/Passwords
        [ResponseType(typeof(Password))]
        public async Task<IHttpActionResult> PostPassword(Password password)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Passwords.Add(password);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PasswordExists(password.PasswordChars))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = password.PasswordChars }, password);
        }

        // DELETE: api/Passwords/5
        [ResponseType(typeof(Password))]
        public async Task<IHttpActionResult> DeletePassword(string id)
        {
            Password password = await db.Passwords.FindAsync(id);
            if (password == null)
            {
                return NotFound();
            }

            db.Passwords.Remove(password);
            await db.SaveChangesAsync();

            return Ok(password);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PasswordExists(string id)
        {
            return db.Passwords.Count(e => e.PasswordChars == id) > 0;
        }
    }
}