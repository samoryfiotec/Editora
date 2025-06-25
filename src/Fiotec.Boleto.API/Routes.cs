using Fiotec.Boletos.Application.Services;
using Fiotec.Boletos.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Fiotec.Boletos.API
{
    public class Routes
    {
        public static void MapRoutes(IEndpointRouteBuilder app)
        {          
            app.MapGet("/", () => "Olá Boletos!");

            var faturamentoMap = app.MapGroup("/api/faturamento")
                .WithTags("Faturamento");

            faturamentoMap.MapGet("/", async ([FromServices] FaturamentoService faturamentoService) =>
            {
                var faturamentos = await faturamentoService.ObterTodosFaturamentosAsync();
                return Results.Ok(faturamentos);
            });

            faturamentoMap.MapGet("/{id:int}", async (FaturamentoService faturamentoService, int id) =>
            {
                var faturamento = await faturamentoService.ObterFaturamentoPorIdAsync(id);
                return faturamento is not null ? Results.Ok(faturamento) : Results.NotFound();
            });

            faturamentoMap.MapPost("/", async (FaturamentoService faturamentoService, Faturamento faturamento) =>
            {
                if (faturamento is null)
                    return Results.BadRequest("Faturamento não pode ser nulo.");

                await faturamentoService.CriarFaturamentoAsync(faturamento);
                return Results.Created($"/api/faturamento/{faturamento.Id}", faturamento);
            });
        }
    }
}
