using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FreeLancaVS2012.Behavior;

namespace FreeLancaVS2012.ViewModels
{
    public class CategoryViewModel:ViewModelBase, IPageViewModel
    {
        private ICommand getAllCategories;

        public string Name
        {
            get
            {
                return "Categories form";
            }
        }

        public ICommand GetAllCategories
        {
            get
            {
                if (this.getAllCategories == null)
                {
                    this.getAllCategories = new RelayCommand(this.HandleGetAllCategoriesCommand);
                }
                return this.getAllCategories;
            }
        }

        private void HandleGetAllCategoriesCommand(object parameter)
        {
            //TODO: Implement GetAllCategories in DataPersister
            throw new NotImplementedException();
        }
    }
}
