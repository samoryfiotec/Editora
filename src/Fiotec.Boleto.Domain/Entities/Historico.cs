namespace Fiotec.Boleto.Domain.Entities
{
    public class Historico
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public string Observacao { get; set; }
        public DateTime DataInclusao { get; set; }
        public int FaturamentoId { get; set; }

        public Historico(int id, Status status, string observacao, DateTime dataInclusao, int faturamentoId)
        {
            Id = id;
            Status = status;
            Observacao = observacao;
            DataInclusao = dataInclusao;
            FaturamentoId = faturamentoId;
        }
    }
}
