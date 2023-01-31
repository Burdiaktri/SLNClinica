using Microsoft.AspNetCore.Mvc;
using System;

namespace SLNClinica.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Nombre = "Bienvenido al sistema de Clinicas";
            ViewBag.Fecha = DateTime.Now.ToString();
            return View();
        }
    }
}
