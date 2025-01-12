using Application.Handlers.StudentHandler;
using Application.Services;
using Application.Validation;
using FluentValidation.AspNetCore;
using Infrastructure.Data;
using Infrastructure.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);


// Register MediatR
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(GetAllStudentsHandlers).Assembly));


builder.Services.AddControllers();
builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<StudentValidation>());


builder.Services.AddScoped<IStudentServices, StudentServices>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
