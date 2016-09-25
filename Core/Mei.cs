using System;

namespace Core
{
    public class Mei : Trabalhador
    {
        public Mei(decimal salarioBruto, decimal horasTrabalhadas) : base(salarioBruto, horasTrabalhadas){ }

        public override decimal calcularTotalDeTaxas()
        {
            decimal valorDeIss = getValorDescontadoDoSalario(Taxas[Taxa.ISS]);
            decimal valorIrpj = getValorDescontadoDoSalario(Taxas[Taxa.IRPJ]);
            decimal valorDas = Taxas[Taxa.DAS];

            return valorIrpj + valorDeIss + valorDas;
        }

        public override decimal calcularTotalDeBeneficios()
        {
            return Beneficios[Beneficio.ValeRefeicao];
        }

        public override decimal calcularValorHora()
        {
            return SalarioBruto / HorasTrabalhadas;
        }

        public new decimal getTotalPercentuaisDeTaxas()
        {
            decimal percentualDaDas = Taxas[Taxa.DAS] / SalarioBruto;
            return Taxas[Taxa.ISS] + Taxas[Taxa.IRPJ] + percentualDaDas;
        }
    }
}
