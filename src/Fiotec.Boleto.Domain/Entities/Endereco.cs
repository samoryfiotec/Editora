namespace Fiotec.Boletos.Domain.Entities
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string? Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        

        public Endereco(string logradouro, string numero, string cidade, string estado, string cep, string? bairro = null)
        {
            Logradouro = logradouro;
            Numero = numero;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;
            Bairro = bairro;
        }

        public Endereco() { }
    }
}
