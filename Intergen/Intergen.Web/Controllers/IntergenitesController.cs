using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyIntergenites.Web.Models;

namespace MyIntergenites.Web.Controllers
{
    public class IntergenitesController : Controller
    {
        private MyIntergenitesContext db = new MyIntergenitesContext();

        // GET: Intergenites
        public ActionResult Index()
        {
            return View(db.Intergenites.ToList());
        }

        // GET: Intergenites/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Intergenite Intergenite = db.Intergenites.Find(id);
            if (Intergenite == null)
            {
                return HttpNotFound();
            }
            return View(Intergenite);
        }

        // GET: Intergenites/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Intergenites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Department")] Intergenite Intergenite)
        {
            if (ModelState.IsValid)
            {
                db.Intergenites.Add(Intergenite);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Intergenite);
        }

        // GET: Intergenites/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Intergenite Intergenite = db.Intergenites.Find(id);
            if (Intergenite == null)
            {
                return HttpNotFound();
            }
            return View(Intergenite);
        }

        // POST: Intergenites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Department")] Intergenite Intergenite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Intergenite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Intergenite);
        }

        // GET: Intergenites/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Intergenite Intergenite = db.Intergenites.Find(id);
            if (Intergenite == null)
            {
                return HttpNotFound();
            }
            return View(Intergenite);
        }

        // POST: Intergenites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Intergenite Intergenite = db.Intergenites.Find(id);
            db.Intergenites.Remove(Intergenite);
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
