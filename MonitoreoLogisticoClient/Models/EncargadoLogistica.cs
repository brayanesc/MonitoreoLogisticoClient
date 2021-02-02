using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoClient.Models
{
    public class EncargadoLogistica
    {
        public EncargadoLogistica()
        {
            FechaIngreso = DateTime.Now;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public string NombreCompleto { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        [DisplayName("Fecha de Ingreso")]
        public DateTime FechaIngreso { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public string CI { get; set; }
        public int Edad { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Usuario Asignado")]
        public int UsuarioId { get; set; }
    }
}