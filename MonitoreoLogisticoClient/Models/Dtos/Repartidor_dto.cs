using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoClient.Models.Dtos
{
    public class Repartidor_dto
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }


        [Display(Name ="Nombre Completo")]
        public string NombreCompleto { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        [Display(Name ="Fecha de Ingreso")]
        public DateTime FechaIngreso { get; set; }
        
        public string CI { get; set; }

        public int Edad { get; set; }

        [Display(Name = "Codigo de Usuario")]
        public int UsuarioId { get; set; }

        [Display(Name = "Usuario Asociado")]
        public string UsuarioNombre { get; set; }

    }
}