using Quotation.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quotation.MotorInsuranceModule.Models;

namespace Quotation.MotorInsuranceModule.ViewModels
{
    public class QuotationViewModel : ViewModelBase
    {
        private readonly MIQuotation quotation;
        private readonly OwnerDetail ownerDetail;
        private readonly VehicleDetail vehicleDetail;

        public QuotationViewModel(MIQuotation quotation, OwnerDetail ownerDetail, VehicleDetail vehicleDetail)
        {
            this.quotation = quotation;
            this.ownerDetail = ownerDetail;
            this.vehicleDetail = vehicleDetail;
        }
        public QuotationViewModel(MIQuotation quotation)
        {
            this.quotation = quotation;
            //this.ownerDetail = ownerDetail;
            //this.vehicleDetail = vehicleDetail;
#if DEBUG
            this.ownerDetail = new OwnerDetail() { Name = "Sifayideen" };
#endif
        }

        public MIQuotation Quotation { get { return quotation; } }

        public OwnerDetail OwnerDetail { get { return ownerDetail; } }

        public VehicleDetail VehicleDetail { get { return vehicleDetail; } }
    }
}
