using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using FreeLancaVS2012.Behavior;
using FreeLancaVS2012.Data;
using FreeLancaVS2012.Helpers;

namespace FreeLancaVS2012.ViewModels
{
    public class AppViewModel : ViewModelBase, IPageViewModel
    {
        #region Constructor - Init START PAGE
        public AppViewModel()
        {
            this.ViewModels = new List<IPageViewModel>();

            var homePageVM = new HomePageViewModel();
            homePageVM.NavigationSuccess += this.NavigateToPage;
            this.ViewModels.Add(homePageVM); // Index 0

            var myJobsPageVM = new MyJobsViewModel();
            this.ViewModels.Add(myJobsPageVM); // Index 1

            var searchJobsPage = new SearchJobsViewModel();
            this.ViewModels.Add(searchJobsPage); //Index 2

            var postedJobsPageVM = new PostedJobsViewModel();
            this.ViewModels.Add(postedJobsPageVM); // Index 3

            var addNewJobPageVM = new AddNewJobViewModel();
            this.ViewModels.Add(addNewJobPageVM); // Index 4
            
            //TODO: Add other pages
            
            var loginVM = new LoginRegisterFormViewModel();
            loginVM.LoginSuccess += this.LoginSuccessful;
            this.LoginRegisterVM = loginVM;

            this.CurrentViewModel = this.LoginRegisterVM;
        } 
        #endregion

        public string Username { get; set; }
        public string Massage { get; set; }

        #region CurrentViewModel -> currentPAGE!
        private IPageViewModel currentViewModel;
        public IPageViewModel CurrentViewModel
        {
            get
            {
                return this.currentViewModel;
            }
            set
            {
                this.currentViewModel = value;
                this.OnPropertyChanged("CurrentViewModel");
            }
        } 
        #endregion
        
        private bool loggedInUser = false;
        public bool LoggedInUser
        {
            get
            {
                return this.loggedInUser;
            }
            set
            {
                this.loggedInUser = value;
                this.OnPropertyChanged("LoggedInUser");
            }
        }

        private ICommand changeViewModelCommand;
        public ICommand ChangeViewModel
        {
            get
            {
                if (this.changeViewModelCommand == null)
                {
                    this.changeViewModelCommand =
                        new RelayCommand(this.HandleChangeViewModelCommand);
                }
                return this.changeViewModelCommand;
            }
        }

        private ICommand logoutCommand;
        public ICommand Logout
        {
            get
            {
                if (this.logoutCommand == null)
                {
                    this.logoutCommand = new RelayCommand(this.HandleLogoutCommand);
                }
                return this.logoutCommand;
            }
        }
        
        public void HandleLogoutCommand(object parameter)
        {
            bool isUserLoggedOut = DataPersister.LogoutUser();
            if (isUserLoggedOut)
            {
                this.Username = "";
                this.LoggedInUser = false;
                //this.CurrentViewModel = this.LoginRegisterVM;
                this.HandleChangeViewModelCommand(this.LoginRegisterVM);
            }
        }
        
        public LoginRegisterFormViewModel LoginRegisterVM { get; set; }

        public List<IPageViewModel> ViewModels { get; set; }

        private void HandleChangeViewModelCommand(object parameter)
        {
            var newCurrentViewModel = parameter as IPageViewModel;
            this.CurrentViewModel = newCurrentViewModel;
        }

        public void LoginSuccessful(object sender, LoginSuccessArgs e)
        {
            this.Username = e.Username;
            this.LoggedInUser = true;
            this.HandleChangeViewModelCommand(this.ViewModels[0]);
        }

        private void HandleGoToPostedJobsPageCommand(object parameter)
        {
            this.HandleChangeViewModelCommand(this.ViewModels[3]);
        }

        public void NavigateToPage(object sender, NavigationSuccessArgs e)
        {
            string pageToGo = e.PageName.ToLower();
            switch (pageToGo)
            {
                case "homepage":
                    this.HandleChangeViewModelCommand(this.ViewModels[0]);
                    break;
                case "myjobs":
                    this.HandleChangeViewModelCommand(this.ViewModels[1]);
                    break;
                case "mypostedjobs":
                    this.HandleChangeViewModelCommand(this.ViewModels[3]);
                    break;
                case "addnewjob":
                    this.HandleChangeViewModelCommand(this.ViewModels[4]);
                    break;
            }
        }



        public string Name
        {
            get 
            {
                return "Post new job";
            }
        }
    }
}