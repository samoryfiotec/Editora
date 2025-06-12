using System;
using System.Collections.Generic;

namespace Fiotec.Boletos.Domain.Entities
{
    public class BoletoValidator
    {
        public IEnumerable<string> Validate(Boleto boleto)
        {
            if (boleto == null)
            {
                yield return "Boleto não pode ser nulo.";
                yield break;
            }

            if (string.IsNullOrWhiteSpace(boleto.Numero))
                yield return "Número é obrigatório.";

            if (boleto.Valor <= 0)
                yield return "Valor deve ser maior que zero.";

            if (boleto.Vencimento == default)
                yield return "Ter um vencimento é obrigatório.";

            if (boleto.Status == null)
                yield return "Estar em um status é obrigatório.";

            if (boleto.Emissor == null)
                yield return "Tem o emissor é obrigatório.";

            if (boleto.Faturamento == null)
                yield return "Faturamento é obrigatório.";
        }
    }
}
