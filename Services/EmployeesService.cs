using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SalesControl.Data;
using SalesControl.Models;


namespace SalesControl.Services;
public class EmployeesService
{
    public readonly MyDbContext _context;
    public EmployeesService(MyDbContext context)
    {
        _context = context;
    }
    public async Task<List<Employee>> FindAllAsync()
    {
        return await _context.Employees.Include(obj => obj.Sector).ToListAsync();
    }

    public async Task<Employee> FindByIdAsync(int id)
    {
        var obj = await _context.Employees.Include(x => x.Sector).Where(x => x.Id == id).ToListAsync();
        Employee emp = new Employee();
        foreach(Employee item in obj)
        {
            emp.Id = item.Id;
            emp.Name = item.Name;
            emp.Email = item.Email;
            emp.BirthDate = item.BirthDate;
            emp.BaseSalary = item.BaseSalary;
            emp.Sector = item.Sector;
        }
        return emp;
    }

    public async Task InsertAsync(Employee obj)
    {
        await _context.Employees.AddAsync(obj);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Employee obj)
    {
        _context.Employees.Update(obj);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Employee obj)
    {
        _context.Remove(obj);
        await _context.SaveChangesAsync();
    }
}