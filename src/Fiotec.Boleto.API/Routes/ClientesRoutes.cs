using Asp.Versioning;
using Asp.Versioning.Builder;
using Fiotec.Boletos.Application.Services.Interfaces;

namespace Fiotec.Boletos.API.Routes
{
    public static class ClientesRoutes
    {
        public static void MapClientesRoutes(IEndpointRouteBuilder routes)
        {
            ApiVersionSet versionSet = routes.NewApiVersionSet()
                    .HasApiVersion(new ApiVersion(1))
                    .ReportApiVersions()
                    .Build();

            var clientes = routes.MapGroup("/api/v{apiVersion:apiVersion}/clientes")
            .WithTags("Clientes")
            .WithApiVersionSet(versionSet);

            clientes.MapGet("/obter/{id:int}", async (int id, IClienteService clienteService) =>
            {
                var cliente = await clienteService.ObterPorIdAsync(id);
                if (cliente == null)
                    return Results.NotFound();

                return Results.Ok(cliente);
            });
        }
    }
}
