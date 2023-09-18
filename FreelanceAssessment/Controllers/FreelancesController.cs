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
using FreelanceAssessment.Data;
using FreelanceAssessment.Models;

namespace FreelanceAssessment.Controllers
{
    public class FreelancesController : ApiController
    {
        private FreelanceAssessmentContext db = new FreelanceAssessmentContext();

        // GET: api/Freelances
        public IQueryable<Freelance> GetFreelances()
        {
            return db.Freelances;
        }

        // GET: api/Freelances/5
        [ResponseType(typeof(Freelance))]
        public async Task<IHttpActionResult> GetFreelance(int id)
        {
            Freelance freelance = await db.Freelances.FindAsync(id);
            if (freelance == null)
            {
                return NotFound();
            }

            return Ok(freelance);
        }

        // PUT: api/Freelances/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFreelance(int id, Freelance freelance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != freelance.Id)
            {
                return BadRequest();
            }

            db.Entry(freelance).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FreelanceExists(id))
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

        // POST: api/Freelances
        [ResponseType(typeof(Freelance))]
        public async Task<IHttpActionResult> PostFreelance(Freelance freelance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Freelances.Add(freelance);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = freelance.Id }, freelance);
        }

        // DELETE: api/Freelances/5
        [ResponseType(typeof(Freelance))]
        public async Task<IHttpActionResult> DeleteFreelance(int id)
        {
            Freelance freelance = await db.Freelances.FindAsync(id);
            if (freelance == null)
            {
                return NotFound();
            }

            db.Freelances.Remove(freelance);
            await db.SaveChangesAsync();

            return Ok(freelance);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FreelanceExists(int id)
        {
            return db.Freelances.Count(e => e.Id == id) > 0;
        }
    }
}