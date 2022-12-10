using Domain;
using Services;
using System.Net;
using System.Web.Mvc;

namespace WebApplicationDDD.Controllers
{
    public class TesteController : Controller
    {
        private TesteService _testeService = new TesteService();

        // GET: Teste
        public ActionResult Index()
        {
            return View(_testeService.Leitura());
        }

        // GET: Teste/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teste teste = _testeService.Detalhe(id.Value);
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
                _testeService.Insercao(teste);
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
            teste teste = _testeService.Detalhe(id.Value);
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
                _testeService.Alteracao(teste.id, teste);
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
            teste teste = _testeService.Detalhe(id.Value);
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
            _testeService.Exclusao(id);
            return RedirectToAction("Index");
        }
    }
}
