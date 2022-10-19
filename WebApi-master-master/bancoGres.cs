using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using WebApi;
using WebApi.Models;
using Npgsql;

namespace WebApi.Models
{
    public class bancoGres : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Database=PostGres;User Id=postgres;Port=5432;Password=1111;");
        public DbSet<Product> Products { get; set; } //Cria tabela.

        internal void Remove(object product)
        {
            throw new NotImplementedException();
        }
    }
}
