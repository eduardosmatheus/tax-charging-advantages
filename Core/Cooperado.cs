using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Cooperado : Trabalhador, IPagavelPorHora
    {
        public Cooperado(double salarioBruto, double horasTrabalhadas) : base(salarioBruto, horasTrabalhadas) { }

        public override double calcularTotalDeTaxas()
        {
            double valorDeImpostoDeRenda = getValorDescontadoDoSalario(Taxas[Taxa.IRPF]);
            double valorDeInss = getValorDescontadoDoSalario(Taxas[Taxa.INSS]);
            double valorDaMensalidade = getValorDescontadoDoSalario(Taxas[Taxa.Mensalidade]);

            return valorDeInss + valorDeImpostoDeRenda + valorDaMensalidade;
        }

        public override double calcularTotalDeBeneficios()
        {
            return Beneficios[Beneficio.AssistenciaMedica];
        }

        public double calcularValorHora()
        {
            return SalarioBruto / HorasTrabalhadas;
        }
    }
}
