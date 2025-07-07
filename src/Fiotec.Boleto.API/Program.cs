using Fiotec.Boletos.API;
using Fiotec.Boletos.Application.Services;
using Fiotec.Boletos.Domain.Entities;
using Fiotec.Boletos.Domain.Validation;
using Fiotec.Boletos.Infrastructure.Data;
using Fiotec.Boletos.Infrastructure.Data.Interfaces;
using Fiotec.Boletos.Infrastructure.Repositories;
using Fiotec.Boletos.Infrastructure.Repositories.Interfaces;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<BoletoService>();
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<FaturamentoService>();
builder.Services.AddScoped<IDbConnectionFactory, DapperContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IValidator<Faturamento>, FaturamentoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<FaturamentoValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

Routes.MapRoutes(app);

app.Run();
