using MonitoreoLogisticoClient.Models.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoClient.Models
{
    public class Zona
    {
        public Zona(){
            this.Coordenadas = "";
            this.datos = new List<ZonaCoordenada_dto>();
        }


        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public string Nombre { get; set; }

        public string Coordenadas { get; set; }

        public List<ZonaCoordenada_dto> datos { get; set; }
    }
}