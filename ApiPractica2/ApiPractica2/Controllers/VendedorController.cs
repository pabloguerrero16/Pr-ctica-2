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
    public class VendedorController : ApiController
    {
        [HttpPost]
        [Route("RegistrarVendedor")]
        public string RegistrarVendedor(VendedorEnt entidad)
        {
            try
            {
                using (var context = new Practica2Entities())
                {
                    var existe = (from x in context.Vendedores
                                  where x.Cedula == entidad.Cedula
                                  select x).Count();

                    if (existe > 0)
                    {
                        return  "YA EXISTE";
                    }
                    else
                    {
                        var user = new Vendedores();
                        user.Cedula = entidad.Cedula;
                        user.Nombre = entidad.Nombre;
                        user.Correo = entidad.Correo;
                        bool estado = user.Estado.Equals("Activo");

                        context.Vendedores.Add(user);
                        context.SaveChanges();
                        return "OK";
                    }
                    
                }
            }catch (Exception) { 
                return string.Empty;
            }
        }

    }
}
