using System.Windows.Data;
using FreeLancaVS2012.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FreeLancaVS2012.ViewModels
{
    public class MyJobsViewModel : ViewModelBase, IPageViewModel
    {
        //private ICommand createCommand;

        //private ICommand addTaskCommand;

        private string title;
        private ObservableCollection<JobDetailedViewModel> myJobsList;

        public ObservableCollection<TaskViewModel> Tasks { get; set; }

        public string Name
        {
            get
            {
                return "My Jobs";
            }
        }

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

        public IEnumerable<JobDetailedViewModel> MyJobsList
        {
            get
            {
                if (this.myJobsList == null)
                {
                    this.MyJobsList = DataPersister.GetDetailedMyJobsList();
                }
                return this.myJobsList;
            }
            set
            {
                if (this.myJobsList == null)
                {
                    this.myJobsList = new ObservableCollection<JobDetailedViewModel>();
                }
                this.myJobsList.Clear();
                foreach (var item in value)
                {
                    this.myJobsList.Add(item);
                }
            }
        }

       
        private int currentJobIndex;

        void view_CurrentChanged(object sender, EventArgs e)
        {
            OnPropertyChanged("CurrentJob");
        }

        
       
        public JobDetailedViewModel CurrentJob
        {
            get
            {
                return this.MyJobsList.ElementAt(currentJobIndex);
            }
        }
    
 

        public MyJobsViewModel()
        {
            this.Tasks = new ObservableCollection<TaskViewModel>();
            this.Tasks.Add(new TaskViewModel()
            {
                Name = "sample"
            });
    
            currentJobIndex = 0;

            var view = CollectionViewSource.GetDefaultView(this.myJobsList);
            if (view!=null)
            {
                view.CurrentChanged += new EventHandler(view_CurrentChanged);
            }
            
        }
    }
}
