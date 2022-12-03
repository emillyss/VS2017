
namespace ExemploPOO
{
    /// <summary>
    /// Exemplo de Implementação de Classe Abstrata
    /// </summary>
    public class FormaAbstrataRetangulo : Abstrata
    {
        private int _base;
        private int _altura;

        public FormaAbstrataRetangulo(int b, int h)
        {
            _base = b;
            _altura = b;
        }

        public override int Calcular_Perimetro()
        {
            return _base * _altura;
        }
    }
}