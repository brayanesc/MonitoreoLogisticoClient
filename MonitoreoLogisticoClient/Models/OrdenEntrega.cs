using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoClient.Models
{
    public class OrdenEntrega
    {
        public OrdenEntrega() {
            Estado = "Pendiente";
            FecharEmision = DateTime.Now;
            Prioridad = 1;
        }

        public int Id { get; set; }
        public DateTime FecharEmision { get; set; }
        public int NroFactura { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public string Estado { get; set; }

        [ScaffoldColumn(false)]
        public int Prioridad { get; set; }

        [Display(Name = "Itinerario")]
        public int ItinerarioId { get; set; }
        [Display(Name = "Nombre del Cliente")]
        public int ClienteId { get; set; }
    }
}