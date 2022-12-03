using System;

namespace ExemploPOO
{
    class Program
    {
        static void Main(string[] args)
        {
            //Início do Programa
            Console.WriteLine("Programa exemplo conceitos básicos de POO");

            #region Abstração
            Console.WriteLine("Abstração");
            var Pessoa = new AbstracaoPessoa();
            Pessoa.PrimeiroNome = "Fulano";
            Pessoa.NomesDoMeio = new string[] { "Beltrano" };
            Pessoa.UltimoNome = "da Silva";
            Console.WriteLine(Pessoa.NomeCompletoOficial());
            Console.WriteLine("Citação da Pessoa usando ABNT: " + Pessoa.CitacaoABNT);
            #endregion

            #region Encapsulamento
            Console.WriteLine("Encapsulamento");
            var EncapsulamentoVazio = new Encapsulamento();
            var EncapsulamentoInfo = new Encapsulamento("Info");
            EncapsulamentoInfo.Publico = "Acesso global";
            EncapsulamentoInfo.Interna = "Acesso interno (mesma dll/namespace)";
            #endregion

            #region Herança
            Console.WriteLine("Herança");
            var Carro = new CarroHeranca(5, "Teste Carro");
            var Aviao = new AviaoHeranca(120,"Teste Avião");
            Carro.Acelerar();
            Aviao.Freiar();
            #endregion

            #region Polimorfismo
            Console.WriteLine("Polimorfismo - Interface");
            var Maiscula = new InterfaceMaiuscula("Teste");
            var Minuscula = new InterfaceMinuscula("Teste");
            Maiscula.DizerPalavra();
            Minuscula.DizerPalavra();

            Console.WriteLine("Polimorfismo por sobreposição(overriding)");
            var Quadrado = new FormaAbstrataQuadrado(10);
            var Retangulo = new FormaAbstrataRetangulo(10,5);
            Quadrado.Calcular_Perimetro();
            Retangulo.Calcular_Perimetro();

            Console.WriteLine("Polimorfismo por sobrecarga (overloading)");
            var Sobrecarga = new Sobrecarga();
            Sobrecarga.Lado = 10;
            Console.WriteLine("Sem Parâmetros: " + Sobrecarga.Calcular_Area());
            Console.WriteLine("Um Parâmetro: " + Sobrecarga.Calcular_Area(10));
            Console.WriteLine("Dois Parâmetros: " + Sobrecarga.Calcular_Area(10,10));
            #endregion

            //Fim do programa
            Console.ReadKey();
        }

    }
}
