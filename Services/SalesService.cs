using System;
using Microsoft.EntityFrameworkCore;
using SalesControl.Data;
using SalesControl.Models;

namespace SalesControl.Services;
public class SalesService
{
    private readonly MyDbContext _context;

    public SalesService(MyDbContext context)
    {
        _context = context;
    }

    public List<Sale> findAll()
    {
        return _context.Sales.Include(obj => obj.Employee).ToList();
    }

    public void insert(Sale sale)
    {
        _context.Sales.Add(sale);
        _context.SaveChanges();
    }
}