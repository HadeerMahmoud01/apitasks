using Microsoft.EntityFrameworkCore;
using System.Data;

namespace tickets.DL;
public class context : DbContext
{
    public DbSet<Ticket> Ticket { get; set; }
    public DbSet<Developer> developers { get; set; }
    public DbSet<Department> Departments { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public context(DbContextOptions<context> options) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //var tickets = new List<Ticket>
        //{ new Ticket { Id = 1,Description="ticket discription",Title="ticket title"},
        //new Ticket { Id = 2,Description="ticket discription",Title="ticket title"},
        //new Ticket { Id = 3,Description="ticket discription",Title="ticket title"},
        //new Ticket { Id = 4,Description="ticket discription",Title="ticket title"},
        //new Ticket { Id = 5,Description="ticket discription",Title="ticket title"}

        //};
        //var developers = new List<Developer>
        //{
        //    new Developer {Id=1,Name="ali"},
        //    new Developer {Id=2,Name="ahmed"},
        //    new Developer {Id=3,Name="sara"},
        //    new Developer {Id=4,Name="aya"},
        //    new Developer {Id=5,Name="alyaa"}
        //};
        //var departments = new List<Department>
        //{
        //    new Department {Id=1, Name="ai"},
        //    new Department {Id=2,Name="os"},
        //    new Department {Id=3,Name="pd"},
        //    new Department {Id=4,Name="sa"},
        //    new Department {Id=5,Name="os"}
        //};
        //modelBuilder.Entity<Ticket>().HasData(tickets);
        //modelBuilder.Entity<Developer>().HasData(developers);
        //modelBuilder.Entity<Department>().HasData(departments);
    }
}
