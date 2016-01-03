using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CocktailsDatabase;
using Cocktails.Models;

namespace Cocktails.Controllers
{
    public class CocktailsController : ApiController
    {
        private CocktailsDbContext db = new CocktailsDbContext();

        // GET: api/Cocktails
        public object GetCoctails()
        {
            var cocktails = db.Coctails.Include(c => c.Ingredients).ToList();
            var cocktailsView = new List<CocktailViewModel>();

            foreach (var cocktail in cocktails)
            {
                cocktailsView.Add(new CocktailViewModel(cocktail));
            }

            return cocktailsView;
        }

        // GET: api/Cocktails/5
        [ResponseType(typeof(Cocktail))]
        public IHttpActionResult GetCocktail(int id)
        {
            Cocktail cocktail = db.Coctails.Find(id);
            if (cocktail == null)
            {
                return NotFound();
            }

            return Ok(cocktail);
        }

        // PUT: api/Cocktails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCocktail(int id, Cocktail cocktail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cocktail.Id)
            {
                return BadRequest();
            }

            db.Entry(cocktail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CocktailExists(id))
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

        // POST: api/Cocktails
        [ResponseType(typeof(Cocktail))]
        public IHttpActionResult PostCocktail(Cocktail cocktail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Coctails.Add(cocktail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cocktail.Id }, cocktail);
        }

        // DELETE: api/Cocktails/5
        [ResponseType(typeof(Cocktail))]
        public IHttpActionResult DeleteCocktail(int id)
        {
            Cocktail cocktail = db.Coctails.Find(id);
            if (cocktail == null)
            {
                return NotFound();
            }

            db.Coctails.Remove(cocktail);
            db.SaveChanges();

            return Ok(cocktail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CocktailExists(int id)
        {
            return db.Coctails.Count(e => e.Id == id) > 0;
        }
    }
}