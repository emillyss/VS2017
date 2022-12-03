
namespace ExemploPOO
{
    /// <summary>
    /// Exemplo de Implementação de Classe Abstrata
    /// </summary>
    public class FormaAbstrataQuadrado: Abstrata
    {
        private int _lado;
        public FormaAbstrataQuadrado(int n) => _lado = n;

        public override int Calcular_Perimetro()
        {
            return _lado * 4;
        }
    }
}
