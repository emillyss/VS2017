
namespace ExemploPOO
{
    /// <summary>
    /// Exemplo de Encapsulamento
    /// </summary>
    public class Encapsulamento
    {
        private string _privado { get; set; }
        public string Publico { get; set; }
        protected string Protegida { get; set; }
        internal string Interna { get; set; }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="privado">Parâmetro para atribuição em variável privada</param>
        public Encapsulamento(string privado)
        {
            this._privado = privado;
        }

        /// <summary>
        /// Construtor sem parâmetro adicionando a palavra "Vazio" à variável Privada
        /// </summary>
        public Encapsulamento()
        {
            _privado = "Vazio";
        }
    }

    public class TesteHerancaEncapsulamento : Encapsulamento
    {
        public TesteHerancaEncapsulamento()
        {
            this.Protegida = "Acessa por meio de herança";
        }
    }
}
