using System;
using AutoMapper;
using Elmasyaf.API.Mapping;
using Microsoft.EntityFrameworkCore;
using Elmasyaf.Infrastructure.Data;
using Elmasyaf.Domain.Interfaces;
using Elmasyaf.Infrastructure.Repositories;
using Elmasyaf.Application.Interfaces;
using Elmasyaf.Application.Services;

namespace Elmasyaf.API
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

            // AutoMapper
            builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());

            // EF Core
            builder.Services.AddDbContext<AppDbContext>(s =>
            {
                s.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
            });

            // Repositories
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            // Application Services
            builder.Services.AddScoped<IApartmentService, ApartmentService>();
            builder.Services.AddScoped<IUserService, UserService>();

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
}

