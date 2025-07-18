using Asp.Versioning;
using Fiotec.Boletos.API.Routes;
using Fiotec.Boletos.Application.Services;
using Fiotec.Boletos.Application.Services.Interfaces;
using Fiotec.Boletos.Domain.Entities;
using Fiotec.Boletos.Domain.Validation;
using Fiotec.Boletos.Infrastructure.Data;
using Fiotec.Boletos.Infrastructure.Data.Interfaces;
using Fiotec.Boletos.Infrastructure.Repositories;
using Fiotec.Boletos.Infrastructure.Repositories.Interfaces;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBoletoService, BoletoService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IFaturamentoService, FaturamentoService>();
builder.Services.AddScoped<IDbConnectionFactory, DapperContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IValidator<Faturamento>, FaturamentoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<FaturamentoValidator>();

builder.Services
    .AddApiVersioning(options =>
    {
        options.DefaultApiVersion = new ApiVersion(1);
        options.ApiVersionReader = new UrlSegmentApiVersionReader();
    }).AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'V";
        options.SubstituteApiVersionInUrl = true;
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

FaturamentosRoute.MapFaturamentosRoutes(app);
ClientesRoutes.MapClientesRoutes(app);
BoletosRoute.MapBoletosRoutes(app);


app.Run();
