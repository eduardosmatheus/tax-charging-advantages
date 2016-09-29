using Core;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxChargingAdvantages
{
    class Escritor
    {

        public static void ImprimirDados(TextWriter escritor, ContratoDeTrabalho trabalhador)
        {
            escritor.WriteLine("************ {0} ************", trabalhador.GetType().ToString());
            escritor.WriteLine("Taxas e incidentes: ");
            trabalhador.Taxas.ToList().ForEach(taxa =>
            {
                escritor.WriteLine(">>{0} : {1}", taxa.Key, taxa.Value);
            });
            
            escritor.WriteLine();
            escritor.WriteLine("Benefícios: ");
            trabalhador.Beneficios.ToList().ForEach(beneficio =>
            {
                escritor.WriteLine(">>{0} : R${1}", beneficio.Key, beneficio.Value);
            });

            decimal totalDeTaxas = trabalhador.calcularTotalDeTaxas();
            decimal totalDeBeneficios = trabalhador.calcularTotalDeBeneficios();
            escritor.WriteLine("Valor Total de taxas: R${0}", totalDeTaxas);
            escritor.WriteLine("% Total de taxas: {0}%", trabalhador.getTotalPercentuaisDeTaxas());
            escritor.WriteLine("Valor Total de benefícios: R${0}", totalDeBeneficios);
            decimal valorHora = trabalhador.calcularValorHora();
            escritor.WriteLine("Valor hora: {0}", (valorHora == 0 ? "Não há" : valorHora.ToString()));
            escritor.WriteLine("Salário líquido: R${0}", trabalhador.calcularSalarioLiquido(totalDeTaxas));
            escritor.WriteLine("Salário líquido (com benefícios): R${0}", trabalhador.calcularSalarioLiquido(totalDeTaxas, totalDeBeneficios));
            escritor.WriteLine();
            escritor.WriteLine("**********************");
        }
    }
}
