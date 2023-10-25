using CalculodeSegurodeVeiculos.Models;
using CalculodeSegurodeVeiculos.Services;

namespace CalculodeSegurodeVeiculos.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCalcularSeguro()
        {
            // Configuração
            var servico = new SeguroService();
            var veiculo = new Veiculo()
            {
                Valor = 10000M
            };

            // Ação
            var resultado = servico.CalcularSeguro(veiculo);

            // Verificação
            Assert.That(resultado, Is.EqualTo(1287.5M));
        }
    }
}