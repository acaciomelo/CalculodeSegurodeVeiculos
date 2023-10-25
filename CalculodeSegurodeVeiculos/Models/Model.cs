using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalculodeSegurodeVeiculos.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Segurado> Segurados { get; set; }
        public DbSet<Seguro> Seguros { get; set; }
    }

    public class Veiculo
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
    }

    public class Segurado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public int Idade { get; set; }
    }

    public class Seguro
    {
        public int Id { get; set; }
        public decimal ValorSeguro { get; set; }

        // Chave estrangeira para Veiculo
        public int FK_Veiculo { get; set; }
        public Veiculo Veiculo { get; set; }

        // Chave estrangeira para Segurado
        public int FK_Segurado { get; set; }
        public Segurado Segurado { get; set; }
    }
}