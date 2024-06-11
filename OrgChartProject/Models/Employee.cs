namespace OrgChartProject.Models;

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }
    public int DepartmentId { get; set; }
    public Department Department { get; set; }
    public string PhotoPath { get; set; }
    public int? ManagerId { get; set; } // Manager Id for hierarchy
    public string? SubUnit { get; set; } // Nullable Sub-unit name
    public bool IsSubUnitLeader { get; set; } // Is the employee a sub-unit leader
}
