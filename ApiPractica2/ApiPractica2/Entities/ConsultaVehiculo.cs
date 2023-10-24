using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiPractica2.Entities
{
    public class ConsultaVehiculo
    {
        public string cedula {  get; set; }
        public string nombre {  get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public decimal precio {  get; set; }

    }
}