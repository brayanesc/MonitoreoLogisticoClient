using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoClient.Models.Reportes
{
    public class ReporteItinerario
    {
        public string Itinerario { get; set; }
        public int OrdenEntrega { get; set; }
        public string Estado { get; set; }
        public DateTime FechaEmision { get; set; }

    }
}