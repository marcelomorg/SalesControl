using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesControl.Models;

namespace SalesControl.Controllers;

public class SectorsController : Controller
{
    public IActionResult Index()
    {
        List<Sector> list = new List<Sector>();
        list.Add(new Sector{Id = 1, Name = "Construction"});
        list.Add(new Sector{Id = 2, Name = "Textile"});
        list.Add(new Sector{Id = 3, Name = "Toys"});

        return View(list);
    }
}