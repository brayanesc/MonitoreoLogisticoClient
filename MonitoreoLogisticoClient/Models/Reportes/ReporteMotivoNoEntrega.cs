using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoClient.Models.Reportes
{
    public class ReporteMotivoNoEntrega
    {
        public int OrdenEntrega { get; set; }
        public int Factura { get; set; }
        public string Itinerario { get; set; }
        public DateTime Fecha { get; set; }
        public string Motivo { get; set; } 
    }
}