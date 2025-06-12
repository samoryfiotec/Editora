namespace Fiotec.Boletos.Domain.Entities
{
    public class Historico
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public string Observacao { get; set; }
        public DateTime DataInclusao { get; set; }
        public int FaturamentoId { get; set; }
        public Faturamento Faturamento { get; set; }

        public Historico(Status status, string observacao, DateTime dataInclusao, Faturamento faturamento)
        {
            Status = status;
            Observacao = observacao;
            DataInclusao = dataInclusao;
            Faturamento = faturamento;
            FaturamentoId = faturamento.Id;
        }

        public Historico() { }
    }
}
