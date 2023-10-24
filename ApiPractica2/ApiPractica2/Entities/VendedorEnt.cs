using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiPractica2.Entities
{
    public class VendedorEnt
    {
        public int IdVendedor { get; set; }
        public string Cedula {  get; set; }
        public string Nombre {  get; set; }
        public string Correo {  get; set; }
        public bool Estado {  get; set; }
    }
}