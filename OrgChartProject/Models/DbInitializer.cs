namespace OrgChartProject.Models;

public static class DbInitializer
{
    public static void Initialize(ApplicationDbContext context)
    {
        context.Database.EnsureCreated();

        if (context.Companies.Any())
        {
            return; // DB has been seeded
        }

        var companies = new Company[]
        {
            new Company { Name = "Company A" },
            new Company { Name = "Company B" },
        };

        foreach (var c in companies)
        {
            context.Companies.Add(c);
        }
        context.SaveChanges();

        var departments = new Department[]
        {
            new Department { Name = "HR", CompanyId = companies[0].Id },
            new Department { Name = "Engineering", CompanyId = companies[0].Id },
            new Department { Name = "Marketing", CompanyId = companies[1].Id },
        };

        foreach (var d in departments)
        {
            context.Departments.Add(d);
        }
        context.SaveChanges();

        var employees = new Employee[]
        {
            new Employee { FirstName = "John", LastName = "Doe", Position = "Manager", DepartmentId = departments[0].Id, PhotoPath = "/images/john_doe.jpg" },
            new Employee { FirstName = "Jane", LastName = "Smith", Position = "Engineer", DepartmentId = departments[1].Id, PhotoPath = "/images/jane_smith.jpg", ManagerId = 1 },
            new Employee { FirstName = "Emily", LastName = "Jones", Position = "Marketer", DepartmentId = departments[2].Id, PhotoPath = "/images/emily_jones.jpg", ManagerId = 1 },
            new Employee { FirstName = "Michael", LastName = "Brown", Position = "Recruiter", DepartmentId = departments[0].Id, PhotoPath = "/images/michael_brown.jpg", ManagerId = 1, SubUnit = "HR", IsSubUnitLeader = true },
            new Employee { FirstName = "Sarah", LastName = "Wilson", Position = "Developer", DepartmentId = departments[1].Id, PhotoPath = "/images/sarah_wilson.jpg", ManagerId = 2, SubUnit = "Engineering" },
            new Employee { FirstName = "David", LastName = "Miller", Position = "Sales", DepartmentId = departments[2].Id, PhotoPath = "/images/david_miller.jpg", ManagerId = 3, SubUnit = "Marketing" },
            new Employee { FirstName = "James", LastName = "Taylor", Position = "HR Specialist", DepartmentId = departments[0].Id, PhotoPath = "/images/james_taylor.jpg", ManagerId = 1, SubUnit = "HR" }
        };

        foreach (var e in employees)
        {
            context.Employees.Add(e);
        }
        context.SaveChanges();
    }
}
