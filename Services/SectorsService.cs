using System;
using SalesControl.Data;
using SalesControl.Models;

namespace SalesControl.Services;
public class SectorsService
{
    private readonly MyDbContext _context;

    public SectorsService(MyDbContext context)
    {
        _context = context;
    }

    public List<Sector> findAll()
    {
        return _context.Sectors.ToList();
    }

    public void insert(Sector obj)
    {
        _context.Add(obj);
        _context.SaveChanges();
    }

    public void Update(Sector obj)
    {
        _context.Sectors.Update(obj);
        _context.SaveChanges();
    }

    public void Delete (Sector obj)
    {
        _context.Sectors.Remove(obj);
        _context.SaveChanges();
    }
}