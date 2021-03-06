﻿using Quotation.Core;
using Quotation.Infrastructure.Base;
using Quotation.Infrastructure.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Quotation.LoginModule.ViewModels
{
    public class UsernameTitlebarViewModel : ViewModelBase
    {
        private string username = "Welcome!";
        private Visibility canUserNameVisible = Visibility.Visible;

        public UsernameTitlebarViewModel()
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
                            if (arg.User != null)
                            {
                                User user = arg.User;
                                this.Username = user.Name;
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
