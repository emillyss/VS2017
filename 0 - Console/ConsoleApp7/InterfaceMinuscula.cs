using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploPOO
{
    /// <summary>
    /// Exemplo de Implementação de Interface
    /// </summary>
    public class InterfaceMinuscula : IInterface
    {
        private string Palavra { get; set; }

        public InterfaceMinuscula(string palavra)
        {
            Palavra = palavra;
        }

        public void DizerPalavra()
        {
            Console.WriteLine(Palavra.ToLower());
        }
    }
}
