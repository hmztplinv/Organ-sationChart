using Microsoft.EntityFrameworkCore;

namespace OrgChartProject.Models;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
    }

    public DbSet<Company> Companies { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }
}
