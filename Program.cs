using ControleEstoqueAPI.Data;
using ControleEstoqueAPI.Repositories;
using ControleEstoqueAPI.Services;
using DinkToPdf.Contracts;
using DinkToPdf;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using BaselineTypeDiscovery;
using ControleEstoqueAPI.Helpers;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(Program));

// Repositories
builder.Services.AddScoped<IFornecedorRepository, FornecedorRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IEntradaEstoqueRepository, EntradaEstoqueRepository>();
builder.Services.AddScoped<ISaidaEstoqueRepository, SaidaEstoqueRepository>();

// Services
builder.Services.AddScoped<IFornecedorService, FornecedorService>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IEntradaEstoqueService, EntradaEstoqueService>();
builder.Services.AddScoped<ISaidaEstoqueService, SaidaEstoqueService>();
builder.Services.AddScoped<IRelatorioService, RelatorioService>();

// Definir cultura para pt-BR
var defaultCulture = new CultureInfo("pt-BR");
CultureInfo.DefaultThreadCurrentCulture = defaultCulture;
CultureInfo.DefaultThreadCurrentUICulture = defaultCulture;

// Carregar a DLL nativa
var context = new ControleEstoqueAPI.Helpers.CustomAssemblyLoadContext();
context.LoadUnmanagedLibrary(Path.Combine(Directory.GetCurrentDirectory(), "DinkToPdfNative", "libwkhtmltox.dll"));

// Registrar o serviço do PDF
builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
builder.Services.AddScoped<IPdfService, PdfService>();


builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
builder.Services.AddScoped<IPdfService, PdfService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
