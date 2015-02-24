using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeFirst.Model
{
    public class Task
    {
        public Task()
        {
            //this.Jobs = new HashSet<Job>();
            this.Tags = new HashSet<Tag>();
            Pending = true;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Difficulty Difficulty { get; set; }

        public bool Pending { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual Job Job { get; set; } 
        //public virtual ICollection<Job> Jobs { get; set; } 
    }
}
