
using application.Extensions;
using EntityFrameworkCore.extensions;
using EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registers all of our controllers.
builder.Services.AddControllers();

// Registers all of our command handlers and the dispatcher.
builder.Services.RegisterCommandHandlers();
builder.Services.RegisterCommandDispatcher();

// ! DB setup.
builder.Services.AddDbContext<DbContext, EfcDbContext>();
builder.Services.RegisterRepositories();
builder.Services.RegisterUnitOfWork();


var app = builder.Build();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();