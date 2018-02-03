using Quotation.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.LoginModule.ViewModels
{
    public class ClockTamperingDetectionViewViewModel : ViewModelBase
    {
        public ClockTamperingDetectionViewViewModel()
        {

        }

        private string warningMessage = "Clock Tampering Detected!";
        public string WarningMessage
        {
            get { return warningMessage; }
            set { warningMessage = value;
                OnPropertyChanged();
            }
        }

    }
}
