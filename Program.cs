using DynamicServiceRegistration;
using DynamicServiceRegistration.ServiceAttributes;

using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var assembly = Assembly.GetExecutingAssembly(); // Change this to your assembly

//Register services dynamically
builder.Services.RegisterServicesWithAttribute<ScopedService>(assembly);
builder.Services.RegisterServicesWithAttribute<SingletonService>(assembly);
builder.Services.RegisterServicesWithAttribute<TransientService>(assembly);


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
