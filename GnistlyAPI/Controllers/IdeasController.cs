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
    public class IdeasController : ApiController
    {
        private Context db = new Context();

        // GET: api/Ideas
        //public IQueryable<Idea> GetIdeas() -- replaced by -see below. JC
        //{
        //    return db.Ideas;
        //}

        // GET api/Ideas
        public IQueryable<IdeaDTO> GetIdeas()
        {
            var ideas = from i in db.Ideas
                        select new IdeaDTO()
                        {
                            IdeaID = i.IdeaID,
                            IdeaTitle = i.IdeaTitle,
                            IdeaDescription = i.IdeaDescription
                        };
            return ideas;
        }

        // GET: api/Ideas/5
        [ResponseType(typeof(IdeaDetailDTO))] //changed type JC
        public async Task<IHttpActionResult> GetIdea(int id)
        {
            var idea = await db.Ideas.Include(b => b.User).Select(b =>
                new IdeaDetailDTO()
                {
                    IdeaID = b.IdeaID,
                    IdeaTitle = b.IdeaTitle,
                    IdeaDescription = b.IdeaDescription,
                    IdeaDate = b.IdeaDate,
                    IdeaImpact = b.IdeaImpact,
                    IdeaEffort = b.IdeaEffort,
                    IdeaChallenges = b.IdeaChallenges,
                    IdeaResults = b.IdeaResults,
                    IdeaSavings = b.IdeaSavings,
                    IdeaAuthor = b.User.UserFname
                }).SingleOrDefaultAsync(b => b.IdeaAuthor.Equals(id));

            if (idea == null)
            {
                return NotFound();
            }

            return Ok(idea);
        }

        // PUT: api/Ideas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutIdea(int id, Idea idea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != idea.IdeaID)
            {
                return BadRequest();
            }

            db.Entry(idea).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IdeaExists(id))
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

        // POST: api/Ideas //changed to return a DTO
        [ResponseType(typeof(IdeaDTO))] // changed type from Idea to IdeaDTO
        public async Task<IHttpActionResult> PostIdea(Idea idea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ideas.Add(idea);
            await db.SaveChangesAsync();

            //new code start:
            db.Entry(idea).Reference(x => x.User).Load(); //load user name

            var dto = new IdeaDTO()
            {
                IdeaID = idea.IdeaID,
                IdeaTitle = idea.IdeaTitle,
                IdeaDescription = idea.IdeaDescription
            };
            //new code stop

            return CreatedAtRoute("DefaultApi", new { id = idea.IdeaID }, dto);
        }

        // DELETE: api/Ideas/5
        [ResponseType(typeof(Idea))]
        public async Task<IHttpActionResult> DeleteIdea(int id)
        {
            Idea idea = await db.Ideas.FindAsync(id);
            if (idea == null)
            {
                return NotFound();
            }

            db.Ideas.Remove(idea);
            await db.SaveChangesAsync();

            return Ok(idea);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IdeaExists(int id)
        {
            return db.Ideas.Count(e => e.IdeaID == id) > 0;
        }
    }
}