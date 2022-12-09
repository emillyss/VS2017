using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ApplicationEF;

namespace ApplicationEF.Views.Teste
{
    public class TesteController : Controller
    {
        private ModelEF db = new ModelEF();

        // GET: Teste
        public ActionResult Index()
        {
            return View(db.testes.ToList());
        }

        // GET: Teste/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teste teste = db.testes.Find(id);
            if (teste == null)
            {
                return HttpNotFound();
            }
            return View(teste);
        }

        // GET: Teste/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teste/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,texto,numero,datahora")] teste teste)
        {
            if (ModelState.IsValid)
            {
                db.testes.Add(teste);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teste);
        }

        // GET: Teste/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teste teste = db.testes.Find(id);
            if (teste == null)
            {
                return HttpNotFound();
            }
            return View(teste);
        }

        // POST: Teste/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,texto,numero,datahora")] teste teste)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teste).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teste);
        }

        // GET: Teste/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teste teste = db.testes.Find(id);
            if (teste == null)
            {
                return HttpNotFound();
            }
            return View(teste);
        }

        // POST: Teste/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            teste teste = db.testes.Find(id);
            db.testes.Remove(teste);
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
