using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestBackEndBD.Classes
{
    public class Item
    {
        public int Id_Produto { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public int Qtd { get; set; }
        public double Total { get => Valor * Qtd; }
        public double ValorTotalCompra()
        {
            return this.Valor * this.Qtd;
        }
    }
}