using Asp.Versioning;
using Asp.Versioning.Builder;
using Fiotec.Boletos.Application.Services;
using Fiotec.Boletos.Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Fiotec.Boletos.API
{
    public class Routes
    {
        public static void MapRoutes(IEndpointRouteBuilder app)
        {
            ApiVersionSet versionSet = app.NewApiVersionSet()
                    .HasApiVersion(new ApiVersion(1))
                    .ReportApiVersions()
                    .Build();

            var faturamentoMap = app.MapGroup("/api/faturamento")
                .WithTags("Faturamento");
                //.AddEndpointFilterFactory((factoryContext, next) =>
                //{
                //    return async context =>
                //    {
                //        var validator = context.HttpContext.RequestServices.GetRequiredService<IValidator<Faturamento>>();
                //        var filter = new ValidationFilter<Faturamento>(validator);
                //        return await filter.InvokeAsync(context, next);
                //    };
                //});

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

            var boletoMap = app.MapGroup("/api/boleto")
                .WithTags("Boleto");

            boletoMap.MapGet("/", static async ([FromServices] BoletoService boletoService) =>
            {
                var boletos = await boletoService.ObterTodosAsync();
                return Results.Ok(boletos);
            });

            var clienteMap = app.MapGroup("/api/cliente")
                .WithTags("Cliente");

            clienteMap.MapGet("/", async ([FromServices] ClienteService clienteService) =>
            {
                var clientes = await clienteService.ObterTodosAsync();
                return Results.Ok(clientes);
            });

            var historicoMap = app.MapGroup("/api/historico")
                .WithTags("Historico");
        }
    }
}
