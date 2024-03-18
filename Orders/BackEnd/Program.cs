
using BackEnd.Database;
using BackEnd.Repository;
using BackEnd.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace BackEnd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            //AddScoped
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IWindowService, WindowService>();
            builder.Services.AddScoped<ISubElementService, SubElementService>();

            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IWindowRepository, WindowRepository>();
            builder.Services.AddScoped<ISubElementRepository, SubElementRepository>();

            //Connection to database
            builder.Services.AddDbContext<DatabaseConnection>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Database"));
            });

            //Cors
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                   builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader());
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            //Exeption handle
            app.UseExceptionHandler(eh => eh.Run(async context =>
            {
                var exception = context.Features.Get<IExceptionHandlerFeature>().Error;
                var response = new { error = exception.Message };
                await context.Response.WriteAsJsonAsync(response);
            }));

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}