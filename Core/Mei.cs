using System;

namespace Core
{
    public class Mei : Trabalhador, IPagavelPorHora
    {
        public Mei(double salarioBruto, double horasTrabalhadas) : base(salarioBruto, horasTrabalhadas){ }

        public override double calcularTotalDeTaxas()
        {
            double valorDeIss = getValorDescontadoDoSalario(Taxas[Taxa.ISS]);
            double valorIrpj = getValorDescontadoDoSalario(Taxas[Taxa.IRPJ]);
            double valorDas = Taxas[Taxa.DAS];

            return valorIrpj + valorDeIss + valorDas;
        }

        public override double calcularTotalDeBeneficios()
        {
            return Beneficios[Beneficio.ValeRefeicao];
        }

        public double calcularValorHora()
        {
            return SalarioBruto / HorasTrabalhadas;
        }

        public new double getTotalPercentuaisDeImpostos()
        {
            double percentualDaDas = Taxas[Taxa.DAS] / SalarioBruto;
            return Taxas[Taxa.ISS] + Taxas[Taxa.IRPJ] + percentualDaDas;
        }
    }
}
