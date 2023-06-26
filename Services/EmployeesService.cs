using System;
using System.Collections.Generic;
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
    public List<Employee> findAll()
    {
        return _context.Employees.ToList();
    }

    public void insert(Employee obj)
    {
        _context.Employees.Add(obj);
        _context.SaveChanges();
    }
}