using Microsoft.EntityFrameworkCore;
using RespositoryPatternWithUOW.Core;
using RespositoryPatternWithUOW.Core.Interfaces;
using RespositoryPatternWithUOW.EF;
using RespositoryPatternWithUOW.EF.Respositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//Add Db servicse
builder.Services.AddDbContext<ApplicationDbContext>(options=>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    b=> b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));


//builder.Services.AddTransient(typeof(IBaseRespository<>), typeof(BaseRespository<>));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
