using Domain;
using Infra;
using Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Services
{
    public class TesteService : ITesteService
    {
        private TesteRepository testeRepository = new TesteRepository();
        public void Alteracao(int id, teste teste)
        {
            testeRepository.Alteracao(id,teste);
        }

        public teste Detalhe(int id)
        {
            return testeRepository.Detalhe(id);
        }

        public void Exclusao(int id)
        {
             testeRepository.Exclusao(id);
        }

        public void Insercao(teste teste)
        {
            testeRepository.Insercao(teste);
        }

        public IEnumerable<teste> Leitura()
        {
            return testeRepository.Leitura();
        }
    }
}
