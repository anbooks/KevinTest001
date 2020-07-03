using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KevinTest001.Controllers
{
    public class EFController:Controller
    {
        public IActionResult Index()
        {
            var i = 1;

            return View();

        }

    }
}
