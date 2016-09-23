using System;
using System.Collections.Generic;

namespace Core
{
    public abstract class Trabalhador : IAssalariavel
    {
        /**
         * Cada entrada do dicionário deve possuir um Beneficio juntamente a um valor de percentual.
         */
        Dictionary<Taxa, double> Taxas { get; set; }
        /**
         * Cada entrada do dicionário deve possuir uma Taxa juntamente a um valor de percentual.
         */
        Dictionary<Beneficio, double> Beneficios { get; set; }

        public double HorasTrabalhadas { get; set; }
        public double SalarioBruto { get; set; }

        public Trabalhador(double salarioBruto, double horasTrabalhadas)
        {
            SalarioBruto = salarioBruto;
            HorasTrabalhadas = horasTrabalhadas;
            Taxas = new Dictionary<Taxa, double>();
            Beneficios = new Dictionary<Beneficio, double>();
        }

        public virtual double calcularValorLiquido()
        {
            throw new NotImplementedException();
        }

        public virtual double calcularValorLiquidoComBeneficios()
        {
            throw new NotImplementedException();
        }

        public virtual double calcularValorHora()
        {
            throw new NotImplementedException();
        }

        public virtual void AdicionarTaxa(Taxa taxa, double valor)
        {
            Taxas.Add(taxa, valor);
        }

        public virtual void AdicionarBeneficio(Beneficio beneficio, double valor)
        {
            Beneficios.Add(beneficio, valor);
        }
    }
}
