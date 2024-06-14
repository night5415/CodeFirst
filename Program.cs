using Code_First.Contexts;
using Code_First.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var automotiveConnectionString = builder.Configuration.GetConnectionString("AutomotiveConnectionString");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<CarContext>(o=> 
    o.UseSqlServer(automotiveConnectionString)
);

builder.Services.AddScoped<ICarService, CarService>();

var app = builder.Build();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();

 