using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPractica2.Entities
{
    public class VehiculoEnt
    {
        public int IdVehiculo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public decimal Precio { get; set; }
        public int Vendedor { get; set; }
    }
}