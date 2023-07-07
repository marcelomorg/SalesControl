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
            var list = _employeeService.FindAll();
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
            if(!ModelState.IsValid)
            {
                List<Sector> sector = _sectorService.findAll();
                EmployeesFormViewModel viewmodels = new EmployeesFormViewModel{Sectors = sector};
                return View(viewmodels);
            }
            _employeeService.Insert(employee);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(Employee employee)
        {
            var resultEmployee = _employeeService.FindById(employee.Id);
            List<Sector> resultSectors = _sectorService.findAll();
            EmployeesFormViewModel result = new EmployeesFormViewModel {Employee = resultEmployee, Sectors = resultSectors};
            return View(result);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult EditTwo(Employee employee)
        {
            _employeeService.Update(employee);
            return RedirectToAction(nameof(Index));   
        }

        public IActionResult Detail(Employee employee)
        {
            var result = _employeeService.FindById(employee.Id);
            return View(result);
        }

        public IActionResult Delete(Employee employee)
        {
            var result = _employeeService.FindById(employee.Id);
            return View(result);
        }

        [HttpPost]
        public IActionResult DeleteTwo(Employee employee)
        {
            _employeeService.Delete(employee);
            return RedirectToAction(nameof(Index));
        }
    }
}