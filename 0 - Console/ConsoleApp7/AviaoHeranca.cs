
namespace ExemploPOO
{
    /// <summary>
    /// Exemplo de Herança
    /// </summary>
    public class AviaoHeranca : Heranca
    {
        public AviaoHeranca(int num, string nome) : base(nome)
        {
            NumeroDePassageiros = num;
        }
    }
}
