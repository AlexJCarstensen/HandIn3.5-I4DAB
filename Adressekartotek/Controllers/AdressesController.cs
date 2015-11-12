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
    public class AdressesController : ApiController
    {
        private AdressekartotekContext db = new AdressekartotekContext();

        // GET: api/Adresses
        public IQueryable<AdresseDTO> GetAdresse()
        {
            var adresse = from a in db.Adresse
                select new AdresseDTO()
                {
                    AdresseID = a.AdresseID,
                    PostNummer = a.PostNummer,
                    City = a.City
                };
            return adresse;
        }

        // GET: api/Adresses/5
        [ResponseType(typeof(AdresseDetailDTO))]
        public async Task<IHttpActionResult> GetAdresse(long id)
        {
            var adresse = await db.Adresse.Include(a => a.Person).Include(a => a.Person1).Select(a => new AdresseDetailDTO()
            {
                AdresseID = a.AdresseID,
                Type = a.Type,
                VejNavn = a.VejNavn,
                HusNummer = a.HusNummer,
                PostNummer = a.PostNummer,
                City = a.City
            }).SingleOrDefaultAsync(a => a.AdresseID == id);
            if (adresse == null)
            {
                return NotFound();
            }

            return Ok(adresse);
        }

        // PUT: api/Adresses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAdresse(long id, Adresse adresse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adresse.AdresseID)
            {
                return BadRequest();
            }

            db.Entry(adresse).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdresseExists(id))
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

        // POST: api/Adresses
        [ResponseType(typeof(Adresse))]
        public async Task<IHttpActionResult> PostAdresse(Adresse adresse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Adresse.Add(adresse);
            await db.SaveChangesAsync();

            db.Entry(adresse).Reference(a => a.Person).Load();
            var dto = new AdresseDTO()
            {
                AdresseID = adresse.AdresseID,
                City = adresse.City,
                PostNummer = adresse.PostNummer
            };

            return CreatedAtRoute("DefaultApi", new { id = adresse.AdresseID }, dto);
        }

        // DELETE: api/Adresses/5
        [ResponseType(typeof(Adresse))]
        public async Task<IHttpActionResult> DeleteAdresse(long id)
        {
            Adresse adresse = await db.Adresse.FindAsync(id);
            if (adresse == null)
            {
                return NotFound();
            }

            db.Adresse.Remove(adresse);
            await db.SaveChangesAsync();

            return Ok(adresse);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdresseExists(long id)
        {
            return db.Adresse.Count(e => e.AdresseID == id) > 0;
        }
    }
}