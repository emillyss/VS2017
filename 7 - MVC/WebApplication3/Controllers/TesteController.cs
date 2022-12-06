using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class TesteController : Controller
    {
        public static List<Teste> Modelo = new List<Teste>();
        // GET: Teste
        public ActionResult Index()
        {
            if (Modelo.Count() == 0)
                for (int i = 0; i < 10; i++)
                {
                    var Aleatorio = new Random(Guid.NewGuid().GetHashCode());
                    Modelo.Add(new Teste
                    {
                        Id = i + 1,
                        TesteDateTime = DateTime.Now.AddDays(Aleatorio.Next(i + 100)),
                        TesteDouble = Aleatorio.Next(i + 100),
                        TesteString = Aleatorio.Next(i + 100).ToString()
                    });
                }
            return View(Modelo);
        }

        // GET: Teste/Details/5
        public ActionResult Details(int id)
        {
            return View(Modelo.FirstOrDefault(x => x.Id == id));
        }

        // GET: Teste/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teste/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Modelo.Add(new Teste
                    {
                        Id = Modelo.Max(x => x.Id) + 1,
                        TesteDateTime = Convert.ToDateTime(collection["TesteDateTime"]),
                        TesteDouble = Convert.ToDouble(collection["TesteDouble"]),
                        TesteString = collection["TesteString"]
                    });
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Teste/Edit/5
        public ActionResult Edit(int id)
        {
            var Escolhido = Modelo.FirstOrDefault(x => x.Id == id);
            return View(Escolhido);
        }

        // POST: Teste/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var Novo = new Teste
                {
                    Id = id,
                    TesteDateTime = Convert.ToDateTime(collection["TesteDateTime"]),
                    TesteDouble = Convert.ToDouble(collection["TesteDouble"]),
                    TesteString = collection["TesteString"]
                };

                Modelo[Modelo.FindIndex(x => x.Id == id)] = Novo;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Teste/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Modelo.FirstOrDefault(x => x.Id == id));
        }

        // POST: Teste/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Modelo.RemoveAt(Modelo.FindIndex(x => x.Id == id));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
