using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesControl.Models;
using SalesControl.Services;

namespace SalesControl.Controllers;

public class SectorsController : Controller
{
    private readonly SectorsService _service;

    public SectorsController(SectorsService service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        List<Sector> list = new List<Sector>();
        list = _service.findAll();
        return View(list);
    }
}