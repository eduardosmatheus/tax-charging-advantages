using System.Collections.Generic;
using Core;
using System;
using System.IO;

namespace TaxChargingAdvantages
{
    class Tester
    {
        static void Main(string[] args)
        {
            Cooperado cooperado = new Cooperado(2700, 160);
            LoadCooperado(cooperado);
            //TO DO: Logar os resultados.

            Clt cltEscravo = new Clt(1000, 160);
            LoadClt(cltEscravo);
            
            //TO DO: Logar os resultados. 

            Mei empreendedor = new Mei(2100, 160);
            LoadMei(empreendedor);
            //TO DO: Logar os resultados.
            Console.Read();
        }

        private static void LoadCooperado(Cooperado cooperado)
        {
            cooperado.AdicionarTaxa(Taxa.INSS, 11);
            cooperado.AdicionarTaxa(Taxa.IRPF, 17);
            cooperado.AdicionarTaxa(Taxa.Mensalidade, 5);
            cooperado.AdicionarBeneficio(Beneficio.AssistenciaMedica, 200d);
        }

        private static void LoadClt(Clt clt)
        {
            clt.AdicionarTaxa(Taxa.INSS, 11);
            clt.AdicionarTaxa(Taxa.IRPF, 25);
            clt.AdicionarBeneficio(Beneficio.AssistenciaMedica, 500d);
            clt.AdicionarBeneficio(Beneficio.ValeRefeicao, 320d);
            clt.AdicionarBeneficio(Beneficio.SeguroDeVida, 80d);
            clt.AdicionarBeneficio(Beneficio.Educacao, 400d);
        }

        private static void LoadMei(Mei mei)
        {
            mei.AdicionarTaxa(Taxa.DAS, 49.9);
            mei.AdicionarBeneficio(Beneficio.ValeRefeicao, 320d);
        }
    }
}
