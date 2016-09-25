using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public abstract class Trabalhador : IPagavel
    {
        public IDictionary<Taxa, double> Taxas { get; private set; }
        public IDictionary<Beneficio, double> Beneficios { get; private set; }
        
        public double HorasTrabalhadas { get; set; }
        public double SalarioBruto { get; set; }

        public Trabalhador(double salarioBruto, double horasTrabalhadas)
        {
            SalarioBruto = salarioBruto;
            HorasTrabalhadas = horasTrabalhadas;
            Taxas = new Dictionary<Taxa, double>();
            Beneficios = new Dictionary<Beneficio, double>();
        }

        public void AdicionarTaxa(Taxa taxa, double valor)
        {
            Taxas.Add(taxa, valor);
        }

        public void AdicionarBeneficio(Beneficio beneficio, double valor)
        {
            Beneficios.Add(beneficio, valor);
        }

        public double calcularSalarioLiquido(double totalDeImpostos)
        {
            return SalarioBruto - totalDeImpostos;
        }

        public double calcularSalarioLiquido(double totalDeImpostos, double totalDeBeneficios)
        {
            return (SalarioBruto + totalDeBeneficios) - totalDeImpostos;
        }

        public abstract double calcularTotalDeTaxas();

        public abstract double calcularTotalDeBeneficios();

        /**
         * Retorna o valor do salário bruto descontado de um percentual recebido.
         */
        protected double getValorDescontadoDoSalario(double percentual)
        {
            return (SalarioBruto * (percentual / 100));
        }

        public virtual double getTotalPercentuaisDeTaxas()
        {
            return (from d in Taxas.Values select d).Sum();
        }

        public virtual double calcularValorHora()
        {
            return 0;
        }
    }
}
