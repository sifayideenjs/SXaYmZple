using Quotation.Infrastructure.Base;
using Quotation.Infrastructure.Events;
using Quotation.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.LoginModule.ViewModels
{
    public class AdministrationTitlebarViewModel : ViewModelBase
    {
        private string text = "Administration";
        public AdministrationTitlebarViewModel()
        {
            SubscribeEvents();
        }

        #region Properties
        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                OnPropertyChanged();
            }
        }
        #endregion //Properties

        #region EventAggregation
        private void SubscribeEvents()
        {
            this.EventAggregator.GetEvent<LoginEvent>().Subscribe(OnLoginEvent);
        }

        private void OnLoginEvent(LoginEventArgs arg)
        {
            if (arg != null)
            {
                switch (arg.ActionType)
                {
                    case "Login":
                        {
                            break;
                        }
                    case "SignUp":
                        {
                            break;
                        }
                    case "Logout":
                        {
                            break;
                        }
                }
            }
        }
        #endregion //EventAggregation
    }
}
