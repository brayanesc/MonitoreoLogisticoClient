using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoClient.Models
{
    public class ZonaDetalle
    {
        public int Id { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public int ZonaId { get; set;}
    }
}