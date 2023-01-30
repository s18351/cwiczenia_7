using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApplication1.Model;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                .AddJsonOptions(conf =>
                {
                    conf.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<S18351Context>(opt =>
            {
                opt.UseSqlServer("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s18351;Integrated Security=True;TrustServerCertificate=True");
            });

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