using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoClient.Models.Reportes
{
    public class ReporteCumplimiento
    {
        public int CodigoCliente { get; set; }
        public int Factura { get; set; }
        public string NombreCliente { get; set; }
        public string Estado { get; set; }
        public string Itinerario { get; set; }
    }
}