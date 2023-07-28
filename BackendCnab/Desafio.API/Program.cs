using AutoMapper;
using Desafio.Application.DI;
using Desafio.Application.Mapper;
using Desafio.Domain.Interfaces.Repositories;
using Desafio.Domain.Interfaces.Services;
using Desafio.Infra.Context;
using Desafio.Infra.Repositories;
using Desafio.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DesafioByCoders.API", Version = "v1" });
});

// ** Injeção de dependência

// Repository
builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IArquivoCnabRepository, ArquivoCnabRepository>();

// Service
builder.Services.AddTransient<IArquivoCnabService, ArquivoCnabService>();

// ** Configuração do EF
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(connectionString));

// ** Configuração do AutoMapper e DI
var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.AddProfile(new DtoToEntity());
    cfg.AddProfile(new EntityToDto());
});

IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var serviceScope = app.Services.CreateScope())
{
    serviceScope.ServiceProvider.GetService<AppDbContext>().Database.Migrate();
}

app.UseHttpsRedirection();

app.UseCors(builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();


