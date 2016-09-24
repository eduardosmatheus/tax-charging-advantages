using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Clt : Trabalhador
    {
        public Clt(double salarioBruto, double horasTrabalhadas) 
            : base(salarioBruto, horasTrabalhadas)
        {}

        public override double calcularValorDeImpostos()
        {
            double percentualDeInss = 0;
            double percentualDeImpostoDeRenda = 0;
            Taxas.TryGetValue(Taxa.INSS, out percentualDeInss);
            Taxas.TryGetValue(Taxa.IRPF, out percentualDeImpostoDeRenda);
            Console.WriteLine("Percentuais totalizados: {0}", percentualDeInss + percentualDeImpostoDeRenda);

            double valorDeImpostoDeRenda = SalarioBruto - getValorDescontadoDoSalario(percentualDeImpostoDeRenda);
            double valorDeInss = SalarioBruto - getValorDescontadoDoSalario(percentualDeInss);
            return valorDeInss + valorDeImpostoDeRenda;
        }

        public override double calcularBeneficios()
        {
            double assistenciaMedica = 0;
            Beneficios.TryGetValue(Beneficio.AssistenciaMedica, out assistenciaMedica);
            double educacao = 0;
            Beneficios.TryGetValue(Beneficio.Educacao, out educacao);
            double seguroDeVida = 0;
            Beneficios.TryGetValue(Beneficio.SeguroDeVida, out seguroDeVida);
            double valeRefeicao = 0;
            Beneficios.TryGetValue(Beneficio.ValeRefeicao, out valeRefeicao);
            return assistenciaMedica + educacao + seguroDeVida + valeRefeicao;
        }
    }
}
