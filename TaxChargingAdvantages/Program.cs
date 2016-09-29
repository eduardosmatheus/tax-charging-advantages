using System.Collections.Generic;
using Core;
using System;
using System.IO;
using System.Linq;

namespace TaxChargingAdvantages
{
    class Tester
    {
        static void Main(string[] args)
        {
            string path = @"C\\Users\\mathe\\Desktop\\res.txt";
            TextWriter writer = new StreamWriter(path, true);
            Cooperado cooperado = new Cooperado(2700, 160);
            LoadCooperado(cooperado);
            //imprimir(cooperado);
            
            Clt clt = new Clt(1000, 160);
            LoadClt(clt);
            //imprimir(clt);
            Escritor.ImprimirDados(writer, clt);

            Mei empreendedor = new Mei(2100, 160);
            LoadMei(empreendedor);
            //imprimir(empreendedor);
            Escritor.ImprimirDados(writer, empreendedor);

            writer.Flush();
            writer.Dispose();
            writer.Close();
            //File.WriteAllLines(path, writer.);
            Console.Read();
        }

        private static void LoadCooperado(Cooperado cooperado)
        {
            cooperado.AdicionarTaxa(Taxa.INSS, 11);
            cooperado.AdicionarTaxa(Taxa.IRPF, 17);
            cooperado.AdicionarTaxa(Taxa.Mensalidade, 5);
            cooperado.AdicionarBeneficio(Beneficio.AssistenciaMedica, 200m);
        }

        private static void LoadClt(Clt clt)
        {
            clt.AdicionarTaxa(Taxa.INSS, 11);
            clt.AdicionarTaxa(Taxa.IRPF, 25);
            clt.AdicionarBeneficio(Beneficio.AssistenciaMedica, 500m);
            clt.AdicionarBeneficio(Beneficio.ValeRefeicao, 320m);
            clt.AdicionarBeneficio(Beneficio.SeguroDeVida, 80m);
            clt.AdicionarBeneficio(Beneficio.Educacao, 400m);
        }

        private static void LoadMei(Mei mei)
        {
            mei.AdicionarTaxa(Taxa.DAS, 49.9m);
            mei.AdicionarTaxa(Taxa.ISS, 2);
            mei.AdicionarTaxa(Taxa.IRPJ, 12);
            mei.AdicionarBeneficio(Beneficio.ValeRefeicao, 320m);
        }

        static void imprimir(ContratoDeTrabalho trabalhador)
        {
            decimal totalDeTaxas = Math.Round(trabalhador.calcularTotalDeTaxas());
            decimal totalDeBeneficios = trabalhador.calcularTotalDeBeneficios();
            decimal valorHora = trabalhador.calcularValorHora();

            Console.WriteLine("************{0}************", trabalhador.GetType().ToString());
            Console.WriteLine("Taxas: ");
            trabalhador.Taxas.ToList().ForEach(taxa =>
            {
                string dinheiro = taxa.Key.ToString().Equals(Taxa.DAS.ToString()) ? " Reais" : " %";
                Console.WriteLine(">>{0} : {1}{2}", taxa.Key, taxa.Value, dinheiro);
            });

            Console.WriteLine();

            Console.WriteLine("Benefícios: ");
            trabalhador.Beneficios.ToList().ForEach(beneficio =>
            {
                Console.WriteLine(">>{0} : R$ {1}", beneficio.Key, beneficio.Value);
            });
            Console.WriteLine();

            Console.WriteLine("Valor Total de taxas: R$ {0}", totalDeTaxas);
            Console.WriteLine("% Total de taxas: {0}%", trabalhador.getTotalPercentuaisDeTaxas());
            Console.WriteLine("Valor Total de benefícios: R$ {0}", totalDeBeneficios);
            Console.WriteLine("Valor hora: {0}", (valorHora == 0 ? "Não há" : valorHora.ToString()));
            Console.WriteLine("Salário líquido: R$ {0}", trabalhador.calcularSalarioLiquido(totalDeTaxas));
            Console.WriteLine("Salário líquido (com benefícios): R$ {0}", trabalhador.calcularSalarioLiquido(totalDeTaxas, totalDeBeneficios));
            Console.WriteLine();
            Console.WriteLine("**********************");
        }
    }
}
