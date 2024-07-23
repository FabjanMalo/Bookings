using Bookings.Api;
using Bookings.Application;
using Bookings.Domain.Bookings;
using Bookings.Infrastructure;
using Bookings.Infrastructure.Bookings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.ConfigureApplicationServices();

builder.Services.ConfigureInfrastructureServices(builder.Configuration);


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

app.MapHub<BookingReserveHub>("/bookingNotification");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
