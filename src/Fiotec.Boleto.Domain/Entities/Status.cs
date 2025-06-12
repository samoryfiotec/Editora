namespace Fiotec.Boletos.Domain.Entities
{
    public class Status
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public ICollection<Boleto> Boletos { get; set; } = new List<Boleto>();
        public ICollection<Historico> Historicos { get; set; } = new List<Historico>();

        public Status(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        public Status() { }
    }
}
