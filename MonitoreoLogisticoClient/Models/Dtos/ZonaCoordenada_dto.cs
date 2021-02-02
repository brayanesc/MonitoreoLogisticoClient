using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoClient.Models.Dtos
{
    public class ZonaCoordenada_dto
    {

        public ZonaCoordenada_dto() {
            coordenadas = new List<Coordenada_dto>();
        }
        public List<Coordenada_dto> coordenadas { get; set; }
        public int zonaid { get; set; }
    }
}