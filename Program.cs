using Mottu.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuração da conexão com o Oracle
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));

// Adicionando os serviços necessários para o controller
builder.Services.AddControllers();

// Adicionando o Swagger para a documentação da API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Mottu API",
        Version = "v1",
        Description = "API para gestão de motos, filiais, vagas de estacionamento e movimentações."
    });

    // Geração de XML de comentários de documentação (opcional, mas útil)
    var xmlFile = $"{System.AppDomain.CurrentDomain.BaseDirectory}/Mottu.xml";
    if (File.Exists(xmlFile))
    {
        c.IncludeXmlComments(xmlFile);
    }
});

var app = builder.Build();

// ✅ Swagger habilitado em todos os ambientes (inclusive produção)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mottu API v1");
    c.RoutePrefix = string.Empty; // Acessível em "/"
});

app.UseAuthorization();
app.MapControllers();

app.Run();