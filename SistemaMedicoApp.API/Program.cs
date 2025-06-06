
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SistemaMedicoApp.API.Configurations;
using SistemaMedicoApp.Infra.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Registrar o DataContext
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("SistemaMedicoApp.Infra.Data")));

// Adiciona serviços
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

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", info: new OpenApiInfo
    {
        Title = "SistemaMedicoApp",
        Version = "v1"
    });
});

// Adicionando configurações personalizadas
SwaggerConfiguration.AddSwaggerConfiguration(builder.Services);
CorsConfiguration.AddCorsConfiguration(builder.Services);
DependencyInjectionConfiguration.AddDependencyInjection(builder.Services);

var app = builder.Build();

// Configura o middleware do Swagger
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI();

CorsConfiguration.UseCorsConfiguration(app);

app.UseAuthorization();  
app.MapControllers();
app.Run();

//tornando a classe Program pública (dar visibilidade
//para que outros projetos possam acessar esta classe)
public partial class Program { }
