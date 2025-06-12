namespace Fiotec.Boletos.Domain.Entities
{
    public class Faturamento
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public Cliente Cliente { get; set; }
        public ICollection<Boleto> Boletos { get; set; } = new List<Boleto>();
        public ICollection<Historico> Historicos { get; set; } = new List<Historico>();

        public Faturamento(DateTime data, decimal valor, Cliente cliente)
        {
            Data = data;
            Valor = valor;
            Cliente = cliente;
        }

        public Faturamento() { }
    }
}
