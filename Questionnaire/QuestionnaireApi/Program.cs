using Common.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QuestionnaireApi.Data;
using QuestionnaireApi.Repositories;
using QuestionnaireApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = builder.Configuration["Auth0Settings:Authority"];
    options.Audience = builder.Configuration["Auth0Settings:Audience"];
});

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionString")));

builder.Services.AddTransient<IQuestionnaireService, QuestionnaireService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IQuestionnaireRepository, QuestionnaireRepository>();

builder.Services.AddTransient<IQuestionnaireRepository, QuestionnaireRepository>();

builder.Services.Configure<Auth0Settings>(builder.Configuration.GetSection("Auth0Settings"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();

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
