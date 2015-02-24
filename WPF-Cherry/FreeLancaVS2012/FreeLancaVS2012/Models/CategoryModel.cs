﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeLancaVS2012.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
      
    }

    public class CategoryDetailedModel: CategoryModel
    {
        public virtual ICollection<JobModel> Jobs { get; set; }
    }
}
