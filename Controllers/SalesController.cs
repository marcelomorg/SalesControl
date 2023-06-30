using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SalesControl.Services;
using SalesControl.Models;
using SalesControl.Models.ViewModels;

namespace SalesControl.Controllers;
public class SalesController : Controller
{
    private readonly SalesService _salesService;
    private readonly EmployeesService _employeesService;
    
    public SalesController(SalesService service, EmployeesService service1)
    {
        _salesService = service;
        _employeesService = service1;
    }

    public IActionResult index()
    {
        List<Sale> sales = new List<Sale>(_salesService.findAll());
        return View(sales);
    }

    public IActionResult Create()
    {
        var employees = _employeesService.FindAll();
        var viewModel = new SalesFormViewModel {Employees = employees};
        return View(viewModel);
    }
    
    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult Create(Sale sale)
    {
        _salesService.insert(sale);
        return RedirectToAction(nameof(Index));
    }
}