using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using WebApi;
using WebApi.Models;
namespace WebApi;

[Table("Products")]
public class Product
{
    [Column("Id")]
    public int Id { get; set; }
    [Column("Name")]
    public string Name { get; set; }
}


