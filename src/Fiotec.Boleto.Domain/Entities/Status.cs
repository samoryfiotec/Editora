namespace Fiotec.Boleto.Domain.Entities
{
    public class Status
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public Status(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
    }
}
