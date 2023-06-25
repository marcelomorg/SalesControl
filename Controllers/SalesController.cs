using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SalesControl.Services;
using SalesControl.Models;

namespace SalesControl.Controllers;
public class SalesController : Controller
{
    private readonly SalesService _service;
    
    public SalesController(SalesService service)
    {
        _service = service;
    }

    public IActionResult index()
    {
        List<Sale> sales = new List<Sale>(_service.findAll());
        return View(sales);
    }
}