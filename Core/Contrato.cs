using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public abstract class ContratoDeTrabalho
    {
        public Dictionary<Taxa, decimal> Taxas { get; private set; }
        public Dictionary<Beneficio, decimal> Beneficios { get; private set; }
        
        public decimal HorasTrabalhadas { get; set; }
        public decimal SalarioBruto { get; set; }

        public ContratoDeTrabalho(decimal salarioBruto, decimal horasTrabalhadas)
        {
            SalarioBruto = salarioBruto;
            HorasTrabalhadas = horasTrabalhadas;
            Taxas = new Dictionary<Taxa, decimal>();
            Beneficios = new Dictionary<Beneficio, decimal>();
        }

        public virtual void AdicionarTaxa(Taxa taxa, decimal valor)
        {
            if(!Taxas.ContainsKey(taxa))
                Taxas.Add(taxa, valor);
        }

        public virtual void AdicionarBeneficio(Beneficio beneficio, decimal valor)
        {
            if(!Beneficios.ContainsKey(beneficio))
                Beneficios.Add(beneficio, valor);
        }

        public decimal calcularSalarioLiquido()
        {
            return SalarioBruto - calcularTotalDeTaxas();
        }

        public decimal calcularSalarioLiquidoComBeneficios()
        {
            return (SalarioBruto + calcularTotalDeBeneficios()) - calcularTotalDeTaxas();
        }

        protected decimal getValorDescontadoDoSalario(decimal percentual)
        {
            return (SalarioBruto * (percentual / 100));
        }

        public virtual decimal getTotalPercentuaisDeTaxas()
        {
            return (from d in Taxas.Values select d).Sum();
        }

        public abstract decimal calcularTotalDeTaxas();

        public abstract decimal calcularTotalDeBeneficios();

        public abstract decimal calcularValorHora();

        public virtual decimal getPercentualDoImposto(Taxa taxa)
        {
            return Taxas[taxa];
        }
    }
}
