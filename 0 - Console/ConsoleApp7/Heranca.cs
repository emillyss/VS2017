using System;

namespace ExemploPOO
{
    /// <summary>
    /// Exemplo de Herança
    /// </summary>
    public class Heranca
    {
        public Heranca(string nome)
        {
            Nome = nome;
        }

        private string Nome { get; set; }
        protected int NumeroDePassageiros { get; set; }

        public void Acelerar()
        {
            Console.WriteLine(Nome + " Acelerando");
        }

        public void Freiar()
        {
            Console.WriteLine(Nome + " Freiando");
        }
    }
}
