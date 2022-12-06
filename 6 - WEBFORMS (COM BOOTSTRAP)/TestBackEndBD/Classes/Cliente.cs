using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestBackEndBD.Classes
{
    public class Cliente
    {
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public string TextoAtivo { get => Ativo ? "SIM" : "NÃO"; }
        public string NumeroAtivo { get => Ativo ? "1" : "0"; }
        public int Id { get; set; }
    }
}