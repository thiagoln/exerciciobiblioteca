using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppExercício.Models;

namespace WebAppExercício.Controllers
{
    public class RequisicaoController : Controller
    {
        private BibliotecaContext db = new BibliotecaContext();

        // GET: Requisicao
        public ActionResult Index()
        {
            var requisicaos = db.Requisicaos.Include(r => r.Aluno).Include(r => r.Livro);
            return View(requisicaos.ToList());
        }

        // GET: Requisicao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requisicao requisicao = db.Requisicaos.Find(id);
            if (requisicao == null)
            {
                return HttpNotFound();
            }
            return View(requisicao);
        }

        // GET: Requisicao/Create
        public ActionResult Create()
        {
            ViewBag.AlunoId = new SelectList(db.Alunoes, "AlunoId", "Nome");
            ViewBag.LivroId = new SelectList(db.Livroes, "LivroId", "Isbn");
            return View();
        }

        // POST: Requisicao/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RequisicaoId,LivroId,AlunoId,DataRequisicao,DataEntrega")] Requisicao requisicao)
        {
            if (ModelState.IsValid)
            {
                db.Requisicaos.Add(requisicao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlunoId = new SelectList(db.Alunoes, "AlunoId", "Nome", requisicao.AlunoId);
            ViewBag.LivroId = new SelectList(db.Livroes, "LivroId", "Isbn", requisicao.LivroId);
            return View(requisicao);
        }

        // GET: Requisicao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requisicao requisicao = db.Requisicaos.Find(id);
            if (requisicao == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlunoId = new SelectList(db.Alunoes, "AlunoId", "Nome", requisicao.AlunoId);
            ViewBag.LivroId = new SelectList(db.Livroes, "LivroId", "Isbn", requisicao.LivroId);
            return View(requisicao);
        }

        // POST: Requisicao/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RequisicaoId,LivroId,AlunoId,DataRequisicao,DataEntrega")] Requisicao requisicao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requisicao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlunoId = new SelectList(db.Alunoes, "AlunoId", "Nome", requisicao.AlunoId);
            ViewBag.LivroId = new SelectList(db.Livroes, "LivroId", "Isbn", requisicao.LivroId);
            return View(requisicao);
        }

        // GET: Requisicao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requisicao requisicao = db.Requisicaos.Find(id);
            if (requisicao == null)
            {
                return HttpNotFound();
            }
            return View(requisicao);
        }

        // POST: Requisicao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Requisicao requisicao = db.Requisicaos.Find(id);
            db.Requisicaos.Remove(requisicao);
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
