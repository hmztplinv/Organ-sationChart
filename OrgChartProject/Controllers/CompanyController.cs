using Microsoft.AspNetCore.Mvc;
using OrgChartProject.Models;
using System.Linq;

public class CompanyController : Controller
{
    private readonly ApplicationDbContext _context;

    public CompanyController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var companies = _context.Companies.ToList();
        return View(companies);
    }

    public IActionResult Departments(int id)
    {
        var departments = _context.Departments.Where(d => d.CompanyId == id).ToList();
        if (departments == null || !departments.Any())
        {
            return NotFound();
        }

        ViewBag.CompanyId = id;
        return View(departments);
    }

    public IActionResult Employees(int id, int companyId)
    {
        var department = _context.Departments.FirstOrDefault(d => d.Id == id);
        var company = _context.Companies.FirstOrDefault(c => c.Id == companyId);
        var employees = _context.Employees.Where(e => e.DepartmentId == id).ToList();

        if (employees == null || !employees.Any())
        {
            return NotFound();
        }

        ViewBag.DepartmentName = department?.Name;
        ViewBag.CompanyName = company?.Name;

        return View(employees);
    }

    [HttpPost]
    public IActionResult UpdateManager(int employeeId, int newManagerId)
    {
        var employee = _context.Employees.Find(employeeId);
        if (employee == null)
        {
            return NotFound();
        }

        employee.ManagerId = newManagerId;
        _context.SaveChanges();

        return Ok();
    }




}