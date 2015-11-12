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
using Adressekartotek.Models;

namespace Adressekartotek.Controllers
{
    public class PeopleController : ApiController
    {
        private AdressekartotekContext db = new AdressekartotekContext();

        // GET: api/People
        public IQueryable<PersonDTO> GetPerson()
        {
            var person = from p in db.Person
                select new PersonDTO()
                {
                    PersonID = p.PersonID,
                    Fornavn = p.Fornavn
                };
            return person;
        }

        // GET: api/People/5
        [ResponseType(typeof(PersonDetailDTO))]
        public async Task<IHttpActionResult> GetPerson(long id)
        {
            var person = await db.Person.Include(p => p.Adresse).Select(p => new PersonDetailDTO()
            {
                PersonID = p.PersonID,
                CPRNr = p.CPRNr,
                Fornavn = p.Fornavn,
                Efternavn = p.Efternavn,
                Mellemnavn = p.Mellemnavn,
                AdresseID = p.AdresseID,
                type = p.type
            }).SingleOrDefaultAsync(p => p.PersonID == id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        // PUT: api/People/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPerson(long id, Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != person.PersonID)
            {
                return BadRequest();
            }

            db.Entry(person).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
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

        // POST: api/People
        [ResponseType(typeof(Person))]
        public async Task<IHttpActionResult> PostPerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Person.Add(person);
            await db.SaveChangesAsync();

            db.Entry(person).Reference(p => p.Adresse).Load();

            var dto = new PersonDTO()
            {
                PersonID = person.PersonID,
                Fornavn = person.Fornavn
            };

            return CreatedAtRoute("DefaultApi", new { id = person.PersonID }, dto);
        }

        // DELETE: api/People/5
        [ResponseType(typeof(Person))]
        public async Task<IHttpActionResult> DeletePerson(long id)
        {
            Person person = await db.Person.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            db.Person.Remove(person);
            await db.SaveChangesAsync();

            return Ok(person);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonExists(long id)
        {
            return db.Person.Count(e => e.PersonID == id) > 0;
        }
    }
}