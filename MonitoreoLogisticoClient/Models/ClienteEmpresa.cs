using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoClient.Models
{
    public class ClienteEmpresa
    {
        public int Id { get; set; }
        public string Abreviacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Sociedad { get; set; }
        public string Rubro { get; set; }
    }
}