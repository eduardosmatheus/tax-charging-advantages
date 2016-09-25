﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Clt : Trabalhador
    {
        public Clt(decimal salarioBruto, decimal horasTrabalhadas) 
            : base(salarioBruto, horasTrabalhadas)
        {}

        public override decimal calcularTotalDeTaxas()
        {
            decimal valorDeImpostoDeRenda = getValorDescontadoDoSalario(Taxas[Taxa.IRPF]);
            decimal valorDeInss = getValorDescontadoDoSalario(Taxas[Taxa.INSS]);
            return valorDeInss + valorDeImpostoDeRenda;
        }

        public override decimal calcularTotalDeBeneficios()
        {
            decimal assistenciaMedica = Beneficios[Beneficio.AssistenciaMedica];
            decimal educacao = Beneficios[Beneficio.Educacao];
            decimal seguroDeVida = Beneficios[Beneficio.SeguroDeVida];
            decimal valeRefeicao = Beneficios[Beneficio.ValeRefeicao];
            decimal decimoTerceiro = calcularDecimoTerceiro();
            decimal ferias = calcularFerias();
            return (assistenciaMedica + educacao + seguroDeVida + valeRefeicao) + Math.Ceiling(decimoTerceiro + ferias);
        }

        private decimal calcularFerias()
        {
            decimal salarioBrutoMaisUmTerco = Math.Round(SalarioBruto + (SalarioBruto / 3), 2);
            decimal valorDasFerias = Math.Round((salarioBrutoMaisUmTerco - calcularTotalDeTaxas()) / 12, 2);
            AdicionarBeneficio(Beneficio.Ferias, valorDasFerias);
            return valorDasFerias;
        }

        private decimal calcularDecimoTerceiro()
        {
            decimal decimoTerceiro = Math.Round((SalarioBruto - calcularTotalDeTaxas()) / 12, 2);
            AdicionarBeneficio(Beneficio.DecimoTerceiro, decimoTerceiro);
            return decimoTerceiro;
        }

        public override decimal calcularValorHora()
        {
            return 0;
        }
    }
}
