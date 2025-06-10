namespace Fiotec.Boleto.Domain.Entities
{
    public class Boleto
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public decimal Valor { get; set; }
        public DateTime Vencimento { get; set; }
        public Status Status { get; set; }
        public int FaturamentoId { get; set; }

        public Boleto(int id, string numero, decimal valor, DateTime vencimento, Status status, int faturamentoId)
        {
            Id = id;
            Numero = numero;
            Valor = valor;
            Vencimento = vencimento;
            Status = status;
            FaturamentoId = faturamentoId;
        }
    }
}
