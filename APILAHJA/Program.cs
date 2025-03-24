using APILAHJA.Config;
using APILAHJA.Data;
using APILAHJA.Dso;
using APILAHJA.Models;
using APILAHJA.Repositorys.Share;
using APILAHJA.Services;
using System;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddLogging(); // ≈÷«›… Œœ„«  «·‹ Logging

builder.Services.AddScoped<IInvoiceShareRepository, InvoiceShareRepository>();
builder.Services.AddScoped<InvoiceService>();

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
