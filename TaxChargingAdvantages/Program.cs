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
            string path = @"Resultado.txt";
            TextWriter writer = new StreamWriter(path, true);
            Cooperado cooperado = new Cooperado(2700, 160);
            LoadCooperado(cooperado);
            Escritor.ImprimirDados(writer, cooperado);

            Clt clt = new Clt(1000, 160);
            LoadClt(clt);
            Escritor.ImprimirDados(writer, clt);

            Mei empreendedor = new Mei(2100, 160);
            LoadMei(empreendedor);
            Escritor.ImprimirDados(writer, empreendedor);

            writer.Flush();
            writer.Dispose();
            writer.Close();
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
    }
}
