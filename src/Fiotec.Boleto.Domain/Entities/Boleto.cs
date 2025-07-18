namespace Fiotec.Boletos.Domain.Entities
{
    public class Boleto
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public decimal Valor { get; set; }
        public DateTime Vencimento { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public Emissor Emissor { get; set; }
        public Faturamento Faturamento { get; set; }

        public Boleto(string numero, decimal valor, DateTime vencimento, Status status, Emissor emissor, Faturamento faturamento)
        {
            Numero = numero;
            Valor = valor;
            Vencimento = vencimento;
            Status = status;
            StatusId = status.Id;
            Emissor = emissor;
            Faturamento = faturamento;
        }

        public Boleto() { }
    }
}
