using System;
using System.ComponentModel.DataAnnotations;
using SalesControl.Models;

namespace SalesControl.Models;

public class Employee
{
    public int Id { get; set;}
    public string Name { get; set; }
    public string Email { get; set;}
    
    [DataType(DataType.Date)]
    [Display(Name = "Birth Date")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime BirthDate { get; set;}
    
    [Display(Name = "Salary")]
    [DisplayFormat(DataFormatString = "{0:F2}")]
    public double BaseSalary { get; set;}
    public Sector Sector { get; set;}
    public int SectorId { get; set;}
    public ICollection<Sale> Sales { get; set;} = new List<Sale>();

    public Employee()
    {

    }
    public Employee(int id, string name, string email, DateTime birthdate, double basesalary, Sector sector)
    {
        Id = id;
        Name = name;
        Email = email;
        BirthDate = birthdate;
        BaseSalary = basesalary;
        Sector = sector;
    }
    

    public void addSale(Sale sale)
    {
        Sales.Add(sale);
    }

    public void delSale(Sale sale)
    {
        Sales.Remove(sale);
    }

    public double totalSale(DateTime initial, DateTime final)
    {
        return Sales.Where(sales => sales.Date >= initial && sales.Date <= final).Sum(sales => sales.Value);
    }

}