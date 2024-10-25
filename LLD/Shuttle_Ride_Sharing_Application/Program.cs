using Shuttle_Ride_Sharing_Application.Repositories;
using Shuttle_Ride_Sharing_Application.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var costPerKm = 0.75;
        //builder.Services.AddSingleton(costPerKm);

        // Register repositories
        builder.Services.AddSingleton<IRideRepository, RideRepository>();
        //builder.Services.AddSingleton<IDriverRepository, DriverRepository>();
       // builder.Services.AddSingleton<IRiderRepository, RiderRepository>();
        builder.Services.AddSingleton<ICabRepository, CabRepository>();

        // Register services
        builder.Services.AddTransient<IRideService, RideService>();
        //builder.Services.AddTransient<IDriverService, DriverService>();
        //builder.Services.AddTransient<IRiderService, RiderService>();
        builder.Services.AddTransient<IBillingService, BillingService>(sp => new BillingService(costPerKm));

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
    }
}
