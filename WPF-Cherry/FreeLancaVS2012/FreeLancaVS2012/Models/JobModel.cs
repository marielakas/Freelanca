using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeLancaVS2012.Models;

namespace FreeLancaVS2012.Models
{
    public class JobModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }

    //TODO: remove/update some properties
    public class JobDetailedModel : JobModel
    {
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }

        public DateTime Deadline { get; set; }

        public bool Completed { get; set; }

        public double Price { get; set; }

        public string Category { get; set; }

        public string Owner { get; set; }

        public string TotalDifficulty { get; set; }

        public  ICollection<TaskModel> Tasks { get; set; }

        public  ICollection<TagModel> JobTags { get; set; }

    }
}
