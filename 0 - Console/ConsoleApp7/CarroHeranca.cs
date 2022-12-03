
namespace ExemploPOO
{
    /// <summary>
    /// Exemplo de Herança
    /// </summary>
    public class CarroHeranca : Heranca
    {
        public CarroHeranca(int num, string nome) : base(nome)
        {
            NumeroDePassageiros = num;
        }
    }
}
