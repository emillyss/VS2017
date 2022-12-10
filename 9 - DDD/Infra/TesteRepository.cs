using Domain;
using Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Infra
{
    public class TesteRepository : ITesteRepository
    {
        private ModelEF db = new ModelEF();

        public void Alteracao(int id, teste teste)
        {
            db.Entry(teste).State = EntityState.Modified;
            db.SaveChanges();
        }

        public teste Detalhe(int id)
        {
            return db.testes.Find(id);
        }

        public void Exclusao(int id)
        {
            teste teste = db.testes.Find(id);
            if (teste == null)
            {
                return;
            }
            db.testes.Remove(teste);
            db.SaveChanges();
        }

        public void Insercao(teste teste)
        {
            db.testes.Add(teste);
            db.SaveChanges();
        }

        public IEnumerable<teste> Leitura()
        {
            return db.testes.ToList();
        }

        private bool testeExists(int id)
        {
            return db.testes.Count(e => e.id == id) > 0;
        }
    }
}
