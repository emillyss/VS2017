using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ApplicationEF;

namespace ApplicationEF.Controllers
{
    public class testesController : ApiController
    {
        private ModelEF db = new ModelEF();

        // GET: api/testes
        public IQueryable<teste> Gettestes()
        {
            return db.testes;
        }

        // GET: api/testes/5
        [ResponseType(typeof(teste))]
        public IHttpActionResult Getteste(int id)
        {
            teste teste = db.testes.Find(id);
            if (teste == null)
            {
                return NotFound();
            }

            return Ok(teste);
        }

        // PUT: api/testes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putteste(int id, teste teste)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != teste.id)
            {
                return BadRequest();
            }

            db.Entry(teste).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!testeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/testes
        [ResponseType(typeof(teste))]
        public IHttpActionResult Postteste(teste teste)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.testes.Add(teste);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = teste.id }, teste);
        }

        // DELETE: api/testes/5
        [ResponseType(typeof(teste))]
        public IHttpActionResult Deleteteste(int id)
        {
            teste teste = db.testes.Find(id);
            if (teste == null)
            {
                return NotFound();
            }

            db.testes.Remove(teste);
            db.SaveChanges();

            return Ok(teste);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool testeExists(int id)
        {
            return db.testes.Count(e => e.id == id) > 0;
        }
    }
}