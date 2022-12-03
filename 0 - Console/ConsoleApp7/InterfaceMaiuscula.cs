using System;

namespace ExemploPOO
{
    /// <summary>
    /// Exemplo de Implementação de Interface
    /// </summary>
    public class InterfaceMaiuscula : IInterface
    {
        private string Palavra { get; set; }

        public InterfaceMaiuscula(string palavra)
        {
            Palavra = palavra;
        }

        public void DizerPalavra()
        {
            Console.WriteLine(Palavra.ToUpper());
        }
    }
}
