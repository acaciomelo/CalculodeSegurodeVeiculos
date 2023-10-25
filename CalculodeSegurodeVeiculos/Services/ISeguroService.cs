using CalculodeSegurodeVeiculos.Models;

namespace CalculodeSegurodeVeiculos.Services
{
    public interface ISeguroService
    {
        decimal CalcularSeguro(Veiculo veiculo);
    }

    public class SeguroService : ISeguroService
    {
        public decimal CalcularSeguro(Veiculo veiculo)
        {
            const decimal MARGEM_SEGURANCA = 0.03M;
            const decimal LUCRO = 0.05M;

            decimal taxaDeRisco = (veiculo.Valor * 5) / (2 * veiculo.Valor);
            decimal premioDeRisco = taxaDeRisco * veiculo.Valor;
            decimal premioPuro = premioDeRisco * (1 + MARGEM_SEGURANCA);
            decimal premioComercial = LUCRO * premioPuro;

            return premioComercial;
        }
    }

}
