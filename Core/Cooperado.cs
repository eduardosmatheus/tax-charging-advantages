using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Cooperado : Trabalhador
    {
        public Cooperado(double salarioBruto, double horasTrabalhadas) : base(salarioBruto, horasTrabalhadas) { }

        public override double calcularValorLiquido()
        {
            return base.calcularValorLiquido();
        }
    }
}
