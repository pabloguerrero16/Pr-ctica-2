using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebPractica2.Entities;
using WebPractica2.Models;

namespace WebPractica2.Controllers
{
    public class HomeController : Controller
    {

        PracticaModelo model = new PracticaModelo();

        [HttpGet]
        public ActionResult Index()
        {
            ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
            return View();
        }

        [HttpGet]
        public ActionResult Vendedores()
        {
            var estados = new List<SelectListItem>
            {
                new SelectListItem { Text = "Activo", Value = "Activo" },
                new SelectListItem { Text = "Inactivo", Value = "Inactivo" }
            };

            ViewBag.Estados = estados;
            return View();
        }

        [HttpGet]
        public ActionResult Vehiculos()
        { 
            ViewBag.Vendedores = model.ConsultarNombres();

            return View();
        }

        [HttpGet]
        public ActionResult Consulta()
        {
            var datos = model.ConsultarVehiculo();
            return View(datos);
        }

        [HttpPost]
        public ActionResult Vehiculos(VehiculoEnt entidad)
        {
            var resp = model.RegistrarVehiculo(entidad);
            if(resp == "OK")
            {
                TempData["Exito"] = "Se ha registrado el vehículo";
                return RedirectToAction("Vehiculos","Home");
            }
            else
            {
                TempData["Error"] = "No ha sido posible registrar el vehículo";
                return RedirectToAction("Vehiculos","Home");
            }
        }

        [HttpPost]
        public ActionResult Vendedores(VendedorEnt entidad)
        {
            var resp = model.RegistrarVendedor(entidad);
            if (resp == "OK")
            {
                TempData["Exito"] = "Se ha registrado el vendedor";
                return RedirectToAction("Vendedores", "Home");
            }
            else
            {
                TempData["Error"] = "No ha sido posible registrar el vendedor";
                return RedirectToAction("Vendedores", "Home");
            }
        }

        [HttpGet]
        public ActionResult ConsultarVehiculo()
        {
            var datos = model.ConsultarVehiculo();
            return View(datos);
        }

    }
}