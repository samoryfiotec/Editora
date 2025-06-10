using Fiotec.Boleto.Domain.Entities;
using Xunit;

namespace Fiotec.Boleto.Tests.Domain.Entities
{
    public class ContaTests
    {
        [Fact]
        public void Constructor_ShouldSetAllProperties_WithDigitoAgencia()
        {
            // Arrange
            string agencia = "1234";
            string digitoAgencia = "5";
            string numero = "67890";
            string digitoNumero = "1";
            string beneficiario = "Empresa XYZ";

            // Act
            var conta = new Conta(agencia, numero, digitoNumero, beneficiario, digitoAgencia);

            // Assert
            Assert.Equal(agencia, conta.Agencia);
            Assert.Equal(digitoAgencia, conta.DigitoAgencia);
            Assert.Equal(numero, conta.Numero);
            Assert.Equal(digitoNumero, conta.DigitoNumero);
            Assert.Equal(beneficiario, conta.Beneficiario);
        }

        [Fact]
        public void Constructor_ShouldSetAllProperties_WithoutDigitoAgencia()
        {
            // Arrange
            string agencia = "4321";
            string numero = "09876";
            string digitoNumero = "2";
            string beneficiario = "Empresa ABC";

            // Act
            var conta = new Conta(agencia, numero, digitoNumero, beneficiario);

            // Assert
            Assert.Equal(agencia, conta.Agencia);
            Assert.Null(conta.DigitoAgencia);
            Assert.Equal(numero, conta.Numero);
            Assert.Equal(digitoNumero, conta.DigitoNumero);
            Assert.Equal(beneficiario, conta.Beneficiario);
        }

        [Fact]
        public void Properties_ShouldBeSettable()
        {
            // Arrange
            var conta = new Conta("1", "2", "3", "Beneficiario");

            // Act
            conta.Agencia = "9999";
            conta.DigitoAgencia = "8";
            conta.Numero = "55555";
            conta.DigitoNumero = "0";
            conta.Beneficiario = "Novo Beneficiario";

            // Assert
            Assert.Equal("9999", conta.Agencia);
            Assert.Equal("8", conta.DigitoAgencia);
            Assert.Equal("55555", conta.Numero);
            Assert.Equal("0", conta.DigitoNumero);
            Assert.Equal("Novo Beneficiario", conta.Beneficiario);
        }
    }
}
