using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using WebApi;
using WebApi.Models;
using Npgsql;

//Gerenciar e controlar a forma como os dados se comportam por meio das funções.

namespace WebApi.Models
{
    public class BancoDeDados : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost;User Id=sa;password=1111;Database=TesteDeCrud;Trusted_Connection=True;");
        public DbSet<Product> Products { get; set; } //Cria tabela.

        internal void Remove(object product)
        {
            throw new NotImplementedException();
        }
    }

}