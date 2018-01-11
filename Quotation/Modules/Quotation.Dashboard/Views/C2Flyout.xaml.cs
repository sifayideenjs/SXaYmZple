﻿using MahApps.Metro.Controls;
using Quotation.Infrastructure.Constants;
using Quotation.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Quotation.DashboardModule.Views
{
    /// <summary>
    /// Interaktionslogik für C2Flyout.xaml
    /// </summary>
    public partial class C2Flyout : Flyout, IFlyoutView
    {
        public C2Flyout()
        {
            InitializeComponent();
        }

        public string FlyoutName
        {
            get
            {
                return FlyoutNames.ModuleAC2Flyout;
            }
        }
    }
}
