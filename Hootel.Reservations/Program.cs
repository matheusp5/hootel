using Hootel.Reservations.Infrastructure;
using Hootel.Reservations.Repositories;
using Hootel.Reservations.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddDbContext<DatabaseContext>(opt =>
{
    opt.UseSqlite("Data Source=reservations.db");
});

builder.Services.AddScoped<IReservationRepository, ReservatioRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();