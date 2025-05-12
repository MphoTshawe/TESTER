using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TESTER.Models;

namespace TESTER.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
       
        
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
            {
            }
            public DbSet<GetQuote> getquote { get; set; }
            public DbSet<Client> Clients { get; set; }
        
    }
}
