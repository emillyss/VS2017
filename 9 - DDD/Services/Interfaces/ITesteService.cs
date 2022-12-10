using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    interface ITesteService
    {
        IEnumerable<teste> Leitura();
        teste Detalhe(int id);
        void Insercao(teste teste);
        void Exclusao(int id);
        void Alteracao(int id, teste teste);
    }
}
