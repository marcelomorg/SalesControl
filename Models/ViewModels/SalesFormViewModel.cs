using System;
using SalesControl.Models.Enums;

namespace SalesControl.Models.ViewModels;
public class SalesFormViewModel
{
    public Sale Sale { get; set; }
    public ICollection<Employee> Employees { get; set;}
}