using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeFirst.Model
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }

        public Category()
        {
            this.Jobs = new HashSet<Job>();
        }
    }
}
