using Asp.Versioning;
using Asp.Versioning.Builder;
using Fiotec.Boletos.Application.Services.Interfaces;
using Fiotec.Boletos.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Fiotec.Boletos.API.Routes
{
    public static class BoletosRoute
    {
        public static void MapBoletosRoutes(IEndpointRouteBuilder routes)
        {
            ApiVersionSet versionSet = routes.NewApiVersionSet()
                    .HasApiVersion(new ApiVersion(1))
                    .ReportApiVersions()
                    .Build();

            var boletos = routes.MapGroup("/api/v{apiVersion:apiVersion}/boletos")
            .WithTags("Boletos")
            .WithApiVersionSet(versionSet);

            boletos.MapGet("/obter-todos", async ([FromServices] IBoletoService boletoService) =>
            {
                var boletosList = await boletoService.ObterTodosAsync();
                return Results.Ok(boletosList);
            });

            boletos.MapGet("/obter/{id:int}", async (int id, [FromServices] IBoletoService boletoService) =>
            {
                var boleto = await boletoService.ObterBoletoPorIdAsync(id);
                if (boleto == null)
                    return Results.NotFound();

                return Results.Ok(boleto);
            });

            boletos.MapPost("/inserir", static async (IBoletoService boletoService, [FromServices] Boleto boleto) =>
            {
                await boletoService.CriarBoletoAsync(boleto);
                return Results.Created($"/boletos/{boleto.Id}", boleto);
            });
        }
    }
}
