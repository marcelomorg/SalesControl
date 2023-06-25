using System;
using SalesControl.Models;
using SalesControl.Models.Enums;

namespace SalesControl.Data;
public class SeedingService
{
    public MyDbContext _context;

    public SeedingService(MyDbContext context)
    {
        _context = context;
        this.seed();
        
    }

    public void seed()
    {
        if(_context.Sectors.Any() && _context.Employees.Any() && _context.Sales.Any())
        {
            return;
        }

        Sector sec1 = new Sector(1, "Eletronics");
        Sector sec2 = new Sector(2, "Textile");
        Sector sec3 = new Sector(3, "Toys");

        Employee emp1 = new Employee(1, "Robert Antony", "rob@email.com", new DateTime(1999,10,15), 5000, sec1);
        Employee emp2 = new Employee(2, "Marie Julie", "mjulie@email.com", new DateTime(1980, 01, 25), 4500, sec3);
        Employee emp3 = new Employee(3, "Jhon Nier", "jhon@email.com", new DateTime(1977, 03, 02), 6000, sec2);

        Sale sal1 = new Sale(1, new DateTime(2022, 10, 22), 500, SaleStatus.BILLED, emp1);
        Sale sal2 = new Sale(2, new DateTime(2022, 11, 12), 100, SaleStatus.BILLED, emp3);
        Sale sal3 = new Sale(3, new DateTime(2022, 1, 2), 600, SaleStatus.BILLED, emp2);
        Sale sal4 = new Sale(4, new DateTime(2022, 7, 11), 100, SaleStatus.CANCELED, emp1);
        Sale sal5 = new Sale(5, new DateTime(2022, 8, 23), 1100, SaleStatus.BILLED, emp2);
        Sale sal6 = new Sale(6, new DateTime(2022, 2, 8), 800, SaleStatus.BILLED, emp1);
        Sale sal7 = new Sale(7, new DateTime(2022, 6, 14), 50, SaleStatus.BILLED, emp3);
        Sale sal8 = new Sale(8, new DateTime(2022, 8, 28), 900, SaleStatus.PEDING, emp1);
        Sale sal9 = new Sale(9, new DateTime(2022, 10, 02), 300, SaleStatus.BILLED, emp2);
        Sale sal10 = new Sale(10, new DateTime(2022, 12, 15), 400, SaleStatus.PEDING, emp1);

        _context.Sectors.AddRange(sec1, sec2, sec3);
        _context.Employees.AddRange(emp1, emp2, emp3);
        _context.Sales.AddRange(sal1, sal2, sal3, sal4, sal5, sal6, sal7, sal8, sal9, sal10);
        _context.SaveChanges();

    }
}