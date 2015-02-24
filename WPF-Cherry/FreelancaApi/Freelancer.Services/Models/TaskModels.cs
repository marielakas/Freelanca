using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeFirst.Model;
using System.Runtime.Serialization;

namespace Freelancer.Services.Models
{
    [DataContract]
    public class TaskModel
    {
        [DataMember(Name = "Id")]
        public int Id { get; set; }

        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "Id")]
        public virtual Difficulty Difficulty { get; set; }

        [DataMember(Name = "Pending")]
        public bool Pending { get; set; }
    }

    public class DetailedTaskModel : TaskModel
    {
        public virtual ICollection<TagModel> Tags { get; set; }
    }
}