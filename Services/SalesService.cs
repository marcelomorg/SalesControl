using System;
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
        return _context.Sales.ToList();
    }
}