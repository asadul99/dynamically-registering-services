using DynamicServiceRegistration;
using DynamicServiceRegistration.ServiceAttributes;
using DynamicServiceRegistration.Services;

using Microsoft.OpenApi.Writers;

using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var assembly = Assembly.GetExecutingAssembly(); // Change this to your assembly
builder.Services.RegisterOfType<ScopedService>(assembly, ServiceLifetime.Scoped);
builder.Services.RegisterOfType<SingletonService>(assembly, ServiceLifetime.Singleton);
builder.Services.RegisterOfType<TransientService>(assembly, ServiceLifetime.Transient);


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