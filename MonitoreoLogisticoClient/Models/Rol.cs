using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoClient.Models
{
    public class Rol
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name ="Nombre de Rol")]
        public string NombreRol { get; set; }
    }
}