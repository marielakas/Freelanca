using FreeLancaVS2012.ViewModels;
using FreeLancaVS2012.Behavior;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FreeLancaVS2012.ViewModels
{
    public class JobViewModel
    {
        public string Title { get; set; }

        public int Id { get; set; }
    }

    public class JobDetailedViewModel : JobViewModel
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

        public IEnumerable<TaskViewModel> Tasks { get; set; }

        public IEnumerable<string> JobTags { get; set; }

    }
}
