using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Clt : ContratoDeTrabalho
    {
        public Clt(decimal salarioBruto, decimal horasTrabalhadas) 
            : base(salarioBruto, horasTrabalhadas)
        {}

        public override void AdicionarBeneficio(Beneficio beneficio, decimal valor)
        {
            if(beneficio.Equals(Beneficio.AssistenciaMedica)
                || beneficio.Equals(Beneficio.DecimoTerceiro)
                || beneficio.Equals(Beneficio.Educacao) 
                || beneficio.Equals(Beneficio.Ferias)
                || beneficio.Equals(Beneficio.SeguroDeVida) 
                || beneficio.Equals(Beneficio.ValeRefeicao))
            {
                base.AdicionarBeneficio(beneficio, valor);
            }
        }

        public override void AdicionarTaxa(Taxa taxa, decimal valor)
        {
            if(taxa.Equals(Taxa.INSS) || taxa.Equals(Taxa.IRPF))
                base.AdicionarTaxa(taxa, valor);
        }

        public override decimal calcularTotalDeTaxas()
        {
            decimal valorDeImpostoDeRenda = getValorDescontadoDoSalario(Taxas[Taxa.IRPF]);
            decimal valorDeInss = getValorDescontadoDoSalario(Taxas[Taxa.INSS]);
            return valorDeInss + valorDeImpostoDeRenda;
        }

        public override decimal calcularTotalDeBeneficios()
        {
            decimal assistenciaMedica = Beneficios[Beneficio.AssistenciaMedica];
            decimal educacao = Beneficios[Beneficio.Educacao];
            decimal seguroDeVida = Beneficios[Beneficio.SeguroDeVida];
            decimal valeRefeicao = Beneficios[Beneficio.ValeRefeicao];
            decimal decimoTerceiro = calcularDecimoTerceiro();
            decimal ferias = calcularFerias();
            return (assistenciaMedica + educacao + seguroDeVida + valeRefeicao) + Math.Ceiling(decimoTerceiro + ferias);
        }

        private decimal calcularFerias()
        {
            decimal salarioBrutoMaisUmTerco = Math.Round(SalarioBruto + (SalarioBruto / 3), 2);
            decimal valorDasFerias = Math.Round((salarioBrutoMaisUmTerco - calcularTotalDeTaxas()) / 12, 2);
            AdicionarBeneficio(Beneficio.Ferias, valorDasFerias);
            return valorDasFerias;
        }

        private decimal calcularDecimoTerceiro()
        {
            decimal decimoTerceiro = Math.Round((SalarioBruto - calcularTotalDeTaxas()) / 12, 2);
            AdicionarBeneficio(Beneficio.DecimoTerceiro, decimoTerceiro);
            return decimoTerceiro;
        }

        public override decimal calcularValorHora()
        {
            return 0;
        }
    }
}
