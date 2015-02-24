using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using CodeFirst.Model;
using CodeFirst.Model;
using Freelancer.Services.Models;
using System.Runtime.Serialization;

namespace Freelancer.Services.Models
{
    [DataContract]
    public class JobModel
    {
        [DataMember(Name = "Id")]
        public int Id { get; set; }

        [DataMember(Name = "Title")]
        public string Title { get; set; }

        [DataMember(Name = "Description")]
        public string Description { get; set; }

        [DataMember(Name = "CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [DataMember(Name = "ModifiedAt")]
        public DateTime ModifiedAt { get; set; }

        [DataMember(Name = "Deadline")]
        public DateTime Deadline { get; set; }

        [DataMember(Name = "Completed")]
        public bool Completed { get; set; }

        [DataMember(Name = "Price")]
        public double Price { get; set; }

        [DataMember(Name = "Category")]
        public string Category { get; set; }

        [DataMember(Name = "Owner")]
        public string Owner { get; set; }

        //public virtual User ModifiedBy { get; set; }

        public virtual Difficulty TotalDifficulty { get; set; }

        public virtual ICollection<TaskModel> Tasks { get; set; }
    }

    public class JobNames
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }

    public class CreateJobModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime Deadline { get; set; }

        public double Price { get; set; }

        public string Category { get; set; }

        public UserModel Owner { get; set; }

        //public virtual User ModifiedBy { get; set; }

        public Difficulty TotalDifficulty { get; set; }
    }

    public class ResponseJobModel
    {
        public string Title { get; set; }
    }

    public class JobDetailedModel : JobModel
    {

        public virtual ICollection<string> JobTags { get; set; }
    }
}