using BolsaValores.Business.Core;
using BolsaValores.Business.Interfaces;
using BolsaValores.DataAccess.Data;
using BolsaValores.DataAccess.Interfaces;
using BolsaValores.DataAccess.Persistences.BolsaValores;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<BolsaValoresTestContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("BolsaValores")));


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddTransient<IAccionDAL, AccionDAL>();
builder.Services.AddTransient<IHistorialDAL, HistorialDAL>();
builder.Services.AddTransient<IBitacoraHistorialDAL, BitacoraHistorialDAL>();
builder.Services.AddTransient<IBitacoraErrorDAL, BitacoraErrorDAL>();
builder.Services.AddTransient<IAccionDAL, AccionDAL>();

builder.Services.AddTransient<IBotBL, BotBL>();
builder.Services.AddTransient<IAccionBL, AccionBL>();
builder.Services.AddTransient<IHistorialBL,HistorialBL>();
builder.Services.AddTransient<IBitacoraHistorialBL, BitacoraHistorialBL>();
builder.Services.AddTransient<IBitacoraErrorBL, BitacoraErrorBL>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("default", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();
app.UseCors("default");
app.Run();
