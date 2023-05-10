

using Microsoft.EntityFrameworkCore;
using tickets.DL;
using tickets.DL.repo.department;
using tickets.DL.repo.ticket;
using ticketsBL.manager;
using ticketsBL.manager.departmentmanager;
using ticketsBL.manager.ticketmanager;

namespace apilab2;

public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



        builder.Services.AddScoped<ITicket, ticketservices>();
        builder.Services.AddScoped<ITicketmanger, ticketmanager>();
        builder.Services.AddScoped<IDepartment,departmentservices>();
        builder.Services.AddScoped<Idepartmentmanager, departmentmanager>();
        
      
        var connectionString = builder.Configuration.GetConnectionString("ConString");
        builder.Services.AddDbContext<context>(options =>
            options.UseSqlServer(connectionString));


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

            app.Run();
        }
    
}