using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoClient.Models
{
    public class ClientePersona
    {
        public int Id { get; set; }
        public string CI { get; set; }
        public string Ocupacion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }

    }
}