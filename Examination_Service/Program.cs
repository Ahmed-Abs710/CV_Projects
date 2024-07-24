using Examination_Service;
using Examination_Service.CQRS;
using Examination_Service.CQRS.Commands.Handlers;
using Examination_Service.CQRS.Querys.Handlers;
using Examination_Service.CQRS.Querys.Requests;
using Examination_Service.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCors(o => {
    o.AddPolicy("AllowAll", b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(x=>x.UseSqlServer(builder.Configuration.GetConnectionString("con")));
builder.Services.AddScoped<IMediator,Mediator>();
//builder.Services.AddMediatR(typeof(RegisterUserHandler).Assembly);
builder.Services.AddScoped<ExamService>();
builder.Services.AddScoped<AnswerService>();
builder.Services.AddScoped<QuestionService>();
builder.Services.AddMediatR(typeof(Program).Assembly);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
