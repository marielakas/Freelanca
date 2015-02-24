using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeLancaVS2012.Models
{
    public class TaskModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Difficulty { get; set; }

        public bool Pending { get; set; }

        public virtual ICollection<TagModel> Tags { get; set; }
    }
}
