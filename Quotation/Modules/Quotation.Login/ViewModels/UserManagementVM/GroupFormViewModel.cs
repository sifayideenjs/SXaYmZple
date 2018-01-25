using Quotation.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.LoginModule.ViewModels
{
    public class GroupFormViewModel : ViewModelBase
    {
        private int id = 0;
        private string name = string.Empty;
        private bool isSelected = false;

        public GroupFormViewModel(int id, string name, GroupViewModel parent)
        {
            this.id = id;
            this.name = name;
            this.Parent = parent;
        }

        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public bool IsSelected
        {
            get
            {
                return isSelected;
            }
            set
            {
                isSelected = value;
                if (Parent != null) Parent.IsModified = true;
                OnPropertyChanged();
            }
        }

        public GroupViewModel Parent { get; set; }
    }
}
