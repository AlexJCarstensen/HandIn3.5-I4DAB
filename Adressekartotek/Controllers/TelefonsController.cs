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
    public class TelefonsController : ApiController
    {
        private AdressekartotekContext db = new AdressekartotekContext();

        // GET: api/Telefons
        public IQueryable<TelefonDTO> GetTelefon()
        {
            var telefon = from t in db.Telefon
                select new TelefonDTO()
                {
                    TelefonID = t.TelefonID,
                    TelefonNr = t.TelefonNr
                };
            return telefon;
        }

        // GET: api/Telefons/5
        [ResponseType(typeof(TelefonDetailDTO))]
        public async Task<IHttpActionResult> GetTelefon(long id)
        {
            var telefon = await db.Telefon.Include(t => t.Person).Select(t => new TelefonDetailDTO()
            {
                TelefonID = t.TelefonID,
                TelefonNr = t.TelefonNr,
                Type = t.Type,
                PersonID = t.PersonID,
                Person = t.Person.Fornavn
            }).SingleOrDefaultAsync(t => t.TelefonID == id);

            if (telefon == null)
            {
                return NotFound();
            }

            return Ok(telefon);
        }

        // PUT: api/Telefons/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTelefon(long id, Telefon telefon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != telefon.TelefonID)
            {
                return BadRequest();
            }

            db.Entry(telefon).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelefonExists(id))
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

        // POST: api/Telefons
        [ResponseType(typeof(Telefon))]
        public async Task<IHttpActionResult> PostTelefon(Telefon telefon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Telefon.Add(telefon);
            await db.SaveChangesAsync();

            // new code
            db.Entry(telefon).Reference(t => t.Person).Load();
            var dto = new TelefonDTO()
            {
                TelefonNr = telefon.TelefonNr,
                TelefonID = telefon.TelefonID
            };

            return CreatedAtRoute("DefaultApi", new { id = telefon.TelefonID }, dto);
        }

        // DELETE: api/Telefons/5
        [ResponseType(typeof(Telefon))]
        public async Task<IHttpActionResult> DeleteTelefon(long id)
        {
            Telefon telefon = await db.Telefon.FindAsync(id);
            if (telefon == null)
            {
                return NotFound();
            }

            db.Telefon.Remove(telefon);
            await db.SaveChangesAsync();

            return Ok(telefon);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TelefonExists(long id)
        {
            return db.Telefon.Count(e => e.TelefonID == id) > 0;
        }
    }
}