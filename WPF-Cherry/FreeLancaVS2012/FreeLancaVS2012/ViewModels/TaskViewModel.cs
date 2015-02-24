using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FreeLancaVS2012.Behavior;
using FreeLancaVS2012.Data;

namespace FreeLancaVS2012.ViewModels
{
    public class TaskViewModel : ViewModelBase
    {
        private string name;
        private ICommand changeStateCommand;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    this.OnPropertyChanged("Name");
                }
            }
        }

        public string Difficulty { get; set; }
        public ICommand ChangeState
        {
            get
            {
                if (this.changeStateCommand == null)
                {
                    this.changeStateCommand = new RelayCommand(this.HandleChangeStateCommand);
                }
                return this.changeStateCommand;
            }
        }

        private void HandleChangeStateCommand(object parameter)
        {
            DataPersister.ChangeState(this.Id);
        }

        public int Id { get; set; }

        public bool Pending { get; set; }
    }
}
