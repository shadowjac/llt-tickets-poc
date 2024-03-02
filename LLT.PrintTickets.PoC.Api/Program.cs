using LLT.PrintTickets.PoC.Api.Extensions;
using LLT.PrintTickets.PoC.Application;
using LLT.PrintTickets.PoC.Infrastructure;
using LLT.PrintTickets.PoC.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddPersistence(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ApplyMigrations();
// app.SeedData();

app.UseCustomExceptionHandler();

app.MapControllers();

app.UseHttpsRedirection();


app.Run();