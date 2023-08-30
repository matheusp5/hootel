using Hootel.Rooms.Infrastructure;
using Hootel.Rooms.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddDbContext<DatabaseContext>(opt =>
{
    opt.UseSqlite("Data Source=rooms.db");
});

builder.Services.AddScoped<IRoomsRepository, RoomsRepository>();

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