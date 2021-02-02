using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoClient.Models.Dtos
{
    public class Itinerario_dto
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public int IdDetalleItinerario { get; set; }

        public string Descripcion { get; set; }

        public DateTime? Salida { get; set; }

        public DateTime? Llegada { get; set; }


        [Display(Name = "Codigo Repartidor")]
        public int RepartidorId { get; set; }


        [Display(Name = "Nombre Repartidor")]
        public string NombreRepartidor { get; set; }


        [Display(Name = "Codigo Zona")]
        public int ZonaId { get; set; }


        [Display(Name = "Descripcion Zona")]
        public string ZonaNombre { get; set; }

    }
}