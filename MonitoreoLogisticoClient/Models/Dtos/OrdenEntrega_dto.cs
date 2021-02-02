using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoClient.Models.Dtos
{
    public class OrdenEntrega_dto
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }


        [Display(Name ="Fecha de Emision")]
        public DateTime FechaEmision { get; set; }


        [Display(Name ="Factura Asociada")]
        public int NroFactura { get; set; }


        [Display(Name ="Estado de la Entrega")]
        public string Estado { get; set; }


        [Display(Name ="Prioridad")]
        public int Prioridad { get; set; }


        [Display(Name = "Codigo Itinerario")]
        public int ItinerarioId { get; set; }


        [Display(Name = "Descripcion de Itinerario")]
        public string ItinerarioDescripcion { get; set; }


        [Display(Name = "Codigo Cliente")]
        public int ClienteId { get; set; }


        [Display(Name = "Nombre de Cliente")]
        public string ClienteNombre { get; set; }

    }
}