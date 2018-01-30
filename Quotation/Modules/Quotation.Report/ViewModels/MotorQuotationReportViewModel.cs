using Microsoft.Practices.Unity;
using CrystalDecisions.CrystalReports.Engine;
using Quotation.Infrastructure.Base;
using Quotation.Infrastructure.Constants;
using Quotation.Infrastructure.Events;
using Quotation.Infrastructure.Interfaces;
using Quotation.ReportModule.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Regions;
using System.Windows;
using SAPBusinessObjects.WPF.Viewer;
using Quotation.Infrastructure;
using System.Windows.Input;
using System.IO;
using System.Drawing;

namespace Quotation.ReportModule.ViewModels
{
    public class MotorQuotationReportViewModel : ViewModelBase, INavigationAware
    {
        private ReportDocument reportSource = null;

        public MotorQuotationReportViewModel()
        {
            SubscribeEvents();
            IntializeCommands();
        }

        public CrystalReportsViewer ReportsViewer { get; set; }

        public ReportDocument ReportSource
        {
            get { return reportSource; }
            set { reportSource = value; OnPropertyChanged(); }
        }

        #region IEventAggregator
        public void SubscribeEvents()
        {
            this.EventAggregator.GetEvent<PrintReportEvent>().Subscribe(OnPrintReportEventw, true);
        }

        private void OnPrintReportEventw(PrintReportEventArgs arg)
        {
            if (arg != null && arg.PrintDataSet != null)
            {
                DataSet printDataSet = arg.PrintDataSet;
                DataTable imageDataTable = GetImageDataTable();
                if(imageDataTable != null)
                {
                    printDataSet.Tables.Add(imageDataTable);
                    SetReportSource(printDataSet);
                }
            }
        }

