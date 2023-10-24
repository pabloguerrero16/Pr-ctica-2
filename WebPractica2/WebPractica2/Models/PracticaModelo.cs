using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Json;
using WebPractica2.Entities;
using System.Web.Mvc;

namespace WebPractica2.Models
{
    public class PracticaModelo
    {
        public string urlApi = ConfigurationManager.AppSettings["urlApi"];
        
        public List<ConsultaVehiculo> ConsultarVehiculo()
        {
            using (var client = new HttpClient())
            {
                var url = "https://localhost:44306/ConsultarVehiculo";
                //var url = urlApi + "ConsultarVehiculo";
                var resp = client.GetAsync(url).Result;
                return resp.Content.ReadFromJsonAsync<List<ConsultaVehiculo>>().Result;
            }
        }

        public string RegistrarVehiculo(VehiculoEnt entidad)
        {
            using (var client = new HttpClient())
            {
                var url = "https://localhost:44306/RegistrarVehiculo";
                //string url = urlApi + "RegistrarVehiculo";
                JsonContent contenido = JsonContent.Create(entidad);
                var resp = client.PostAsync(url, contenido).Result;
                return resp.Content.ReadFromJsonAsync<string>().Result;
            }
        }

        public string RegistrarVendedor(VendedorEnt entidad)
        {
            using (var client = new HttpClient())
            {
                var url = "https://localhost:44306/RegistrarVendedor";
                //string url = urlApi + "RegistrarVendedor";
                JsonContent contenido = JsonContent.Create(entidad);
                var resp = client.PostAsync(url, contenido).Result;
                return resp.Content.ReadFromJsonAsync<string>().Result;
            }

        }

        public List<SelectListItem> ConsultarNombres()
        {
            using (var client = new HttpClient())
            {
                var url = "https://localhost:44306/ConsultarNombres";
                //string url = urlApi + "ConsultarNombres";
                var resp = client.GetAsync(url).Result;
                return resp.Content.ReadFromJsonAsync<List<SelectListItem>>().Result;
            }
        }
    }
}