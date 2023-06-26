using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalesControl.Models;
using SalesControl.Services;
using SalesControl.Models.ViewModels;

namespace SalesControl.Controllers
{
    public class EmployeesController : Controller
    {
        public readonly EmployeesService _employeeService;
        public readonly SectorsService _sectorService;

        public EmployeesController(EmployeesService service, SectorsService service1)
        {
            _employeeService = service;
            _sectorService = service1;
        }

        public IActionResult Index()
        {
            var list = _employeeService.findAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var sectors = _sectorService.findAll();
            var viewModel = new EmployeesFormViewModel {Sectors = sectors};
            return View(viewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Employee employee)
        {
            _employeeService.insert(employee);
            return RedirectToAction(nameof(Index));
        }

    }
}