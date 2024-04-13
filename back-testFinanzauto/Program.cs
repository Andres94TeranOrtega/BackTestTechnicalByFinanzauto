using back_testFinanzauto.Contexts;
using back_testFinanzauto.Models;
using back_testFinanzauto.Services;
using back_testFinanzauto.Tools;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Context>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), options => options.EnableRetryOnFailure());
    });

builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<TeachersService>();
builder.Services.AddScoped<CoursesService>();
builder.Services.AddScoped<QualificationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseMiddleware<ApiKeyAuth>();
app.UseAuthorization();

app.MapControllers();

app.Run();
