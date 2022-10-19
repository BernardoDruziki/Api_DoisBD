using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApi;
//using WebApi.Controllers;
using WebApi.Models;
using WebCRUDMVCSQL.Controllers;
using static System.Net.WebRequestMethods;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
        
var app = builder.Build();
app.UseRouting(); 

    app.MapPost("/saveproduct", ProductsController.SaveProduct); // MÉTODO POST //

    app.MapGet("/getproduct/{Id}", ProductsController.GetProduct); // MÉTODO GET //

    app.MapPut("/editproduct", ProductsController.EditProduct); // MÉTODO UPDATE //

    app.MapDelete("/deleteproduct/{Id}", ProductsController.DeleteProduct); // MÉTODO DELETE //


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();




