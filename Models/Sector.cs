using System;

namespace SalesControl.Models;

public class Sector
{
    public int Id{ get; set;}
    public string? Name { get; set;}
    public ICollection<Employee> Employees { get; set;} = new List<Employee>();

    public Sector()
    {

    }
    public Sector(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public void addEmployee(Employee employee)
    {
        Employees.Add(employee);
    }

    public double totalSale(DateTime initial, DateTime final)
    {
        return Employees.Sum(emp => emp.totalSale(initial, final));
    }
}