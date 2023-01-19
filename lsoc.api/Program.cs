using Lsoc.API.Mapping;
using Lsoc.Core;
using Lsoc.Core.Services;
using Lsoc.Data;
using Lsoc.Services.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(LsocMappingProfile));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IPostsService, PostService>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen();

// Add the DB connection to the container.
builder.Services.AddDbContext<LsocDbContext>(
    options => options.UseSqlite(
        builder.Configuration.GetConnectionString("Default"),
        x => x.MigrationsAssembly("Lsoc.Data")
        )
    );

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<LsocDbContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseCors();

app.Run();
