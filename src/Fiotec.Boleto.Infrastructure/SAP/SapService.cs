using Fiotec.Boletos.Infrastructure.SAP.Interface;
using ServiceReference;
using System.ServiceModel;

namespace Fiotec.Boletos.Infrastructure.SAP
{
    public class SapService(ServiceSapClient _serviceSapClient) : ISapService
    {
        public async Task<Retorno_Lista_Clientes> ObterCliente(string codigo)
        {
            try
            {
                await _serviceSapClient.OpenAsync();
                var response = await _serviceSapClient.ZF_LISTA_CLIENTESAsync("", codigo, "", "", "");

                await _serviceSapClient.CloseAsync();
                return response.ZF_LISTA_CLIENTESResult;
            }
            catch (Exception ex)
            {
                if (_serviceSapClient.State == CommunicationState.Faulted)
                    _serviceSapClient.Abort();

                throw new Exception($"Erro ao buscar cliente no SAP: {ex.Message}", ex);
            }
            finally
            {
                if (_serviceSapClient.State == CommunicationState.Opened)
                {
                    await _serviceSapClient.CloseAsync();
                }
            }
        }

    }

}


