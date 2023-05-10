using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace apilab3.Data
{
    public class Officecontext:IdentityDbContext<Lawyer>
    {
        public Officecontext(DbContextOptions<Officecontext>options):base(options)
        { 
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Lawyer>().ToTable("lawyer");
        }
    }
}
