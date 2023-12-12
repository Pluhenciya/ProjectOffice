using ProjectOfficeApi.Data;
using ProjectOfficeApi.Models;
using System.Security.Cryptography;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ProjectOfficeContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/user/{login}/{password}", (string login, string password, ProjectOfficeContext context) =>
{
    var user = context.Users.FirstOrDefault(u => u.Login == login.Trim());

    var hashInput = ComputeSha256Hash(password);

    User currentUser = new User();
    if (user != null && Convert.ToHexString(user.Password) == Convert.ToHexString(hashInput))
    {
        currentUser = user;
        return Results.Ok(currentUser);
    }
    else
        return Results.NotFound();
});

/// <summary>
/// Хэширует данные
/// </summary>
/// <param name="rawData">Данные для хеша</param>
/// <returns>Возвращает хеш</returns>
static byte[] ComputeSha256Hash(string rawData)
{
    using (SHA256 sha256Hash = SHA256.Create())
        return sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
}

app.Run();

