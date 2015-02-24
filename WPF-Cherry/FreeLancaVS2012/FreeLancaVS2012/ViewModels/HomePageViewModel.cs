using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using FreeLancaVS2012.Behavior;
using FreeLancaVS2012.Data;
using FreeLancaVS2012.Helpers;
using FreeLancaVS2012.Models;

namespace FreeLancaVS2012.ViewModels
{
    public class HomePageViewModel : ViewModelBase, IPageViewModel
    {
        public event EventHandler<NavigationSuccessArgs> NavigationSuccess;

        private ObservableCollection<JobViewModel> myJobs { get; set; }
        public IEnumerable<JobViewModel> MyJobs
        {
            get
            {
                if (this.myJobs == null)
                {
                    this.MyJobs = DataPersister.GetMyJobsList();
                }
                return this.myJobs;
            }
            set
            {
                if (this.myJobs == null)
                {
                    this.myJobs = new ObservableCollection<JobViewModel>();
                }
                this.myJobs.Clear();
                foreach (var item in value)
                {
                    this.myJobs.Add(item);
                }
            }
        }
        private ObservableCollection<JobViewModel> postedJobs { get; set; }
        public IEnumerable<JobViewModel> PostedJobs
        {
            get
            {
                if (this.postedJobs == null)
                {
                    this.PostedJobs = DataPersister.GetPostedJobsList();
                }
                return this.postedJobs;
            }
            set
            {
                if (this.postedJobs == null)
                {
                    this.postedJobs = new ObservableCollection<JobViewModel>();
                }
                this.postedJobs.Clear();
                foreach (var item in value)
                {
                    this.postedJobs.Add(item);
                }
            }
        }

        private ICommand viewMyJobsDetailsCommand;
        public ICommand ViewMyJobsDetails
        {
            get
            {
                if (this.viewMyJobsDetailsCommand == null)
                {
                    this.viewMyJobsDetailsCommand = new RelayCommand(this.HandleViewMyJobsDetailsCommand);
                }
                return this.viewMyJobsDetailsCommand;
            }
        }


        private ICommand viewPostedJobsDetailsCommand;
        public ICommand ViewPostedJobsDetails
        {
            get
            {
                if (this.viewPostedJobsDetailsCommand == null)
                {
                    this.viewPostedJobsDetailsCommand = new RelayCommand(this.HandleViewPostedJobsDetailsCommand);
                }
                return this.viewPostedJobsDetailsCommand;
            }
        }



        private ICommand addNewJobRequestCommand;
        public ICommand AddNewJobRequest
        {
            get
            {
                if (this.addNewJobRequestCommand == null)
                {
                    this.addNewJobRequestCommand = new RelayCommand(this.HandleAddNewJobRequestCommand);
                }
                return this.addNewJobRequestCommand;
            }
        }

        public string Name
        {
            get
            {
                return "Home Page";
            }
        }

        private void HandleViewMyJobsDetailsCommand(object parameter)
        {
            var page = "myjobs";
            this.RaiseNavigation(page);
        }

        private void RaiseNavigation(string page)
        {
            if (this.NavigationSuccess != null)
            {
                this.NavigationSuccess(this, new NavigationSuccessArgs(page));
            }
        }

        private void HandleViewPostedJobsDetailsCommand(object parameter)
        {
            var page = "mypostedjobs";
            this.RaiseNavigation(page);
        }

        private void HandleAddNewJobRequestCommand(object parameter)
        {
            var page = "addnewjob";
            this.RaiseNavigation(page);
        }
    }
}
