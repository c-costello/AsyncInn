﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AsyncInnApp.Controllers
{
    public class AmenitiesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}