using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Regions;
using Quotation.Infrastructure.Base;
using Quotation.Infrastructure.Constants;
using Quotation.Infrastructure.Events;
using Quotation.ReportModule.Interfaces;
using Quotation.ReportModule.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using Quotation.Infrastructure.Interfaces;

namespace Quotation.ReportModule
{
    public class ReportModule : PrismBaseModule
    {
        public ReportModule(IUnityContainer unityContainer, IRegionManager regionManager) : base(unityContainer, regionManager)
        {
            Prism.Unity.UnityExtensions.RegisterTypeForNavigation<MotorQuotationReport>(unityContainer, PopupNames.ReportModule_Motor);
        }
    }
}