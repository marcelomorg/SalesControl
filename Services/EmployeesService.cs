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
    public List<Employee> FindAll()
    {
        return _context.Employees.Include(obj => obj.Sector).ToList();
    }

    public Employee FindById(int id)
    {
        var obj = _context.Employees.Include(x => x.Sector).Where(x => x.Id == id).ToList();
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

    public void Insert(Employee obj)
    {
        _context.Employees.Add(obj);
        _context.SaveChanges();
    }

    public void Update(Employee obj)
    {
        _context.Employees.Update(obj);
        _context.SaveChanges();
    }

    public void Delete(Employee obj)
    {
        _context.Remove(obj);
        _context.SaveChanges();
    }
}