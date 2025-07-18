using Asp.Versioning;
using Asp.Versioning.Builder;
using Fiotec.Boletos.Application.Services.Interfaces;

namespace Fiotec.Boletos.API.Routes
{
    public static class FaturamentosRoute
    {
        public static void MapFaturamentosRoutes(IEndpointRouteBuilder routes)
        {
            ApiVersionSet versionSet = routes.NewApiVersionSet()
                    .HasApiVersion(new ApiVersion(1))
                    .ReportApiVersions()
                    .Build();

            var faturamentos = routes.MapGroup("/api/v{apiVersion:apiVersion}/faturamentos")
            .WithTags("Faturamentos")
            .WithApiVersionSet(versionSet);

            faturamentos.MapGet("/obter/{id:int}", async (int id, IFaturamentoService faturamentoService) =>
            {
                var faturamento = await faturamentoService.ObterFaturamentoPorIdAsync(id);
                if (faturamento == null)
                    return Results.NotFound();

                return Results.Ok(faturamento);
            });

        }
    }
}
