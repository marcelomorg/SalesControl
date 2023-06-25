using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalesControl.Models;
using SalesControl.Services;

namespace SalesControl.Controllers
{
    public class EmployeesController : Controller
    {
        public readonly EmployeesService _service;

        public EmployeesController(EmployeesService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var list = _service.findAll();
            return View(list);
        }

    }
}