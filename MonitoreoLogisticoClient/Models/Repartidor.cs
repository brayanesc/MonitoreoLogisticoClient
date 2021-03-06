﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoClient.Models
{
    public class Repartidor
    {
        public Repartidor() {
            FechaIngreso = DateTime.Now;
        }

        public int Id { get; set; }


        [Required(ErrorMessage = "Este campo es requerido")]
        public string NombreCompleto { get; set; }


        [Required(ErrorMessage = "Este campo es requerido")]
        public string Telefono { get; set; }


        [Required(ErrorMessage = "Este campo es requerido")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Este campo es requerido")]
        
        public DateTime FechaIngreso { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public string CI { get; set; }

        public int Edad { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name ="Usuario")]
        public int UsuarioId { get; set; }
    }
}