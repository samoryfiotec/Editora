using static System.Net.Mime.MediaTypeNames;

namespace Fiotec.Boleto.Domain.Entities
{
    public class Emissor
    {
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Endereco { get; set; }
        public Conta Conta { get; set; }

        public Emissor(string nome, string cnpj, string endereco, Conta conta)
        {
            Nome = nome;
            Cnpj = cnpj;
            Endereco = endereco;
            Conta = conta;
        }
    }
}
