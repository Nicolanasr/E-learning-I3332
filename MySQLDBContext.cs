using Microsoft.EntityFrameworkCore;
namespace E_Learning_I3332.Models;
public class MySQLDBContext : DbContext
{
    public DbSet<Users>? Users { get; set; }
    public MySQLDBContext(DbContextOptions<MySQLDBContext> options) : base(options) { }
}