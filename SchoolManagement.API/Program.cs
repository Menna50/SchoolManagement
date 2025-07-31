
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Infrastructure;
using SchoolManagement.Infrastructure.Data;
using SchoolManagement.Service;
using SchoolManagement.Infrastructure.Repositories.Implementations;
using SchoolManagement.Infrastructure.Repositories.Interfaces;
using SchoolManagement.Core;
using System.Reflection;
using SchoolManagement.API.Middlewares;

namespace SchoolManagement.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            });
            builder.Services.AddInfrastructureDependencies();
            builder.Services.AddServiceDependencies();
            builder.Services.AddCoreDependencies();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
           app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
