using FreeLancaVS2012.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeLancaVS2012.ViewModels
{
    public class PostedJobsViewModel : ViewModelBase, IPageViewModel
    {
        private string title;

        private ObservableCollection<JobDetailedViewModel> postedJobsList;

        public ObservableCollection<TaskViewModel> Tasks { get; set; }

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                if (this.title != value)
                {
                    this.title = value;
                    this.OnPropertyChanged("Title");
                }
            }
        }

        public IEnumerable<JobDetailedViewModel> MyPostedJobsList
        {
            get
            {
                if (this.postedJobsList == null)
                {
                    this.MyPostedJobsList = DataPersister.GetDetailedPostedJobsList();
                }
                return this.postedJobsList;
            }
            set
            {
                if (this.postedJobsList == null)
                {
                    this.postedJobsList = new ObservableCollection<JobDetailedViewModel>();
                }
                this.postedJobsList.Clear();
                foreach (var item in value)
                {
                    this.postedJobsList.Add(item);
                }
            }
        }

        public PostedJobsViewModel()
        {
            this.Tasks = new ObservableCollection<TaskViewModel>();
            this.Tasks.Add(new TaskViewModel()
            {
                Name = "sample"
            });
        }

        public string Name
        {
            get
            {
                return "Posted Jobs";
            }
        }
        
    }
}
