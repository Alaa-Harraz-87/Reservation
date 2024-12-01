using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Reservation.Core.Interfaces;
using Reservation.Core.Services.Impelmentation;
using Reservation.Core.Services.Interfaces;
using Reservation.InfraStructure;
using Reservation.InfraStructure.Repositories;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();


//builder.Services.AddDbContext<ReservationContext>(options =>
//{
//    options.UseInMemoryDatabase("ReservationDB");
//});


builder.Services.AddDbContext<ReservationContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();



using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ReservationContext>();
    if (app.Environment.IsDevelopment())
    {
        context.Database.Migrate();
    }
}

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
