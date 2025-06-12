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
                yield return "Boleto n�o pode ser nulo.";
                yield break;
            }

            if (string.IsNullOrWhiteSpace(boleto.Numero))
                yield return "N�mero � obrigat�rio.";

            if (boleto.Valor <= 0)
                yield return "Valor deve ser maior que zero.";

            if (boleto.Vencimento == default)
                yield return "Ter um vencimento � obrigat�rio.";

            if (boleto.Status == null)
                yield return "Estar em um status � obrigat�rio.";

            if (boleto.Emissor == null)
                yield return "Tem o emissor � obrigat�rio.";

            if (boleto.Faturamento == null)
                yield return "Faturamento � obrigat�rio.";
        }
    }
}
