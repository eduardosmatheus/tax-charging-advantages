using System;

namespace Core
{
    public class Mei : Trabalhador, IPagavelPorHora
    {
        public Mei(double salarioBruto, double horasTrabalhadas) : base(salarioBruto, horasTrabalhadas){ }

        public override double calcularValorDeImpostos()
        {
            double percentualDeIss = 0;
            Taxas.TryGetValue(Taxa.ISS, out percentualDeIss);

            double valorDeIss = getValorDescontadoDoSalario(percentualDeIss);

            double valorDas = 0;
            Taxas.TryGetValue(Taxa.DAS, out valorDas);

            //TO DO: Retornar os percentuais de forma que possa ser escrito em um output de texto. 
            double percentualDaDas = valorDas / SalarioBruto;

            return valorDas + valorDeIss;
        }

        public override double calcularBeneficios()
        {
            double valorDeAlmoco = 0;
            Beneficios.TryGetValue(Beneficio.ValeRefeicao, out valorDeAlmoco);
            return valorDeAlmoco;
        }

        public double calcularValorHora()
        {
            return SalarioBruto / HorasTrabalhadas;
        }
    }
}
