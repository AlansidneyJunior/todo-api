using TodoApi.Data;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using TodoApi.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuração do banco
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Ativa o Swagger no modo desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Get all
app.MapGet("/todos", async (AppDbContext db) => await db.Todos.ToListAsync());

// Get by id
app.MapGet("/todos/{id}", async (int id, AppDbContext db) =>
await db.Todos.FindAsync(id) is Todo todo ? Results.Ok(todo) : Results.NotFound());

// Create
app.MapPost("/todos", async (TodoCreateDTO dto, AppDbContext db) =>
{
    var todo = new Todo { Title = dto.Title, Description = dto.Description, Date = dto.Date, Status = dto.Status };
    db.Todos.Add(todo);
    await db.SaveChangesAsync();
    return Results.Created($"/todos/{todo.Id}", todo);
});

// Update
app.MapPut("/todos/{id}", async (int id, TodoCreateDTO dto, AppDbContext db) =>
{
    var todo = await db.Todos.FindAsync(id);
    if (todo == null) return Results.NotFound();
    todo.Title = dto.Title ?? todo.Title;
    todo.Description = dto.Description ?? todo.Description;
    todo.Date = dto.Date != default ? dto.Date : todo.Date;
    todo.Status = dto.Status;
    await db.SaveChangesAsync();
    return Results.NoContent();
});

// Delete
app.MapDelete("/todos/{id}", async (int id, AppDbContext db) =>
{
    var todo = await db.Todos.FindAsync(id);
    if (todo == null) return Results.NotFound();
    db.Todos.Remove(todo);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

// Find — por date, status e title (query params)
app.MapGet("/todos/search", async (DateTime? date, TodoStatus? status, string? title, AppDbContext db) =>
{
    var query = db.Todos.AsQueryable();
    if (date.HasValue) query = query.Where(t => t.Date.Date == date.Value.Date);
    if (status.HasValue) query = query.Where(t => t.Status == status.Value);
    if (!string.IsNullOrEmpty(title)) query = query.Where(t => t.Title.Contains(title));
    var results = await query.ToListAsync();
    return Results.Ok(results);
});

app.Run();
