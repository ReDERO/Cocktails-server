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
    public class CocktailsController : Controller
    {
        private CocktailsDbContext db = new CocktailsDbContext();

        // GET: AdminPanel/Cocktails
        public ActionResult Index()
        {
            return View(db.Cocktails.ToList());
        }

        // GET: AdminPanel/Cocktails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cocktail cocktail = db.Cocktails.Find(id);
            if (cocktail == null)
            {
                return HttpNotFound();
            }
            return View(cocktail);
        }

        // GET: AdminPanel/Cocktails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminPanel/Cocktails/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] Cocktail cocktail)
        {
            if (ModelState.IsValid)
            {
                db.Cocktails.Add(cocktail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cocktail);
        }

        // GET: AdminPanel/Cocktails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cocktail cocktail = db.Cocktails.Find(id);
            if (cocktail == null)
            {
                return HttpNotFound();
            }
            return View(cocktail);
        }

        // POST: AdminPanel/Cocktails/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] Cocktail cocktail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cocktail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cocktail);
        }

        // GET: AdminPanel/Cocktails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cocktail cocktail = db.Cocktails.Find(id);
            if (cocktail == null)
            {
                return HttpNotFound();
            }
            return View(cocktail);
        }

        // POST: AdminPanel/Cocktails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cocktail cocktail = db.Cocktails.Find(id);
            db.Cocktails.Remove(cocktail);
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
