using Microsoft.EntityFrameworkCore;
using Minimal_Api.Context;
using Minimal_Api.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MinimalContext>(options => 
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapPost("/adicionarCategoria", async (Categoria categoria, MinimalContext db) => {
    db.Categorias?.Add(categoria);
    await db.SaveChangesAsync();

    return Results.Created($"/categorias/{categoria.CategoriaId}", categoria);
}).ExcludeFromDescription(); // não aparece mais na interface do swagger

app.MapGet("/recuperarCategoria", async (MinimalContext db) => {
    return await db.Categorias?.ToListAsync();
});

app.MapPut("/alterarCategoria", async (Categoria categoria, MinimalContext db) => {
    var categorias = db.Categorias.FindAsync(categoria.CategoriaId);

    categorias.Result.Nome = categoria.Nome;

    await db.SaveChangesAsync();

    return Results.Ok();
});

app.MapDelete("/deletarCategoria", async (int id, MinimalContext db) => {
    var categoria = await db.Categorias.FindAsync(id);

    db.Categorias.Remove(categoria);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
