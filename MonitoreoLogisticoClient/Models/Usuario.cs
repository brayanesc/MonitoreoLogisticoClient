using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoClient.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public string Contrasena { get; set; }


        [Display(Name = "Rol")]
        public int RolId { get; set; }
    }
}