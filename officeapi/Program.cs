using Microsoft.EntityFrameworkCore;
using officeapi.Models;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<officeContext>(db => db.UseSqlServer(builder.Configuration.GetConnectionString("AppCon")));


builder.Services.AddSwaggerGen();
builder.Services.AddCors(cors => cors.AddPolicy("MyPolicy", builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));
//builder.Services.AddDbContext<officeContext>(o =>
//{
//    o.UseSqlServer(builder.Configuration.GetConnectionString("AppCon"));
//});

var app = builder.Build();
app.UseCors("MyPolicy");
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
