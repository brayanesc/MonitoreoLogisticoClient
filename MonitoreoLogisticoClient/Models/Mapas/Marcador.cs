using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoClient.Models.Mapas
{
    public class Marcador
    {
            public string Nombre { get; set; }
            public float Latitud { get; set; }
            public float Longitud { get; set; }
            public string Icono { get; set; }
            public string Descripcion { get; set; }
    }
}