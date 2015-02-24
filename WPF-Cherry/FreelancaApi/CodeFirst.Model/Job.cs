using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeFirst.Model
{
    public class Job
    {
        #region Id,Title,Description,CreatedAt,ModifiedAt,Deadline,Compleated,Price
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime Deadline { get; set; }

        public bool Completed { get; set; }

        public double Price { get; set; }
        #endregion

        public virtual Category Category { get; set; }

        
        public virtual User Owner { get; set; }

        public virtual User Worker { get; set; }

        public virtual Difficulty TotalDifficulty { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }

        public virtual ICollection<Tag> JobTags { get; set; }

        public Job()
        {
            this.Tasks = new HashSet<Task>();
            this.JobTags = new HashSet<Tag>();
        }


        /*SiteViews / Popularity - до колко програмиста
 * е достигнала работата, т.е. колко 
 * програмиста са я отворили и прочели на 
 * сайта (статистика за този, който я е пуснал)
        */


        //public string ImageUrl { get; set; }

        //public int Mileage { get; set; }

        //public string Doors { get; set; }

        //public string FuelType { get; set; }

        //public int EngineVolume { get; set; }

        //public virtual ICollection<Task> Extras { get; set; }

        //public virtual User Owner { get; set; }
    }
}
