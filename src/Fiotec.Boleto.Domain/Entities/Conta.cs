namespace Fiotec.Boletos.Domain.Entities
{
    public class Conta
    {
        public string Agencia { get; set; }
        public string? DigitoAgencia { get; set; }
        public string Numero { get; set; }
        public string DigitoNumero { get; set; }
        public string Beneficiario { get; set; }

        public Conta(string agencia, string numero, string digitoNumero, string beneficiario, string? digitoAgencia = null)
        {
            Agencia = agencia;
            Numero = numero;
            DigitoNumero = digitoNumero;
            Beneficiario = beneficiario;
            DigitoAgencia = digitoAgencia;
        }

        public Conta() { }
    }
}
