using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CocktailsDatabase;

namespace Cocktails.Areas.AdminPanel.Controllers
{
    public class CocktailIngredientsController : Controller
    {
        private CocktailsDbContext db = new CocktailsDbContext();

        // GET: AdminPanel/CocktailIngredients
        public ActionResult Index()
        {
            var cocktailIngredients = db.CocktailIngredients
                .Include(c => c.Cocktail)
                .Include(c => c.Ingredient);
            return View(cocktailIngredients.ToList());
        }
        
        // GET: AdminPanel/CocktailIngredients/Create
        public ActionResult Create(int? cocktailId)
        {
            if (cocktailId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cocktail cocktail = db.Cocktails.Find(cocktailId);
            if (cocktail == null)
            {
                return HttpNotFound();
            }
            CocktailIngredient cocktailIngredient = new CocktailIngredient()
            {
                CocktailId = cocktail.Id,
                Cocktail = cocktail
            };
            ViewBag.IngredientId = new SelectList(db.Ingredients, "Id", "Name");
            return View(cocktailIngredient);
        }

        // POST: AdminPanel/CocktailIngredients/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CocktailId,IngredientId,Count")] CocktailIngredient cocktailIngredient)
        {
            if (ModelState.IsValid)
            {
                db.CocktailIngredients.Add(cocktailIngredient);
                db.SaveChanges();
                return RedirectToAction("Details", "Cocktails", new { id = cocktailIngredient.CocktailId });
            }

            Cocktail cocktail = db.Cocktails.Find(cocktailIngredient.CocktailId);
            cocktailIngredient.Cocktail = cocktail;

            ViewBag.IngredientId = new SelectList(db.Ingredients, "Id", "Name", cocktailIngredient.IngredientId);
            return View(cocktailIngredient);
        }

        // GET: AdminPanel/CocktailIngredients/Edit/5
        public ActionResult Edit(int? cocktailId, int? ingredientId)
        {
            if (cocktailId == null && ingredientId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CocktailIngredient cocktailIngredient = db.CocktailIngredients
                .Include(ci => ci.Cocktail)
                .Include(ci => ci.Ingredient)
                .FirstOrDefault(ci => ci.CocktailId == cocktailId && ci.IngredientId == ingredientId);
            if (cocktailIngredient == null)
            {
                return HttpNotFound();
            }
            return View(cocktailIngredient);
        }

        // POST: AdminPanel/CocktailIngredients/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CocktailId,IngredientId,Count")] CocktailIngredient cocktailIngredient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cocktailIngredient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Cocktails", new { id = cocktailIngredient.CocktailId });
            }

            Cocktail cocktail = db.Cocktails.Find(cocktailIngredient.CocktailId);
            Ingredient ingredient = db.Ingredients.Find(cocktailIngredient.IngredientId);
            cocktailIngredient.Cocktail = cocktail;
            cocktailIngredient.Ingredient = ingredient;
            
            return View(cocktailIngredient);
        }

        // GET: AdminPanel/CocktailIngredients/Delete/5
        public ActionResult Delete(int? cocktailId, int? ingredientId)
        {
            if (cocktailId == null && ingredientId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CocktailIngredient cocktailIngredient = db.CocktailIngredients
                .Include(ci => ci.Cocktail)
                .Include(ci => ci.Ingredient)
                .FirstOrDefault(ci => ci.CocktailId == cocktailId && ci.IngredientId == ingredientId);
            if (cocktailIngredient == null)
            {
                return HttpNotFound();
            }
            return View(cocktailIngredient);
        }

        // POST: AdminPanel/CocktailIngredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? cocktailId, int? ingredientId)
        {
            CocktailIngredient cocktailIngredient = db.CocktailIngredients.Find(cocktailId, ingredientId);
            db.CocktailIngredients.Remove(cocktailIngredient);
            db.SaveChanges();
            return RedirectToAction("Details", "Cocktails", new { id = cocktailId });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
