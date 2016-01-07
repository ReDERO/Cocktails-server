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
            var cocktailIngredients = db.CocktailIngredients.Include(c => c.Cocktail).Include(c => c.Ingredient);
            return View(cocktailIngredients.ToList());
        }

        // GET: AdminPanel/CocktailIngredients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CocktailIngredient cocktailIngredient = db.CocktailIngredients.Find(id);
            if (cocktailIngredient == null)
            {
                return HttpNotFound();
            }
            return View(cocktailIngredient);
        }

        // GET: AdminPanel/CocktailIngredients/Create
        public ActionResult Create()
        {
            ViewBag.CocktailId = new SelectList(db.Coctails, "Id", "Name");
            ViewBag.IngredientId = new SelectList(db.Ingredients, "Id", "Name");
            return View();
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
                return RedirectToAction("Index");
            }

            ViewBag.CocktailId = new SelectList(db.Coctails, "Id", "Name", cocktailIngredient.CocktailId);
            ViewBag.IngredientId = new SelectList(db.Ingredients, "Id", "Name", cocktailIngredient.IngredientId);
            return View(cocktailIngredient);
        }

        // GET: AdminPanel/CocktailIngredients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CocktailIngredient cocktailIngredient = db.CocktailIngredients.Find(id);
            if (cocktailIngredient == null)
            {
                return HttpNotFound();
            }
            ViewBag.CocktailId = new SelectList(db.Coctails, "Id", "Name", cocktailIngredient.CocktailId);
            ViewBag.IngredientId = new SelectList(db.Ingredients, "Id", "Name", cocktailIngredient.IngredientId);
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
                return RedirectToAction("Index");
            }
            ViewBag.CocktailId = new SelectList(db.Coctails, "Id", "Name", cocktailIngredient.CocktailId);
            ViewBag.IngredientId = new SelectList(db.Ingredients, "Id", "Name", cocktailIngredient.IngredientId);
            return View(cocktailIngredient);
        }

        // GET: AdminPanel/CocktailIngredients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CocktailIngredient cocktailIngredient = db.CocktailIngredients.Find(id);
            if (cocktailIngredient == null)
            {
                return HttpNotFound();
            }
            return View(cocktailIngredient);
        }

        // POST: AdminPanel/CocktailIngredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CocktailIngredient cocktailIngredient = db.CocktailIngredients.Find(id);
            db.CocktailIngredients.Remove(cocktailIngredient);
            db.SaveChanges();
            return RedirectToAction("Index");
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
