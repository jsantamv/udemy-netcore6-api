using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Repositories;
using NZWalks.API.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//We create de Connetion to SQL Server
builder.Services.AddDbContext<NZWalksDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("NZWalksConnStr"));
});

builder.Services.AddScoped<IRegionRepository, RegionsRepostory>();
builder.Services.AddScoped<IWalkRepository, WalksRepository>();
builder.Services.AddScoped<IWalkRepository,WalksRepository>();
builder.Services.AddScoped<IWalkDifficultyRepository, WalkDifficultyRepository>();
builder.Services.AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining<Program>());


//Automaper Inject
builder.Services.AddAutoMapper(typeof(Program).Assembly);

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
