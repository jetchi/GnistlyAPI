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
   [EnableCors(origins: "*", headers: "*", methods: "*")] /* enables all headers, also from another origin. 
                                                           If only one other origin should be allowed, 
                                                           use the URI where the webClient is deployed 
                                                           as origin parameter (write "http://localhost:63342" 
                                                           instead of the first star).*/
    public class IdeasController : ApiController
    {
        private Context db = new Context();

        // GET: api/Ideas
        public IQueryable<Idea> GetIdeas() 
        {
            return db.Ideas.Include(c => c.User);
        }

        // not in use:
        //// GET api/Ideas
        //public IQueryable<IdeaDTO> GetIdeas()
        //{
        //    var ideas = from i in db.Ideas
        //                select new IdeaDTO()
        //                {
        //                    IdeaID = i.IdeaID,
        //                    IdeaTitle = i.IdeaTitle,
        //                    IdeaDescription = i.IdeaDescription
        //                };
        //    return ideas;
        //}

        // GET: api/Ideas/5
        [ResponseType(typeof(Idea))] 
        public async Task<IHttpActionResult> GetIdea(int id)
        {
            var idea = await db.Ideas.Include(b => b.User).Select(b =>
                new Idea()
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
                    User = b.User
                }).SingleOrDefaultAsync(b => b.User.Equals(id));

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

        // POST: api/Ideas
        [ResponseType(typeof(Idea))]
        public async Task<IHttpActionResult> PostIdea(Idea idea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ideas.Add(idea);
            await db.SaveChangesAsync();

            db.Entry(idea).Reference(x => x.User).Load(); //load corresponding user

            var dto = new Idea()
            {
                IdeaID = idea.IdeaID,
                IdeaTitle = idea.IdeaTitle,
                IdeaDescription = idea.IdeaDescription,
                IdeaDate = idea.IdeaDate,
                IdeaImpact = idea.IdeaImpact,
                IdeaEffort = idea.IdeaEffort,
                IdeaChallenges = idea.IdeaChallenges,
                IdeaSavings = idea.IdeaSavings,
                IdeaResults = idea.IdeaResults,
                UserID = idea.UserID
            };

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