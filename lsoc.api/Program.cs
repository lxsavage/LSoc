using Lsoc.API.Mapping;
using Lsoc.Core;
using Lsoc.Core.Services;
using Lsoc.Data;
using Lsoc.Services.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(LsocMappingProfile));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IPostsService, PostsService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add the DB connection to the container.
builder.Services.AddDbContext<LsocDbContext>(
    options => options.UseSqlite(
        builder.Configuration.GetConnectionString("Default"),
        x => x.MigrationsAssembly("Lsoc.Data")
        )
    );

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
