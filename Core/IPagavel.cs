using System.Collections.Generic;

namespace Core
{
    public interface IPagavel
    {
        double calcularValorHora();
        double calcularSalarioLiquido(double totalImpostos);
        double calcularSalarioLiquido(double totalImpostos, double totalBeneficios);
    }
}
