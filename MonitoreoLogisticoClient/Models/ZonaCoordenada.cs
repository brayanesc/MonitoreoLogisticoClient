using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoClient.Models
{
    public class ZonaCoordenada
    {
        public int Id;
        public int CoordenadaId { get; set; }
        public int ZonaId { get; set; }
    }
}