using System.Linq;

namespace ExemploPOO
{
    /// <summary>
    /// Exemplo de Abstração
    /// </summary>
    public class AbstracaoPessoa
    {
        public string PrimeiroNome { get; set; }
        public string[] NomesDoMeio { get; set; }
        public string UltimoNome { get; set; }

        /// <summary>
        /// Apresenta o nome completo
        /// </summary>
        /// <returns>String com nome</returns>
        public string NomeCompletoOficial()
        {
            string NomeCompleto = PrimeiroNome;

            foreach (var nome in NomesDoMeio)
                NomeCompleto = NomeCompleto + " " + nome;

            NomeCompleto += UltimoNome;
            return NomeCompleto;
        }

        /// <summary>
        /// Citação ABNT no formato SOBRENOME, PrimeiroNome
        /// </summary>
        public string CitacaoABNT { get => $"{UltimoNome.ToUpper()}, {PrimeiroNome}";  }

    }
}
