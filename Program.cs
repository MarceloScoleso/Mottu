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
    // Adiciona informações sobre a API (opcional, mas útil para documentação)
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Mottu API",
        Version = "v1",
        Description = "API para gestão de motos, filiais, vagas de estacionamento e movimentações."
    });
    // Geração de XML de comentários de documentação
    var xmlFile = $"{System.AppDomain.CurrentDomain.BaseDirectory}/Mottu.xml";
    c.IncludeXmlComments(xmlFile);
});

var app = builder.Build();

// Configuração do ambiente para exibição do Swagger apenas no ambiente de Desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mottu API v1");
        c.RoutePrefix = string.Empty;  // Faz o Swagger ser acessível na raiz do servidor, se desejado
    });
}

app.UseAuthorization();
app.MapControllers();

app.Run();