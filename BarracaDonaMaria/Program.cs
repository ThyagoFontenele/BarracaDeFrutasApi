using BarracaDonaMaria.Domain.Repositories;
using BarracaDonaMaria.Infrastructure.Repositories;
using BarracaDonaMaria.Middleware;
using System.Net;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(j => {
    j.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    j.JsonSerializerOptions.DefaultIgnoreCondition =  JsonIgnoreCondition.WhenWritingNull;
});

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IItemPedidoRepository, ItemPedidoRepository>();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseMiddleware<Middleware>();

app.MapControllers();

app.Run();