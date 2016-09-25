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
            double valorDasFerias = (salarioBrutoMaisUmTerco - totalDeImpostos) / 12;
            AdicionarBeneficio(Beneficio.Ferias, valorDasFerias);
            return valorDasFerias;
        }

        public double calcularDecimoTerceiro(double totalDeImpostos)
        {
            double decimoTerceiro = (SalarioBruto - totalDeImpostos) / 12;
            AdicionarBeneficio(Beneficio.DecimoTerceiro, decimoTerceiro);
            return decimoTerceiro;
        }
    }
}
