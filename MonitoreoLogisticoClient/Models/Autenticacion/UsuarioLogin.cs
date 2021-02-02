using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoClient.Models.Autenticacion
{
    public class UsuarioLogin
    {
        public UsuarioLogin() {
            grant_type = "password";
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string grant_type { get; set; }
    }
}