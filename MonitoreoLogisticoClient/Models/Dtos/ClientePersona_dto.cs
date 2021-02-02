using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoClient.Models.Dtos
{
    public class ClientePersona_dto
    {
        public ClientePersona_dto()
        {
            Id = 0;
            UbicacionId = 0;
            ClientePersonaId = 0;

            FechaNacimiento = DateTime.Now;
        }


        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public int UbicacionId { get; set; }

        [ScaffoldColumn(false)]
        public int ClientePersonaId { get; set; }

        //datos cliente
        [Required]
        [DisplayName("Nombre Completo")]
        public string NombreCompleto { get; set; }

        [Required]
        public string Telefono { get; set; }

        [Required]
        public string Email { get; set; }

        
        //datos cliente persona
            
        public string CI { get; set; }
        public string Ocupacion { get; set; }

        [DisplayName("Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }



        //datos ubicacion
        public string Descripcion { get; set; }

        [Required]
        public string Latitud { get; set; }

        [Required]
        public string Longitud { get; set; }


    }
}