   M S B A M L   `   `   `  ���� Y  UQuotation.MotorInsuranceModule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:Quotation.MotorInsuranceModule.Views.Wizards,Quotation.MotorInsuranceModule.Views.Wizards  S OQuotation.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullyRclr-namespace:Quotation.Infrastructure.Constants;assembly=Quotation.Infrastructure"Quotation.Infrastructure.Constants yRclr-namespace:Quotation.Infrastructure.Behaviors;assembly=Quotation.Infrastructure"Quotation.Infrastructure.Behaviors {Sclr-namespace:Quotation.Infrastructure.Converters;assembly=Quotation.Infrastructure#Quotation.Infrastructure.Converters L HQuotation.Styling, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullbCclr-namespace:Quotation.Styling.Controls;assembly=Quotation.StylingQuotation.Styling.Controls C    =Quotation.MotorInsuranceModule.Views.Wizards.QuotationSummary   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Llocal:clr-namespace:Quotation.MotorInsuranceModule.Views.Wizards     T PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f8metro,http://metro.mahapps.com/winfx/xaml/controls  U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullX	 TMaterialDesignThemes.MahApps, Version=0.0.11.0, Culture=neutral, PublicKeyToken=nullBmaterial1http://materialdesigninxaml.net/winfx/xaml/themes  	 P
 LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8'prismlibhttp://prismlibrary.com/ 
 )prismhttp://www.codeplex.com/prism 
 einfConstantsRclr-namespace:Quotation.Infrastructure.Constants;assembly=Quotation.Infrastructure 
 einfBehaviorsRclr-namespace:Quotation.Infrastructure.Behaviors;assembly=Quotation.Infrastructure 
 ginfConvertersSclr-namespace:Quotation.Infrastructure.Converters;assembly=Quotation.Infrastructure 
 QcontrolCclr-namespace:Quotation.Styling.Controls;assembly=Quotation.Styling 
   � DataContext  ��  � 	Resources A  ;Quotation.Infrastructure.Converters.YesNoToBooleanConverter   YesNoToBooleanConverterE  ?Quotation.Infrastructure.Converters.ZeroCollapsedNonZeroVisible  ZeroCollapsedNonZeroVisible��%   &	        &	          .���  � RowDefinitions �� $��* ��� $
��auto �.+��� $��0��$
��Auto=�.���  �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $��0��$��Owner / Insured Details��.��� $��1��  �� *QuotationViewModel+ � ColumnDefinitions �� $	��180 ��� $	��300��$	��350 ��� $	��100��$	��120 ��� $	��180 ��� $	��300��$	��350 � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��0��$��Center=�$��14(�.��Insured Name:�� $��0��$��1��$��14(�$��5q����� *OwnerDetail.Name+ �� Mode$ TwoWay=��� $��1��$��0��$��Center=�$��14(�.��
Contact:�� $��1��$��1��$��14(�$��5q����� *OwnerDetail.Contact+$ TwoWay=��� $��2��$��0��$��Center=�$��14(�.��NRIC:�� $��2��$��1��$��14(�$��5q����� *OwnerDetail.NRIC+$ TwoWay=��� $��3��$��0��$��Center=�$��14(�.��Biz Reg No:�� $��3��$��1��$��14(�$��5q����� *OwnerDetail.BizRegNo+$ TwoWay=��� $��4��$��0��$��Center=�$��14(�.��Date of Birth:�� $��4��$��1��$��14(�$��5q����� *OwnerDetail.DateOfBirth+$ TwoWay=��� $��5��$��0��$��Center=�$��14(�.��	Gender:�� $��5��$��1��$��14(�$��5q����� *OwnerDetail.Gender+$ TwoWay=��� $��6��$��0��$��Center=�$��14(�.��Marital Status:�� $��6��$��1��$��14(�$��5q����� *OwnerDetail.MaritalStatus+$ TwoWay=��� $��0��$��3��$��Center=�$��14(�.��Occupation:�� $��0��$��4��$��14(�$��5q����� *OwnerDetail.Occupation+$ TwoWay=��� $��1��$��3��$��Center=�$��14(�.��	Industry:�� $��1��$��4��$��14(�$��5q����� *OwnerDetail.Industry+$ TwoWay=��� $��2��$��3��$��Center=�$��14(�.��License Date:�� $��2��$��4��$��14(�$��5q����� *OwnerDetail.LicenseDate+$ TwoWay=��� $��3��$��3��$��Center=�$��14(�.��Email:�� $��3��$��4��$��14(�$��5q����� *OwnerDetail.Email+$ TwoWay=��� $��4��$��3��$��Center=�$��14(�.��
Address:�� $��4��$��4��$��2��$��14(�$��5q����� *OwnerDetail.Address+$ TwoWay=��� $��1��$��Driver Details��y��� *(&QuotationViewModel.DriverDetails.Count+ �� 	Converter# [ .��&   System.Windows.Controls.DataGrid    AzureDataGrid#��[    AutoGenerateColumns .     
IsReadOnly . ���� *" QuotationViewModel.DriverDetails+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn	   Header$	 Insured Name��
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 200 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *InsuredName+  $	 Insured NRIC��$	
 130  �� *InsuredNRIC+  $	 
Biz Reg No��$	
 120  �� *
BizRegNo+  $	 Date of Birth��$	
 160  �� *DateOfBirth+  $	 Gender��$
 80  �� *Gender+  $	 Marital Status��$	
 120  �� *MaritalStatus+# [    $	 
Occupation��$	
 200  �� *
Occupation+  $	 Industry��$	
 200  �� *
Industry+  $	 License Date��$	
 160  �� *LicenseDate+�� $��2��$��Vehicle Details��.��� $��1��  �� *QuotationViewModel+ �� $	��180 ��� $	��300��$	��350 ��� $	��100��$	��120 ��� $	��180 ��� $	��300��$	��350 � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��0��$��Center=�$��14(�.��Make:�� $��0��$��1��$��14(�$��5q����� *VehicleDetail.Make+$ TwoWay=��� $��1��$��0��$��Center=�$��14(�.��Model:�� $��1��$��1��$��14(�$��5q����� *VehicleDetail.VehicleModel+$ TwoWay=��� $��2��$��0��$��Center=�$��14(�.��	Capacity:�� $��2��$��1��$��14(�$��5q����� *VehicleDetail.Capacity+$ TwoWay=��� $��3��$��0��$��Center=�$��14(�.��
Tonnage:�� $��3��$��1��$��14(�$��5q����� *VehicleDetail.Tonnage+$ TwoWay=��� $��4��$��0��$��Center=�$��14(�.��Date of Reg:�� $��4��$��1��$��14(�$��5q����� * VehicleDetail.DateOfRegistered+$ TwoWay=��� $��5��$��0��$��Center=�$��14(�.��
Year Made:�� $��5��$��1��$��14(�$��5q����� *VehicleDetail.YearMade+$ TwoWay=��� $��6��$��0��$��Center=�$��14(�.��Reg No Plate:�� $��6��$��1��$��14(�$��5q����� *VehicleDetail.RegNo+$ TwoWay=��� $��0��$��3��$��Center=�$��14(�.��Parallel Import:�� $��0��$��4��$��14(�$��5q����� *VehicleDetail.ParallelImport+$ TwoWay=��� $��1��$��3��$��Center=�$��14(�.��Off Peak Vehicle:�� $��1��$��4��$��14(�$��5q����� *VehicleDetail.OffPeakVehicle+$ TwoWay=��� $��2��$��3��$��Center=�$��14(�.��
NCD (%):�� $��2��$��4��$��14(�$��5q����� *VehicleDetail.NCD+$ TwoWay=��� $��3��$��3��$��Center=�$��14(�.��Existing Insurer:�� $��3��$��4��$��14(�$��5q����� *VehicleDetail.ExistingInsurer+$ TwoWay=��� $��4��$��3��$��Center=�$��14(�.��Previous Reg No:�� $��4��$��4��$��14(�$��5q����� *VehicleDetail.PreviousRegNo+$ TwoWay=��� $��5��$��3��$��Center=�$��14(�.��Claims (Past 3 years):�� $��5��$��4��$��3��$��14(�$��5q����� *VehicleDetail.Claims+$ TwoWay=��� $��3��$��Insurance Details��.��� $��1��  �� *QuotationViewModel+ �� $	��180 ��� $	��300��$	��350 ��� $	��100��$	��120 ��� $	��180 ��� $	��300��$	��350 � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��0��$��Center=�$��14(�.��Insurance Expiry Date:�� $��0��$��1��$��14(�$��5q����� *,*CurrentInsuranceDetail.InsuranceExpiryDate+$ TwoWay=��� $��1��$��0��$��Center=�$��14(�.��Road Tax Expiry Date:�� $��1��$��1��$��14(�$��5q����� **(CurrentInsuranceDetail.RoadTaxExpiryDate+$ TwoWay=��� $��2��$��0��$��Center=�$��14(�.��Previous Dealer:�� $��2��$��1��$��14(�$��5q����� *'%CurrentInsuranceDetail.PreviousDealer+$ TwoWay=��� $��0��$��3��$��Center=�$��14(�.��	Agency:�� $��0��$��4��$��14(�$��5q����� *CurrentInsuranceDetail.Agency+$ TwoWay=��� $��1��$��3��$��Center=�$��14(�.��Finance Bank:�� $��1��$��4��$��14(�$��5q����� *$"CurrentInsuranceDetail.FinanceBank+$ TwoWay=��� $��2��$��3��$��Center=�$��14(�.��Previous Year Premium:�� $��2��$��4��$��14(�$��5q����� *(&CurrentInsuranceDetail.PrevYearPremium+$ TwoWay=��� $��1�� �� Orientation$ 
Horizontal=�$��Center=�$��5q�.+��� $��1��$��50��$��50�� * &MaterialDesignFloatingActionDarkButton#��[ $	��5 0q����� *DashboardCommand+.��'  !MaterialDesignThemes.Wpf.PackIcon  �	  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]] 	  Kind$
 Home=�$��30��$��30���� $��1��$��50��$��50��#��[ $	��5 0q����� *PrintQuotationCommand+.���� $��25��$��25��
������� J� OpacityMask !�  j� Stretch$
 Fill=�  appbar_printer !� Visual# �  