using System;
using System.Collections.Generic;

namespace Fiotec.Boleto.Domain.Entities
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
                yield return "Vencimento é obrigatório.";

            if (boleto.Status == null)
                yield return "Status é obrigatório.";

            if (boleto.FaturamentoId <= 0)
                yield return "FaturamentoId deve ser maior que zero.";
        }
    }
}
