using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeesManagement.Data;

namespace EmployeesManagement.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context) { _context = context; }

    public async Task<IActionResult> Index()
    {
        ViewBag.TotalEmployees = await _context.Employees.CountAsync();
        ViewBag.TotalDepartments = await _context.Employees.Select(e => e.Department).Distinct().CountAsync();
        ViewBag.TotalCountries = await _context.Employees.Select(e => e.Country).Distinct().CountAsync();
        return View();
    }

    public IActionResult Privacy() => View();
}
