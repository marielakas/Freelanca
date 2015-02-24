using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FreeLancaVS2012.Models
{
    [DataContract]
    public class LoginResponseModel
    {
        [DataMember(Name = "displayName")]
        public string DisplayName { get; set; }

        [DataMember(Name = "accessToken")]
        public string AccessToken { get; set; }
    }
}
