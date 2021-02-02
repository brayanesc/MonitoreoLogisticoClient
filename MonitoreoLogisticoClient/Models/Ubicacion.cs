using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoClient.Models
{
    public class Ubicacion
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
    }
}