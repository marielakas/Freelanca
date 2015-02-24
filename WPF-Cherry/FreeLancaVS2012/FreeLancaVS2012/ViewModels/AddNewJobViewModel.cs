using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FreeLancaVS2012.Behavior;
using FreeLancaVS2012.Data;

namespace FreeLancaVS2012.ViewModels
{
    public class AddNewJobViewModel : ViewModelBase, IPageViewModel
    {
        public string Name
        {
            get { return "Add new job"; }
        }

        private ICommand createCommand;
        private ICommand addTodoCommand;

        #region title description dedline price category totalDifficulty
        private string title { get; set; }
        private string description { get; set; }
        private string deadline { get; set; }
        private double price { get; set; }
        private string category { get; set; }
        private string totalDifficulty { get; set; }

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

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                if (this.description != value)
                {
                    this.description = value;
                    this.OnPropertyChanged("Description");
                }
            }
        }

        public string Deadline
        {
            get
            {
                return this.deadline;
            }
            set
            {
                if (this.deadline != value)
                {
                    this.deadline = value;
                    this.OnPropertyChanged("Deadline");
                }
            }
        }

        public double Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (this.price != value)
                {
                    this.price = value;
                    this.OnPropertyChanged("Price");
                }
            }
        }

        public string Category
        {
            get
            {
                return this.category;
            }
            set
            {
                if (this.category != value)
                {
                    this.category = value;
                    this.OnPropertyChanged("Category");
                }
            }
        }

        public string TotalDifficulty
        {
            get
            {
                return this.totalDifficulty;
            }
            set
            {
                if (this.totalDifficulty != value)
                {
                    this.totalDifficulty = value;
                    this.OnPropertyChanged("TotalDifficulty");
                }
            }
        } 
        #endregion

        public virtual ObservableCollection<TaskViewModel> TasksList { get; set; }

        public ICommand Create
        {
            get
            {
                if (this.createCommand == null)
                {
                    this.createCommand = new RelayCommand(this.HandleCreateListCommand);
                }
                return this.createCommand;
            }
        }
        public ICommand AddNewTask
        {
            get
            {
                if (this.addTodoCommand == null)
                {
                    this.addTodoCommand = new RelayCommand(this.HandleAddNewTaskCommand);
                }
                return this.addTodoCommand;
            }
        }
        
        private void HandleAddNewTaskCommand(object parameter)
        {
            this.TasksList.Add(new TaskViewModel()
            {
                Difficulty = "2"
            });
        }

        private void HandleCreateListCommand(object parameter)
        {
            DataPersister.CreateNewTodosList(this.Title ,this.description,DateTime.Now,//this.deadline,
                this.price,this.category,this.totalDifficulty,this.TasksList.Where(t=>!string.IsNullOrEmpty(t.Name)));
            this.Title = "";
            this.Description = "";
            this.Deadline = "";
            this.price = 0.0d;
            this.category = "";
            this.totalDifficulty = "1";
            
            this.TasksList.Clear();
        }

        public AddNewJobViewModel()
        {
            this.TasksList = new ObservableCollection<TaskViewModel>();
            this.TasksList.Add(new TaskViewModel()
            {
                Name = "Task" + TasksList.Count + 1 + ": ",
                Difficulty = "2"
            });
        }












        public virtual ICollection<TagViewModel> TagsList { get; set; }



        //private ObservableCollection<TaskViewModel> jobToAdd;
        //private ObservableCollection<TagViewModel> jobToAdd;
        //public JobDetailedViewModel JobToAdd
        //{
        //    get { return jobToAdd; }
        //    set { jobToAdd = value; }
        //}



        
    }
}
