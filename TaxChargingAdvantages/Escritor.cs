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
        StreamWriter escritor;

        public Escritor(string caminhoDeEscrita)
        {
            escritor = new StreamWriter(caminhoDeEscrita);
        }

        public void write(Trabalhador trabalhador)
        {
            escritor.WriteLine("************{0}************", trabalhador.GetType().ToString());
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

            double totalDeTaxas = trabalhador.calcularTotalDeTaxas();
            double totalDeBeneficios = trabalhador.calcularTotalDeBeneficios();
            escritor.WriteLine("Valor Total de taxas: R${0}", totalDeTaxas);
            escritor.WriteLine("% Total de taxas: {0}%", trabalhador.getTotalPercentuaisDeTaxas());
            escritor.WriteLine("Valor Total de benefícios: R${0}", totalDeBeneficios);
            escritor.WriteLine("Salário líquido: R${0}", trabalhador.calcularSalarioLiquido(totalDeTaxas));
            escritor.WriteLine("Salário líquido (com benefícios): R${0}", trabalhador.calcularSalarioLiquido(totalDeTaxas, totalDeBeneficios));
            escritor.WriteLine();
            escritor.WriteLine("**********************");
        }
    }
}
