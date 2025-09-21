using Microsoft.EntityFrameworkCore;
using Twiddle.DataAccess.Database.Entities;

namespace Twiddle.DataAccess.Database;

public class TwiddleDb : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=TwiddleDb;Trusted_Connection=True;TrustServerCertificate=true");
    }
    
    public DbSet<User> Users { get; set; }
    
    public DbSet<Twid> Twids { get; set; } 
}