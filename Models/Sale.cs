using SalesControl.Models.Enums;

namespace SalesControl.Models;

public class Sale
{
    public int Id { get; set;}
    public DateTime Date { get; set;}
    public double Value { get; set;}
    public SaleStatus Status {get; set;}
    public  Employee? Employee {get; set;}
    public int EmployeeId { get; set;}

    public Sale()
    {

    }
    public Sale(int id, DateTime date, double value, SaleStatus status, Employee employee)
    {
        Id = id;
        Date = date;
        Value = value;
        Status = status;
        Employee = employee;
    }

}