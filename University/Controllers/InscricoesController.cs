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
    public class InscricoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Inscricoes
        public ActionResult Index()
        {
            var inscricoes = db.Inscricoes.Include(i => i.Estudante);
            return View(inscricoes.ToList());
        }

        // GET: Inscricoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscricao inscricao = db.Inscricoes.Find(id);
            if (inscricao == null)
            {
                return HttpNotFound();
            }
            return View(inscricao);
        }

        // GET: Inscricoes/Create
        public ActionResult Create()
        {
            ViewBag.Estudantes = new SelectList(db.Estudantes, "EstudanteId", "Nome");
            ViewBag.Cursos = new SelectList(db.Cursos, "CursoId", "Titulo");
            return View();
        }

        // POST: Inscricoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InscricaoId,CursoId,EstudanteId,Grau,DataInscricao")] Inscricao inscricao)
        {
            if (ModelState.IsValid)
            {
                db.Inscricoes.Add(inscricao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Estudantes = new SelectList(db.Estudantes, "EstudanteId", "Nome");
            ViewBag.Cursos = new SelectList(db.Cursos, "CursoId", "Titulo"); return View(inscricao);
        }

        // GET: Inscricoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscricao inscricao = db.Inscricoes.Find(id);
            if (inscricao == null)
            {
                return HttpNotFound();
            }
            ViewBag.Estudantes = new SelectList(db.Estudantes, "EstudanteId", "Nome");
            ViewBag.Cursos = new SelectList(db.Cursos, "CursoId", "Titulo"); 
            return View(inscricao);
        }

        // POST: Inscricoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InscricaoId,CursoId,EstudanteId,Grau,DataInscricao")] Inscricao inscricao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inscricao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Estudantes = new SelectList(db.Estudantes, "EstudanteId", "Nome");
            ViewBag.Cursos = new SelectList(db.Cursos, "CursoId", "Titulo"); return View(inscricao);
        }

        // GET: Inscricoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscricao inscricao = db.Inscricoes.Find(id);
            if (inscricao == null)
            {
                return HttpNotFound();
            }
            return View(inscricao);
        }

        // POST: Inscricoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inscricao inscricao = db.Inscricoes.Find(id);
            db.Inscricoes.Remove(inscricao);
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
