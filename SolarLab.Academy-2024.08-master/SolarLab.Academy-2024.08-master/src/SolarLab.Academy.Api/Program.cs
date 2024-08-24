using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SolarLab.Academy.AppServices.Repository;
using SolarLab.Academy.AppServices.Services;
using SolarLab.Academy.AppServices.User.Repository;
using SolarLab.Academy.AppServices.User.Service;
using SolarLab.Academy.AppServices.WeatherForecast.Services;
using SolarLab.Academy.DataAccess.Context.Repository;
using SolarLab.Academy.DataAccess.MapProfile;
using SolarLab.Academy.Domain.Advert;
using SolarLab.Academy.Domain.Userss;
using SolarLab.Academy.Infrastructure;
using SolarLab.Academy.Infrastructure.Repository;
using System;
using System.Text.Json.Serialization;

namespace SolarLab.Academy.Api
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
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });



            //  var options = new DbContextOptionsBuilder<BoardDbContext>()
            //.UseInMemoryDatabase(databaseName: "NotesDatabase")
            // .Options;
            //builder.Services.AddTransient<IWeatherForecastService, WeatherForecastService>();
            var mapperConfiguration = new MapperConfiguration(config =>
            {
                config.AddProfile(new AdvertProfile());
            });
            builder.Services.AddSingleton(mapperConfiguration.CreateMapper());
            builder.Services.AddDbContext<BoardDbContext>(options =>
                    options.UseInMemoryDatabase("InMemoryDb"));
            builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddTransient<IAdvertRepository, AdvertRepository>();
            builder.Services.AddTransient<IAdvertService, AdvertService>();
            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddTransient<IUserService, UserService>();




            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<BoardDbContext>();
                SeedData(context); // ?????????? ?????? ?? ?????????
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

            void SeedData(BoardDbContext context)
            {
                if (!context.Adverts.Any())
                {
                    context.Adverts.AddRange(
                        new Advert
                        {
                            Id = new Guid("e5878c94-90eb-47f5-a52f-c1c9e65171cc"),
                            Name = "car sale",
                            Description = " new car for sale .",
                        },
                        new Advert
                        {
                            Id = new Guid("e5178c94-88eb-47f5-a52f-c1c9e65171cc"),
                            Name = "bike sale",
                            Description = " new bike for sale .",
                        }
                    );
                    context.SaveChanges();
                }
                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User
                        {
                            Id = new Guid("e4444c94-90eb-47f5-a52f-c1c9e65171cc"),
                            Name = "Ivan",
                            Surname = " Ivanov",
                            Login="login",
                            Password="password"
                        },
                        new User
                        {
                            Id = new Guid("e5555c94-77eb-47f5-a52f-c1c9e65171cc"),
                            Name = "Dmitri",
                            Surname = "Dmitrov",
                            Login = "login1",
                            Password = "password1"
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
