using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using University.Models;

namespace University.Controllers
{
    [Authorize]
    public class EstudantesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Estudantes
        public ActionResult Index()
        {
            return View(db.Estudantes.ToList());
        }

        // GET: Estudantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudante estudante = db.Estudantes.Find(id);
            if (estudante == null)
            {
                return HttpNotFound();
            }
            return View(estudante);
        }

        // GET: Estudantes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estudantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EstudanteId,Nome,Endereco")] Estudante estudante)
        {
            if (ModelState.IsValid)
            {
                db.Estudantes.Add(estudante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estudante);
        }

        // GET: Estudantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudante estudante = db.Estudantes.Find(id);
            if (estudante == null)
            {
                return HttpNotFound();
            }
            return View(estudante);
        }

        // POST: Estudantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EstudanteId,Nome,Endereco")] Estudante estudante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estudante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estudante);
        }

        // GET: Estudantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudante estudante = db.Estudantes.Find(id);
            if (estudante == null)
            {
                return HttpNotFound();
            }
            return View(estudante);
        }

        // POST: Estudantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estudante estudante = db.Estudantes.Find(id);
            db.Estudantes.Remove(estudante);
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
