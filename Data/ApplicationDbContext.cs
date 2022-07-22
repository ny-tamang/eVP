using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using evp.Models;
namespace evp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BusinessVisa> BusinessVisaForm { get; set; }
        public DbSet<StudentVisa> StudentVisaForm { get; set; }
        public DbSet<TouristVisa> TouristVisaForm { get; set; }
    }
}