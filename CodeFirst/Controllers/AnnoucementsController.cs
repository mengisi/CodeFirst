using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeFirst.Models;

namespace CodeFirst.Controllers
{
    public class AnnoucementsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Annoucements
        public ActionResult Index()
        {
            return View(db.Annoucements.ToList());
        }

        // GET: Annoucements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Annoucement annoucement = db.Annoucements.Find(id);
            if (annoucement == null)
            {
                return HttpNotFound();
            }
            return View(annoucement);
        }

        // GET: Annoucements/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Annoucements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Text")] Annoucement annoucement)
        {
            if (ModelState.IsValid)
            {
                annoucement.CreateTime = DateTime.Now;
                db.Annoucements.Add(annoucement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(annoucement);
        }

        // GET: Annoucements/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Annoucement annoucement = db.Annoucements.Find(id);
            if (annoucement == null)
            {
                return HttpNotFound();
            }
            return View(annoucement);
        }

        // POST: Annoucements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Text,CreateTime")] Annoucement annoucement)
        {
            if (ModelState.IsValid)
            {
                annoucement.Updatetime = DateTime.Now;
                db.Entry(annoucement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(annoucement);
        }

        // GET: Annoucements/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Annoucement annoucement = db.Annoucements.Find(id);
            if (annoucement == null)
            {
                return HttpNotFound();
            }
            return View(annoucement);
        }

        // POST: Annoucements/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Annoucement annoucement = db.Annoucements.Find(id);
            db.Annoucements.Remove(annoucement);
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
