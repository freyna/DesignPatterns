using DesignPattern.Models.Models;
using DesignPattern.Repository;
using DesignPatternASP.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tools.Earn;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// De esta manera estamos indicando que podemos inyectar el servicio para consumirlo en cualquier constructor
var configuration = builder.Configuration;

builder.Services.Configure<MyConfig>(builder.Configuration.GetSection("MyConfig"));

//Inyección de dependencias
//AddTransient indica que siempre habrá una nueva instancia cuando se solicite.
builder.Services.AddTransient((x) =>
{
    return new LocalEarnFactory(builder.Configuration.GetSection("MyConfig").GetValue<decimal>("LocalPercentage"));
});

builder.Services.AddTransient((x) =>
{
    return new ForeignEarnFactory(
        builder.Configuration.GetSection("MyConfig").GetValue<decimal>("ForeignPorcentage"),
        builder.Configuration.GetSection("MyConfig").GetValue<decimal>("Extra")
        );
});

builder.Services.AddDbContext<DesignPatternContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("RepositoryConnection"));
});

//AddScoped indica que habrá una única instancia por controlador.
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
