namespace Fiotec.Boleto.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public Endereco Endereco { get; set; }
        public string Email { get; set; }
        public string? Telefone { get; set; }

        public Cliente(int id, string nome, string cpf, Endereco endereco, string email, string? telefone = null)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Endereco = endereco;
            Email = email;
            Telefone = telefone;
        }
    }
}
