using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApi;
using WebApi.Models;
using Npgsql;

namespace WebCRUDMVCSQL.Controllers
{
    public class ProductsController : Controller
    {
        // SALVAR PRODUTO //
        [HttpPost ("/saveproduct")]
       public static async Task <Product> SaveProduct ([FromBody]Product product)
        {
             Product  produto = product;

            using (var db = new BancoDeDados()) 
            {
                db.Products.Add(produto);
                await db.SaveChangesAsync();
            } 
             using (var dbpg = new bancoGres()) 
            {
                dbpg.Products.Add(produto);
                await dbpg.SaveChangesAsync();
            } 
            return produto;
        }

        // RECEBER PRODUTO //
        [HttpGet ("/getproduct/{Id}")]
       public static async Task <Product> GetProduct ([FromRoute]int Id)
        {
             Product  product = new Product();
            using (var db = new BancoDeDados()) 
            {
                product = db.Products.Find(Id);
                db.Products.Update(product);
                await db.SaveChangesAsync();
            }
            using (var dbpg = new bancoGres()) 
            {
                product = dbpg.Products.Find(Id);
                dbpg.Products.Update(product);
                await dbpg.SaveChangesAsync();
            }
            return product;
        }

        // EDITAR PRODUTO //
        [HttpPut ("/editproduct")]
       public static async Task<String> EditProduct ([FromBody]Product product)
        {
            using (var db = new BancoDeDados()) 
            {
               var products = new Product();
                db.Products.Update(product);
                await db.SaveChangesAsync();
            } 
            using (var dbpg = new bancoGres()) 
            {
               var products = new Product();
                dbpg.Products.Update(product);
                await dbpg.SaveChangesAsync();
            } 
            return "Produto editado com sucesso!";
        }

        // DELETAR PRODUTO //
        [HttpDelete ("/deleteproduct/{Id}")]
       public static async Task<string> DeleteProduct ([FromRoute]int Id)
        {   
            using (var db = new BancoDeDados()) 
            {
                Product product = db.Products.Find(Id);
                db.Products.Remove(product);
                db.SaveChanges();
            }
            using (var dbpg = new bancoGres()) 
            {
                Product product = dbpg.Products.Find(Id);
                dbpg.Products.Remove(product);
                dbpg.SaveChanges();
            }
            return "Produto deletado com sucesso!";
        }

    }
}
