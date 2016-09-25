using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Cooperado : Trabalhador
    {
        public Cooperado(decimal salarioBruto, decimal horasTrabalhadas) 
            : base(salarioBruto, horasTrabalhadas) { }

        public override decimal calcularTotalDeTaxas()
        {
            decimal valorDeImpostoDeRenda = getValorDescontadoDoSalario(Taxas[Taxa.IRPF]);
            decimal valorDeInss = getValorDescontadoDoSalario(Taxas[Taxa.INSS]);
            decimal valorDaMensalidade = getValorDescontadoDoSalario(Taxas[Taxa.Mensalidade]);

            return valorDeInss + valorDeImpostoDeRenda + valorDaMensalidade;
        }

        public override decimal calcularTotalDeBeneficios()
        {
            return Beneficios[Beneficio.AssistenciaMedica];
        }

        public override decimal calcularValorHora()
        {
            return SalarioBruto / HorasTrabalhadas;
        }
    }
}
