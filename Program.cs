
using DarkBid.Interfaces;
using DarkBid.Services;
using Microsoft.EntityFrameworkCore;

namespace DarkBid
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddRazorPages(); // Optional
            builder.Services.AddDirectoryBrowser();

            builder.Services.AddDbContext<DarkBidContext>(options =>
                options.UseMySql(ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DarkBid"))));

            builder.Services.AddScoped<IAuctionService, AuctionService>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // ✅ CORRECT PLACE to add CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // ✅ Middleware goes after app.Build()
            app.UseCors("AllowAll");

            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseAuthorization();

            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run();

        }
    }
}
