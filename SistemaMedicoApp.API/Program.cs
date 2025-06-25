
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SistemaMedicoApp.API.Configurations;
using SistemaMedicoApp.Data.Mappings;
using SistemaMedicoApp.Infra.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Registrar o DataContext através do Entity Framework Core
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("SistemaMedicoApp.Infra.Data")));

// Alguns dados do usuário são convertidos da API de Usuários para a tabela de
// pacientes no Sistema Médico.
// Configura o uso de controllers com suporte a JSON e Newtonsoft.Json
// Isso permite o uso de serialização e desserialização de objetos JSON
// além de permitir o tratamento de erros de serialização.
// Em suma: Habilitar a serialização e desserialização de objetos JSON
// (converter API → JSON e JSON → API);
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.Error = (sender, args) =>
        {
            args.ErrorContext.Handled = true;
        };
    });

// Configurações para exibir os endpoints da API em caixa baixa
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddEndpointsApiExplorer();


// Adicionando configurações personalizadas
// para o Swagger, CORS e Injeção de Dependência
SwaggerConfiguration.AddSwaggerConfiguration(builder.Services);

// Configuração do CORS para permitir requisições de um frontend específico
// neste caso, o React com Vite rodando na porta 3000.
CorsConfiguration.AddCorsConfiguration(builder.Services);
// Configuração de Injeção de Dependência para os serviços e repositórios
// do Sistema Médico
DependencyInjectionConfiguration.AddDependencyInjection(builder.Services);

var app = builder.Build();

// Configura o middleware do Swagger
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Configura o Swagger para gerar a documentação da API
app.UseSwagger();
app.UseSwaggerUI();

CorsConfiguration.UseCorsConfiguration(app);

app.UseAuthorization();  
app.MapControllers();
app.Run();

//tornando a classe Program pública (dar visibilidade
//para que outros projetos possam acessar esta classe)
public partial class Program { }
