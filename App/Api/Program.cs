using Api.Data;
using Api.Repositories.Implementations;
using Api.Repositories.Interfaces;
using Api.UnitsOfWork.Implementations;
using Api.UnitsOfWork.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting(r => r.LowercaseUrls = true);

builder.Services.AddDbContext<DataContext>(c => c.UseSqlServer(builder.Configuration.GetConnectionString("dbConn")));
builder.Services.AddCors(c => c.AddPolicy("myCors", p =>
{
    p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
}));
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped(typeof(IUnitOfWork<>), typeof(GenericUnitOfWork<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("myCors");
app.UseRouting();
app.MapControllers();

app.Run();