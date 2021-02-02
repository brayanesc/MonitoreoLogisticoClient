using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoClient.Models
{
    public class Zonificacion
    {
        public Zonificacion()
        {
            Coordenadas = new List<Models.Coordenadas>();
        }


        public string Nombre { get; set; }

        //arreglo
        public List<Coordenadas> Coordenadas { get; set; }
    }
}