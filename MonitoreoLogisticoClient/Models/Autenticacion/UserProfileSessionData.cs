using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitoreoLogisticoClient.Models.Autenticacion
{
    [Serializable]
    public class UserProfileSessionData
    {
        public int UserId { get; set; }
        public string EmailAddress { get; set; }
        public string FullName { get; set; }
        public string Token { get; set; }

        public UserProfileSessionData()
        {
            this.UserId = 0;
            this.EmailAddress = "";
            this.FullName = "";
            this.Token = "";

        }
    }
}