using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeFirst.Model
{
    public class Tag
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }

        public Tag()
        {
            this.Jobs = new HashSet<Job>();
        }
    }
}
