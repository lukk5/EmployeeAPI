using EmployeeData.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeData;

public class Context: DbContext
{
    public DbSet<Employee> Employees { get; set; }
    
    public Context(DbContextOptions<Context> options): base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().HasKey(e => e.Id);
    }
}