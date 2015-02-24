using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FreeLancaVS2012.Models
{
    //[DataContract]
    public class UserModel
    {
        //[DataMember(Name = "username")]
        public string Username { get; set; }

        //[DataMember(Name = "authCode")]
        public string AuthCode { get; set; }

        //[DataMember(Name = "email")]
        public string Email { get; set; }

        //[DataMember(Name = "displayName")]
        public string DisplayName { get; set; }

        //[DataMember(Name = "location")]
        public string Location { get; set; }

        //[DataMember(Name = "phone")]
        public string Phone { get; set; }
    }
}
