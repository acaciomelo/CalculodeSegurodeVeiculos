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
            // Configura��o
            var servico = new SeguroService();
            var veiculo = new Veiculo()
            {
                Valor = 10000M
            };

            // A��o
            var resultado = servico.CalcularSeguro(veiculo);

            // Verifica��o
            Assert.That(resultado, Is.EqualTo(1287.5M));
        }
    }
}