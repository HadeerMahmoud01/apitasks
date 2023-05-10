
using static System.Net.Mime.MediaTypeNames;

namespace apilab1
{
    public class Program
    {
        public static int count = 0;
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
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
          

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            app.Use(async (context, next) =>
            {
                count++;
                await next(context);
            });
                

              



            app.Run();
        }
    }
}