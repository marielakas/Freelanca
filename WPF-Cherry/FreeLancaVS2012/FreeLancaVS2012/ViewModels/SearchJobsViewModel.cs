using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FreeLancaVS2012.Behavior;
using FreeLancaVS2012.Data;
using FreeLancaVS2012.Helpers;

namespace FreeLancaVS2012.ViewModels
{
    public class SearchJobsViewModel : ViewModelBase, IPageViewModel
    {
        public event EventHandler<SearchSuccessArgs> SearchSuccess;

        public string SearchQuery { get; set; }

        private ICommand searchJobs;
        public ICommand SearchJobs
        {
            get
            {
                if (this.searchJobs == null)
                {
                        this.searchJobs = new RelayCommand(this.HandleSearchJobsCommand);
                }
                return this.searchJobs;
            }
        }

        private void HandleSearchJobsCommand(object parameter)
        {
            if (this.SearchQuery != null || this.SearchQuery != "")
            {
                this.MatchedJobs = DataPersister.SearchJob(this.SearchQuery);
                
            }
        }

        private ObservableCollection<JobDetailedViewModel> matchedJobs { get; set; }
        public IEnumerable<JobDetailedViewModel> MatchedJobs
        {
            get
            {
                if (this.matchedJobs == null)
                {
                    this.matchedJobs = new ObservableCollection<JobDetailedViewModel>();
                }
                return this.matchedJobs;
            }
            set
            {
                if (this.matchedJobs == null)
                {
                    this.matchedJobs = new ObservableCollection<JobDetailedViewModel>();
                }
                this.matchedJobs.Clear();
                foreach (var item in value)
                {
                    this.matchedJobs.Add(item);
                }
            }
        }

        public string Name
        {
            get
            {
                return "Search";
            }
        }

        private void RaiseSearch(string page)
        {
            if (this.SearchSuccess != null)
            {
                this.SearchSuccess(this, new SearchSuccessArgs(page));
            }
        }
    }
}
