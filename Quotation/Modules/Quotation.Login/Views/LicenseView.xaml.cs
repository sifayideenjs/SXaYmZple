﻿using Quotation.LoginModule.ViewModels;
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

namespace Quotation.LoginModule.Views
{
    /// <summary>
    /// Interaction logic for LicenseView.xaml
    /// </summary>
    public partial class LicenseView : UserControl
    {
        public LicenseView(LicenseViewViewModel viewmodel)
        {
            InitializeComponent();
            this.DataContext = viewmodel;
        }
    }
}