        private void SetReportSource(DataSet printDataSet)
        {
            try
            {
                ReportClass report = LoadReport("InsMgt", "rpt_MotorQuotation", System.IO.Directory.GetCurrentDirectory()) as ReportClass;
                if (report != null && ReportsViewer != null)
                {
                    TextObject InsuredName = (TextObject)report.ReportDefinition.ReportObjects["InsuredName"];
                    InsuredName.Text = printDataSet.Tables["DriverDetails"].Rows[0]["InsuredName"].ToString();

                    TextObject InsuredNRIC = (TextObject)report.ReportDefinition.ReportObjects["InsuredNRIC"];
                    InsuredNRIC.Text = printDataSet.Tables["DriverDetails"].Rows[0]["InsuredNRIC"].ToString();

                    //TextObject BizRegNo = (TextObject)report.ReportDefinition.ReportObjects["BizRegNo"];
                    //BizRegNo.Text = printDataSet.Tables["DriverDetails"].Rows[0]["BizRegNo"].ToString();

                    TextObject DateOfBirth = (TextObject)report.ReportDefinition.ReportObjects["DateOfBirth"];
                    DateOfBirth.Text = printDataSet.Tables["DriverDetails"].Rows[0]["DateOfBirth"].ToString();

                    TextObject Gender = (TextObject)report.ReportDefinition.ReportObjects["Gender"];
                    Gender.Text = printDataSet.Tables["DriverDetails"].Rows[0]["Gender"].ToString();

                    TextObject MaritalStatus = (TextObject)report.ReportDefinition.ReportObjects["MaritalStatus"];
                    MaritalStatus.Text = printDataSet.Tables["DriverDetails"].Rows[0]["MaritalStatus"].ToString();

                    TextObject Occupation = (TextObject)report.ReportDefinition.ReportObjects["Occupation"];
                    Occupation.Text = printDataSet.Tables["DriverDetails"].Rows[0]["Occupation"].ToString();

                    TextObject Industry = (TextObject)report.ReportDefinition.ReportObjects["Industry"];
                    Industry.Text = printDataSet.Tables["DriverDetails"].Rows[0]["Industry"].ToString();

                    TextObject LicenseDate = (TextObject)report.ReportDefinition.ReportObjects["LicenseDate"];
                    LicenseDate.Text = printDataSet.Tables["DriverDetails"].Rows[0]["LicenseDate"].ToString();

                    report.Database.Tables["OwnerDetails"].SetDataSource(printDataSet.Tables["OwnerDetails"]);
                    report.Database.Tables["VehicleDetails"].SetDataSource(printDataSet.Tables["VehicleDetails"]);
                    //report.Database.Tables["DriverDetails"].SetDataSource(printDataSet.Tables["DriverDetails"]);
                    report.Database.Tables["MIQuotation"].SetDataSource(printDataSet.Tables["InsuranceDetails"]);
                    report.Database.Tables["Images"].SetDataSource(printDataSet.Tables["Images"]);

                    ReportsViewer.ViewerCore.ReportSource = report;
                }
                else
                {
                    this.Container.Resolve<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService).ShowMessageAsnyc("Print Report", "Unable to load Crystal Report.\nPlease contact your administrator.");
                }
            }
            catch (Exception ex)
            {
                this.Container.Resolve<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService).ShowMessageAsnyc("Print Report", ex.Message);
            }
        }

        private object LoadReport(string DllName, string ClassName, string curAppPath)
        {
            object reportSource = null;
            try
            {
                reportSource = System.Reflection.Assembly.LoadFrom(curAppPath + "\\" + DllName + ".dll").CreateInstance(DllName + "." + ClassName);
            }
            catch (Exception ex)
            {
                reportSource = null;
            }

            return reportSource;
        }

        private DataTable GetImageDataTable()
        {
            DataTable imageDataTable = null;
            string imagePath = Directory.GetCurrentDirectory() + @"\Images\QTN.bmp";
            if(File.Exists(imagePath))
            {
                imageDataTable = new DataTable("Images", "Images");
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    Bitmap bitmap = new Bitmap(imagePath);
                    bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Bmp);
                    imageDataTable.Columns.Add("Image", typeof(byte[]));

                    var row = imageDataTable.NewRow();
                    row[0] = memoryStream.GetBuffer();
                    imageDataTable.Rows.Add(row);
                    imageDataTable.AcceptChanges();
                }
            }
            return imageDataTable;
        }
        #endregion //IEventAggregator

        #region ICommand
        private void IntializeCommands()
        {
            this.PrintReportCommand = new RelayCommand(this.ExecutePrintReportCommand, this.CanExecutePrintReportCommand);
            this.RefreshReportCommand = new RelayCommand(this.ExecuteRefreshReportCommand, this.CanExecuteRefreshReportCommand);
            this.ExportReportCommand = new RelayCommand(this.ExecuteExportReportCommand, this.CanExecuteExportReportCommand);
        }

        public ICommand PrintReportCommand { get; private set; }

        public bool CanExecutePrintReportCommand()
        {
            if (ReportsViewer != null && ReportsViewer.ViewerCore != null && ReportsViewer.ViewerCore.IsLoaded) return true;
            else return false;
        }

        public void ExecutePrintReportCommand()
        {
            this.ReportsViewer.ViewerCore.PrintReport();
        }

        public ICommand RefreshReportCommand { get; private set; }

        public bool CanExecuteRefreshReportCommand()
        {
            if (ReportsViewer != null && ReportsViewer.ViewerCore != null && ReportsViewer.ViewerCore.IsLoaded) return true;
            else return false;
        }

        public void ExecuteRefreshReportCommand()
        {
            this.ReportsViewer.ViewerCore.RefreshReport();
        }


        public ICommand ExportReportCommand { get; private set; }

        public bool CanExecuteExportReportCommand()
        {
            if (ReportsViewer != null && ReportsViewer.ViewerCore != null && ReportsViewer.ViewerCore.IsLoaded) return true;
            else return false;
        }

        public void ExecuteExportReportCommand()
        {
            this.ReportsViewer.ViewerCore.ExportReport();
        }
        #endregion //ICommand

        #region INavigationAware
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var navParameters = navigationContext.Parameters;
            if(navParameters != null)
            {
                DataSet reportDataDataSet = (DataSet)navParameters["ReportDataSet"];
                if(reportDataDataSet != null)
                {
                    DataTable imageDataTable = GetImageDataTable();
                    if (imageDataTable != null)
                    {
                        reportDataDataSet.Tables.Add(imageDataTable);
                        SetReportSource(reportDataDataSet);
                    }
                }
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
        #endregion //INavigationAware
    }
}
