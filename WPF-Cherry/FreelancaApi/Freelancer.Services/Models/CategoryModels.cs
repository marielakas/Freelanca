using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Freelancer.Services.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class CategoryDetailedModel : CategoryModel
    {
        public virtual ICollection<JobModel> Jobs { get; set; }
    }
}