using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.ReportModule.Interfaces
{
    public interface IReportModule
    {
        CrystalDecisions.CrystalReports.Engine.ReportDocument ReportSource { get; set; }
    }
}
