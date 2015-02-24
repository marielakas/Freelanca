using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FreeLancaVS2012.Behavior;

namespace FreeLancaVS2012.ViewModels
{
    public class TagViewModel: ViewModelBase, IPageViewModel
    {
        private ICommand getAllTags;

        public ICommand GetAllTags
        {
            get
            {
                if (this.getAllTags == null)
                {
                    this.getAllTags= new RelayCommand(this.HandleGetAllTagsCommand);
                }

                return this.getAllTags;
            }
        }

        private void HandleGetAllTagsCommand(object parameter)
        {
            // TODO: Implemet in DataPersister
            throw new NotImplementedException();
        }

        public string Name
        {
            get 
            {
                return "All tags";
            }
        }
    }
}
