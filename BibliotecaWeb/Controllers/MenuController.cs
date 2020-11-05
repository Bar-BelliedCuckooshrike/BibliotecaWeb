using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibliotecaWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaWeb.Controllers
{
    public class MenuController : Controller
    {
        public Context _context;
        
        public IActionResult Index()
        {
            return View();          
        }
    }
}
