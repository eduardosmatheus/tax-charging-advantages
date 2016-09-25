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

        public override double calcularTotalDeTaxas()
        {
            double valorDeImpostoDeRenda = SalarioBruto - getValorDescontadoDoSalario(Taxas[Taxa.IRPF]);
            double valorDeInss = SalarioBruto - getValorDescontadoDoSalario(Taxas[Taxa.INSS]);
            return valorDeInss + valorDeImpostoDeRenda;
        }

        public override double calcularTotalDeBeneficios()
        {
            double assistenciaMedica = Beneficios[Beneficio.AssistenciaMedica];
            double educacao = Beneficios[Beneficio.Educacao];
            double seguroDeVida = Beneficios[Beneficio.SeguroDeVida];
            double valeRefeicao = Beneficios[Beneficio.ValeRefeicao];

            return assistenciaMedica + educacao + seguroDeVida + valeRefeicao;
        }

        public double calcularFerias(double totalDeImpostos)
        {
            double salarioBrutoMaisUmTerco = SalarioBruto + (SalarioBruto / 3);
            return (salarioBrutoMaisUmTerco - totalDeImpostos) / 12;
        }

        public double calcularDecimoTerceiro(double totalDeImpostos)
        {
            return (SalarioBruto - totalDeImpostos) / 12;
        }
    }
}
