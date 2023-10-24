using ApiPractica2.Entities;
using ApiPractica2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiPractica2.Controllers
{
    public class VehiculoController : ApiController
    {
        [HttpPost]
        [Route("RegistrarVehiculo")]
        public string RegistrarVehiculo(VehiculoEnt entidad)
        {
            try
            {
                using (var context = new Practica2Entities())
                {
                    var cantidad = (from x in context.Vehiculos
                                  where x.Marca == entidad.Marca
                                  select x).Count();

                    if (cantidad >= 2)
                    {
                        return "NO SE PERMITE OTRO VEHICULO CON ESA MARCA";
                    }
                    else
                    {
                        context.InsertarVehiculo(entidad.Marca, entidad.Modelo, entidad.Color, entidad.Precio, entidad.Vendedor);
                        return "OK";
                    }

                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        [HttpGet]
        [Route("ConsultarVehiculo")]
        public List<ConsultaVehiculo> ConsultarVehiculo()
        {
            try
            {
                using (var context = new Practica2Entities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    var datos = (from x in context.Vendedores
                                 join v in context.Vehiculos on x.IdVendedor equals v.IdVendedor
                                 select new ConsultaVehiculo
                                 {
                                     cedula = x.Cedula,
                                     nombre = x.Nombre,
                                     marca = v.Marca,
                                     modelo = v.Modelo,
                                     precio = v.Precio
                                 }).ToList();
                    return datos;
                }
            }catch (Exception)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("ConsultarNombres")]
        public List<System.Web.Mvc.SelectListItem> ConsultarNombres()
        {
            try
            {
                using (var context = new Practica2Entities())
                {
                    var datos = (from x in context.Vendedores
                                 select x).ToList();

                    var respuesta = new List<System.Web.Mvc.SelectListItem>();
                    foreach (var item in datos)
                    {
                        respuesta.Add(new System.Web.Mvc.SelectListItem { Value = item.IdVendedor.ToString(), Text = item.Nombre });
                    }
                    return respuesta;
                }

            }catch (Exception)
            {
                return null;
            }
        }
    }
}
