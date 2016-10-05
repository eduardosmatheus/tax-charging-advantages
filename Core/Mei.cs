using System;

namespace Core
{
    public class Mei : ContratoDeTrabalho
    {
        public Mei(decimal salarioBruto, decimal horasTrabalhadas) : base(salarioBruto, horasTrabalhadas){ }

        public override decimal calcularTotalDeTaxas()
        {
            decimal valorDeIss = getValorDescontadoDoSalario(Taxas[Taxa.ISS]);
            decimal valorIrpj = getValorDescontadoDoSalario(Taxas[Taxa.IRPJ]);
            decimal valorDas = Taxas[Taxa.DAS];

            return valorIrpj + valorDeIss + valorDas;
        }

        public override void AdicionarBeneficio(Beneficio beneficio, decimal valor)
        {
            if (!beneficio.Equals(Beneficio.ValeRefeicao))
                return;
            base.AdicionarBeneficio(beneficio, valor);
        }

        public override void AdicionarTaxa(Taxa taxa, decimal valor)
        {
            if (taxa.Equals(Taxa.DAS) || taxa.Equals(Taxa.IRPJ) 
                || taxa.Equals(Taxa.INSS) || taxa.Equals(Taxa.ISS))
                base.AdicionarTaxa(taxa, valor);
        }

        public override decimal calcularTotalDeBeneficios()
        {
            return Beneficios[Beneficio.ValeRefeicao];
        }

        public override decimal calcularValorHora()
        {
            return SalarioBruto / HorasTrabalhadas;
        }

        public override decimal calcularTotalDosPercentuaisDeTaxas()
        {
            return Taxas[Taxa.ISS] + Taxas[Taxa.IRPJ] + Math.Round(getPercentualDoDAS(), 2);
        }

        public override decimal getPercentualDaTaxa(Taxa taxa)
        {
            if (taxa.Equals(Taxa.DAS))
                return Math.Round(getPercentualDoDAS() * 100, 2);

            return Taxas[taxa];
        }

        private decimal getPercentualDoDAS()
        {
            return Taxas[Taxa.DAS] / SalarioBruto;
        }
    }
}
