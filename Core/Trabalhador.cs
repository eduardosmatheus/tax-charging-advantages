using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public abstract class Trabalhador
    {
        public Dictionary<Taxa, decimal> Taxas { get; private set; }
        public Dictionary<Beneficio, decimal> Beneficios { get; private set; }
        
        public decimal HorasTrabalhadas { get; set; }
        public decimal SalarioBruto { get; set; }

        public Trabalhador(decimal salarioBruto, decimal horasTrabalhadas)
        {
            SalarioBruto = salarioBruto;
            HorasTrabalhadas = horasTrabalhadas;
            Taxas = new Dictionary<Taxa, decimal>();
            Beneficios = new Dictionary<Beneficio, decimal>();
        }

        public void AdicionarTaxa(Taxa taxa, decimal valor)
        {
            Taxas.Add(taxa, valor);
        }

        public void AdicionarBeneficio(Beneficio beneficio, decimal valor)
        {
            Beneficios.Add(beneficio, valor);
        }

        public decimal calcularSalarioLiquido(decimal totalDeImpostos)
        {
            return SalarioBruto - totalDeImpostos;
        }

        public decimal calcularSalarioLiquido(decimal totalDeImpostos, decimal totalDeBeneficios)
        {
            return (SalarioBruto + totalDeBeneficios) - totalDeImpostos;
        }

        public abstract decimal calcularTotalDeTaxas();

        public abstract decimal calcularTotalDeBeneficios();

        public abstract decimal calcularValorHora();

        /**
         * Retorna o valor do salário bruto descontado de um percentual recebido.
         */
        protected decimal getValorDescontadoDoSalario(decimal percentual)
        {
            return (SalarioBruto * (percentual / 100));
        }

        public virtual decimal getTotalPercentuaisDeTaxas()
        {
            return (from d in Taxas.Values select d).Sum();
        }

    }
}
