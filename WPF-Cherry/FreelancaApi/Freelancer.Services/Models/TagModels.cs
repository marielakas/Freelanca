using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Freelancer.Services.Models
{
    [DataContract]
    public class TagModel
    {
        [DataMember(Name = "Id")]
        public int Id { get; set; }

        [DataMember(Name = "Name")]
        public string Name { get; set; }
    }

    public class TagDetailedModel : TagModel
    {
        public virtual ICollection<JobModel> Jobs { get; set; }
    }
}