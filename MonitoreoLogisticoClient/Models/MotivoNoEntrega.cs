using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoClient.Models
{
    public class MotivoNoEntrega
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int MarcacionEntregaId { get; set; }
    }
}