using CalculodeSegurodeVeiculos.Repository;
using CalculodeSegurodeVeiculos.Models;
using CalculodeSegurodeVeiculos.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connection = @"Server=DESKTOP-RF5HB5T\SQLEXPRESS;Database=Exame;User Id=sa;Password=Anotherpc-4765;TrustServerCertificate=true";

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));
builder.Services.AddRazorPages();
builder.Services.AddSingleton<ISeguroService, SeguroService>();
builder.Services.AddScoped<ISeguroRepository, SeguroRepository>();
builder.Services.AddScoped<ISeguradoRepository, SeguradoRepository>();
builder.Services.AddScoped<IVeiculoRepository, VeiculoRepository>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();

app.MapControllers();

app.Run();
