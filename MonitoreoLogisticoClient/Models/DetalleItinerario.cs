using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoClient.Models
{
    public class DetalleItinerario
    {
        public int Id { get; set; }
        public DateTime? Salida { get; set; }
        public DateTime? Llegada { get; set; }
    }
}