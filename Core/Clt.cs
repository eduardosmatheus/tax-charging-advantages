using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Clt : Trabalhador
    {
        public Clt(double salarioBruto, double horasTrabalhadas) 
            : base(salarioBruto, horasTrabalhadas)
        {}

        public override double calcularValorLiquido()
        {
            throw new NotImplementedException("Falta implementar.");
        }

        public override double calcularValorLiquidoComBeneficios()
        {
            throw new NotImplementedException("Falta implementar.");
        }
    }
}
