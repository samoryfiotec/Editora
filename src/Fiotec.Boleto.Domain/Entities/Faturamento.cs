namespace Fiotec.Boleto.Domain.Entities
{
    public class Faturamento
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public int ClienteId { get; set; }

        public Faturamento(int id, DateTime data, decimal valor, int clienteId)
        {
            Id = id;
            Data = data;
            Valor = valor;
            ClienteId = clienteId;
        }
    }
}
