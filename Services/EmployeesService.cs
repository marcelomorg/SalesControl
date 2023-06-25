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
}