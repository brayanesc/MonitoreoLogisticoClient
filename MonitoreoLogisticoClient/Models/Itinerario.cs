using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoClient.Models
{
    public class Itinerario
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }


        [Display(Name ="Identificador Repartidor")]
        public int RepartidorId { get; set; }


        [Display(Name = "Identificador DetalleItinerario")]
        public int DetalleItinerarioId { get; set; }


        [Display(Name = "Identificador de Zona")]
        public int ZonaId { get; set; }
    }
}