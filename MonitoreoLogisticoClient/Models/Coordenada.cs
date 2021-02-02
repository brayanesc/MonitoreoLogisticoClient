using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoClient.Models
{
    public class Coordenada
    {
        public int Id { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public int ZonaId { get; set; }
    }
}