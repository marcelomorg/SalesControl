using System;

namespace SalesControl.Models.ViewModels;
public class EmployeesFormViewModel
{
    public Employee Employee{ get; set;}
    public ICollection<Sector> Sectors { get; set; }
}