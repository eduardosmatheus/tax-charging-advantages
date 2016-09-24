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

        public override double calcularValorDeImpostos()
        {
            double percentualDeInss = 0d;
            Taxas.TryGetValue(Taxa.INSS, out percentualDeInss);
            double percentualDeImpostoDeRenda = 0d;
            Taxas.TryGetValue(Taxa.IRPF, out percentualDeImpostoDeRenda);
            double percentualAdministrativo = 0d;
            Taxas.TryGetValue(Taxa.Mensalidade, out percentualAdministrativo);
            double totalPercentuais = percentualDeInss + percentualDeImpostoDeRenda + percentualAdministrativo;
            Console.WriteLine("Percentuais totalizados: {0}", totalPercentuais);

            double valorDeImpostoDeRenda = getValorDescontadoDoSalario(percentualDeImpostoDeRenda);
            double valorDeInss = getValorDescontadoDoSalario(percentualDeInss);
            double valorDaMensalidade = getValorDescontadoDoSalario(percentualAdministrativo);
            double valorTotalDeImpostos = valorDeInss + valorDeImpostoDeRenda + valorDaMensalidade;
            Console.WriteLine("Valor total de impostos: {0}", valorTotalDeImpostos);
            return valorTotalDeImpostos;
        }

        public override double calcularBeneficios()
        {
            double assistenciaMedica = 0d;
            Beneficios.TryGetValue(Beneficio.AssistenciaMedica, out assistenciaMedica);
            Console.WriteLine("Valor total de beneficios: R${0}", assistenciaMedica);
            return assistenciaMedica;
        }

        public double calcularValorHora()
        {
            return SalarioBruto / HorasTrabalhadas;
        }
    }
}
