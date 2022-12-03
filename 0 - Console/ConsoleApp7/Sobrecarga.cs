
namespace ExemploPOO
{
    /// <summary>
    /// Exemplo de Sobrecarga de Métodos
    /// </summary>
    public class Sobrecarga
    {
        public int Lado;

        public int Calcular_Area()
        {
            return Lado * Lado;
        }

        public int Calcular_Area(int quadrado2, int quadrado3)
        {
            return Lado * Lado + quadrado2 + quadrado3;
        }

        public int Calcular_Area(int novo_lado)
        {
            Lado = novo_lado;
            return Lado * Lado;
        }
    }

}
