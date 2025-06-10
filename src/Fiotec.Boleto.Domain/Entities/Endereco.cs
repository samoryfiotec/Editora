namespace Fiotec.Boleto.Domain.Entities
{
        public class Endereco
        {
            public string Logradouro { get; set; }
            public string Numero { get; set; }
            public string? Bairro { get; set; }
            public string Cidade { get; set; }
            public string Estado { get; set; }
            public string Cep { get; set; }
            public int ClienteId { get; set; }

            public Endereco(string logradouro, string numero, string cidade, string estado, string cep, int clienteId, string? bairro = null)
            {
                Logradouro = logradouro;
                Numero = numero;
                Cidade = cidade;
                Estado = estado;
                Cep = cep;
                ClienteId = clienteId;
                Bairro = bairro;
            }
        }
}
