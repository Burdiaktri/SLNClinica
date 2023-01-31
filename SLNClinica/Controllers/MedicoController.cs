using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SLNClinica.Data;
using SLNClinica.Models;
using System.Collections.Generic;
using System.Linq;

namespace SLNClinica.Controllers
{
    public class MedicoController : Controller
    {
        private readonly DBClinicaMVCContext context;

        public MedicoController(DBClinicaMVCContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Medico> medicos =  context.Medicos.ToList();
            return View(medicos);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Medico medico = new Medico();
            return View(medico);
        }

        [HttpPost]
        public ActionResult Create(Medico medico)
        {
            if (ModelState.IsValid)
            {
                context.Medicos.Add(medico);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medico);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Medico medico = TraerUno(id);
            if (medico == null)
            {
                return NotFound();
            }
            else
            {
                return View(medico);
            }
        }

        [ActionName("Delete")]
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            Medico medico = TraerUno(id);
            if (medico == null)
            {
                return NotFound();
            }
            else
            {
                context.Medicos.Remove(medico);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Medico medico = TraerUno(id);
            if (medico == null)
            {
                return NotFound();
            }
            else
            {
                return View("Details", medico);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Medico medico = TraerUno(id);
            if (medico == null)
            {
                return NotFound();
            }
            else
            {
                return View("detalle", medico);
            }
        }


        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditConfirmed(Medico medico)
        {
            if (ModelState.IsValid)
            {
                context.Entry(medico).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medico);
        }

        private Medico TraerUno(int id)
        {
            return context.Medicos.Find(id);
        }
    }
}
