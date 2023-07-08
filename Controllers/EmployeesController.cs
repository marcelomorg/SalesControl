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

        public async Task<IActionResult> Index()
        {
            var list = await _employeeService.FindAllAsync();
            return View(list);
        }

        public IActionResult Create()
        {
            var sectors = _sectorService.findAll();
            var viewModel = new EmployeesFormViewModel {Sectors = sectors};
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            if(!ModelState.IsValid)
            {
                List<Sector> sector = _sectorService.findAll();
                EmployeesFormViewModel viewmodels = new EmployeesFormViewModel{Sectors = sector};
                return View(viewmodels);
            }
            await _employeeService.InsertAsync(employee);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Employee employee)
        {
            var resultEmployee = await _employeeService.FindByIdAsync(employee.Id);
            List<Sector> resultSectors = _sectorService.findAll();
            EmployeesFormViewModel result = new EmployeesFormViewModel {Employee = resultEmployee, Sectors = resultSectors};
            return View(result);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> EditTwo(Employee employee)
        {
            await _employeeService.UpdateAsync(employee);
            return RedirectToAction(nameof(Index));   
        }

        public async Task<IActionResult> Detail(Employee employee)
        {
            var result = await _employeeService.FindByIdAsync(employee.Id);
            return View(result);
        }

        public async Task<IActionResult> Delete(Employee employee)
        {
            var result = await _employeeService.FindByIdAsync(employee.Id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTwo(Employee employee)
        {
            await _employeeService.DeleteAsync(employee);
            return RedirectToAction(nameof(Index));
        }
    }
}