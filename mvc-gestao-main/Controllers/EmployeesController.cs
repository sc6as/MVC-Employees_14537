using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeesManagement.Data;
using EmployeesManagement.Models;

namespace EmployeesManagement.Controllers;

[Authorize]
public class EmployeesController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public EmployeesController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index() => View(await _context.Employees.ToListAsync());

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var e = await _context.Employees.FirstOrDefaultAsync(m => m.Id == id);
        return e == null ? NotFound() : View(e);
    }

    public IActionResult Create() => View();

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Employee employee)
    {
        var userId = _userManager.GetUserId(User);
        employee.CreatedById = userId;
        employee.CreatedOn = DateTime.Now;
        employee.ModifiedById = userId;
        employee.ModifiedOn = DateTime.Now;

        if (ModelState.IsValid)
        {
            _context.Add(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(employee);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var e = await _context.Employees.FindAsync(id);
        return e == null ? NotFound() : View(e);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Employee employee)
    {
        if (id != employee.Id) return NotFound();
        if (ModelState.IsValid)
        {
            try
            {
                employee.ModifiedById = _userManager.GetUserId(User);
                employee.ModifiedOn = DateTime.Now;
                _context.Update(employee);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Employees.Any(e => e.Id == id)) return NotFound();
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(employee);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();
        var e = await _context.Employees.FirstOrDefaultAsync(m => m.Id == id);
        return e == null ? NotFound() : View(e);
    }

    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var e = await _context.Employees.FindAsync(id);
        if (e != null) _context.Employees.Remove(e);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
