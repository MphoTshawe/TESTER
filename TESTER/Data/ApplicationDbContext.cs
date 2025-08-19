using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using TESTER.Models;

namespace TESTER.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
       
        
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
            {
            }
            public DbSet<GetQuote> getquote { get; set; }
            public DbSet<Beneficiaries> beneficiaries { get; set; }

            public DbSet<Claims>claims { get; set; }




    }
}
