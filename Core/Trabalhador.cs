using System;
using System.Collections.Generic;

namespace Core
{
    public abstract class Trabalhador
    {
        protected IDictionary<Taxa, double> Taxas { get; set; }
        protected IDictionary<Beneficio, double> Beneficios { get; set; }
        
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

        protected double calcularValorLiquido(double totalDeImpostos)
        {
            return SalarioBruto - totalDeImpostos;
        }

        protected double calcularValorLiquido(double totalDeImpostos, double totalDeBeneficios)
        {
            return (SalarioBruto + totalDeBeneficios) - totalDeImpostos;
        }

        public abstract double calcularValorDeImpostos();

        public abstract double calcularBeneficios();

        /**
         * Retorna o valor do salário bruto descontado de um percentual recebido.
         */
        protected double getValorDescontadoDoSalario(double percentual)
        {
            return (SalarioBruto * (percentual / 100));
        }
    }
}
