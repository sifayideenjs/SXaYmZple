using Quotation.Infrastructure.Base;
using Quotation.Infrastructure.Events;
using Quotation.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Quotation.DashboardModule.ViewModels
{
    public class UsernameTitlebarCommandsViewModel : ViewModelBase
    {
        private string username = "Welcome!";
        private Visibility canUserNameVisible = Visibility.Visible;

        public UsernameTitlebarCommandsViewModel()
        {
            SubscribeEvents();
        }

        #region Properties
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged();
            }
        }

        public Visibility CanUserNameVisible
        {
            get { return canUserNameVisible; }
            set
            {
                canUserNameVisible = value;
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
                            if(arg.User != null)
                            {
                                User user = arg.User;
                                this.Username = user.Username;
                                //this.CanUserNameVisible = Visibility.Visible;
                            }
                            break;
                        }
                    case "SignUp":
                        {
                            break;
                        }
                    case "Logout":
                        {
                            this.Username = "Welcome!";
                            //this.CanUserNameVisible = Visibility.Collapsed;
                            break;
                        }
                }
            }
        }
        #endregion //EventAggregation
    }
}