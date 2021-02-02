using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoClient.Models
{
    public class MarcacionEntrega
    {
        public int Id { get; set; }
        public DateTime Hora { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public int OrdenEntregaId { get; set; }
    }
}