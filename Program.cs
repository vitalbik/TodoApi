using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddDbContext<TodoContext>(opt =>
    opt.UseInMemoryDatabase("TodoList"));

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

app.Run();