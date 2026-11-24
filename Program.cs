
using Infrastrcuture.AppDBContext;
using Microsoft.EntityFrameworkCore;
using Domain.Interface;
using Infrastrcuture.Repository;
using Microsoft.Identity.Client;
using Infrastructure.Repository;
namespace Web_Site_EC.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddScoped<ICartRepository, CartRepository>();
            builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();



            // Add services to the container.

            builder.Services.AddDbContext<AppDbContext>(options =>
              options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
