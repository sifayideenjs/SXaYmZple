   M S B A M L   `   `   `  ���� Y  UQuotation.MotorInsuranceModule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:Quotation.MotorInsuranceModule.Views$Quotation.MotorInsuranceModule.Views  S OQuotation.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullyRclr-namespace:Quotation.Infrastructure.Constants;assembly=Quotation.Infrastructure"Quotation.Infrastructure.Constants yRclr-namespace:Quotation.Infrastructure.Behaviors;assembly=Quotation.Infrastructure"Quotation.Infrastructure.Behaviors {Sclr-namespace:Quotation.Infrastructure.Converters;assembly=Quotation.Infrastructure#Quotation.Infrastructure.Converters L HQuotation.Styling, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullbCclr-namespace:Quotation.Styling.Controls;assembly=Quotation.StylingQuotation.Styling.Controls M    GQuotation.MotorInsuranceModule.Views.SearchWizards.RenewInsuranceDetail   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Dlocal2clr-namespace:Quotation.MotorInsuranceModule.Views     T PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f8metro,http://metro.mahapps.com/winfx/xaml/controls  U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullX	 TMaterialDesignThemes.MahApps, Version=0.0.11.0, Culture=neutral, PublicKeyToken=nullBmaterial1http://materialdesigninxaml.net/winfx/xaml/themes  	 P
 LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8'prismlibhttp://prismlibrary.com/ 
 )prismhttp://www.codeplex.com/prism 
 einfConstantsRclr-namespace:Quotation.Infrastructure.Constants;assembly=Quotation.Infrastructure 
 einfBehaviorsRclr-namespace:Quotation.Infrastructure.Behaviors;assembly=Quotation.Infrastructure 
 ginfConvertersSclr-namespace:Quotation.Infrastructure.Converters;assembly=Quotation.Infrastructure 
 QcontrolCclr-namespace:Quotation.Styling.Controls;assembly=Quotation.Styling 
   � 	Resources  A  ;Quotation.Infrastructure.Converters.YesNoToBooleanConverter   YesNoToBooleanConverterE  ?Quotation.Infrastructure.Converters.ZeroCollapsedNonZeroVisible  ZeroCollapsedNonZeroVisible��%   &	        &	          .��� -    �Name$
 root�� � RowDefinitions �� $
��Auto ��� $��* �.+�#  MaterialDesignThemes.Wpf.Card  $��0��  MaterialDesignBackground#���  $��0 5 5 0q�y��� *SearchFound+.���� $��0 0 0 10q�.+���  �� Orientation$ Vertical=�  MaterialDesignBody#���  $��	24,0,20,8q�.+�� $��0 10 0 0q� � DataContext �� *QuotationViewModel+ �� $
��Auto ��� $
��Auto ��� $��* �.+�]� $��0��$��0 5 5 5q���. .+��� $ 
Horizontal=�$��Right=�.+��� $��45��$��45�� * &MaterialDesignFloatingActionDarkButton#��[ $
��Left=�$��5 0 5 0q����� *!DataContext.AddQuotationCommand+ �� ElementName$
 root��.��'  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]   Kind$
 Plus=�$��35��$��35���� $��45��$��45��#��[ $
��Left=�$��5 0 0 0q����� *#!DataContext.PrintQuotationCommand+$
 root��.��  $ Printer=�$��30��$��30���� $��0�� # MaterialDesignHeadlineTextBlock#��[ $��Center=�Insurance Details�� $��1��   MaterialDesignLightSeparator#��[ 
�������� $��2��{��� *IsQuotationAdded+ � ColumnDefinitions �� $	��180 ��� $	��300��$	��350 ��� $	��100��$	��120 ��� $	��180 ��� $	��300��$	��350 � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��0��$��Center=�$��14(�.��Insurance Expiry Date:(  "System.Windows.Controls.DatePicker  $��0��$��1��$��Center=�$��5q�   SelectedDate �� *,*CurrentInsuranceDetail.InsuranceExpiryDate+	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=� �� ValidatesOnExceptions .  �� NotifyOnValidationError .  �� ValidatesOnDataErrors . �� $��1��$��0��$��Center=�$��14(�.��Road Tax Expiry Date:  $��1��$��1��$��Center=�$��5q� �� **(CurrentInsuranceDetail.RoadTaxExpiryDate+$	 TwoWay=�$
 PropertyChanged=� .  .  . �� $��2��$��0��$��Center=�$��14(�.��Previous Dealer:�� $��2��$��1��*  $MahApps.Metro.Controls.TextBoxHelper   ClearTextButton . $��Center=�$��5q����� *'%CurrentInsuranceDetail.PreviousDealer+$	 TwoWay=�$
 PropertyChanged=� .  .  . �� $��3��$��0��$��Center=�$��14(�.��	Agency:�� $��3��$��1�� . $��Center=�$��5q����� *CurrentInsuranceDetail.Agency+$	 TwoWay=�$
 PropertyChanged=� .  .  . �� $��0��$��3��$��Center=�$��14(�.��Finance Bank:�� $��0��$��4�� . $��Center=�$��5q����� *$"CurrentInsuranceDetail.FinanceBank+$	 TwoWay=�$
 PropertyChanged=� .  .  . �� $��1��$��3��$��Center=�$��14(�.��Previous Year Premium:�� $��1��$��4��$��3�� . $	��Top=� �� TextWrapping$
 Wrap=� �� AcceptsReturn . $��5q����� *(&CurrentInsuranceDetail.PrevYearPremium+$	 TwoWay=�$
 PropertyChanged=� .  .  . ]� $��1����. y��� *SearchFound+.+�  $��3��#���  $��0 5 5 5q���. .���� $
��Auto=���.  .���� .+�9� $��Stretch=�$��Owner / Insured Details��  HeaderFontFamily#���  .���� $ Vertical=�#���  $��	24,0,20,8q�.+��  �� *QuotationViewModel+ �� $	��180 ��� $	��300��$	��350 ��� $	��100��$	��120 ��� $	��180 ��� $	��300��$	��350 � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��0��$��Center=�$��14(�.��Insured Name:�� $��0��$��1��$��14(�$��5q����� *OwnerDetail.Name+$	 TwoWay=��� $��1��$��0��$��Center=�$��14(�.��
Contact:�� $��1��$��1��$��14(�$��5q����� *OwnerDetail.Contact+$	 TwoWay=��� $��2��$��0��$��Center=�$��14(�.��NRIC:�� $��2��$��1��$��14(�$��5q����� *OwnerDetail.NRIC+$	 TwoWay=��� $��3��$��0��$��Center=�$��14(�.��Biz Reg No:�� $��3��$��1��$��14(�$��5q����� *OwnerDetail.BizRegNo+$	 TwoWay=��� $��4��$��0��$��Center=�$��14(�.��Date of Birth:�� $��4��$��1��$��14(�$��5q����� *OwnerDetail.DateOfBirth+$	 TwoWay=��� $��5��$��0��$��Center=�$��14(�.��	Gender:�� $��5��$��1��$��14(�$��5q����� *OwnerDetail.Gender+$	 TwoWay=��� $��6��$��0��$��Center=�$��14(�.��Marital Status:�� $��6��$��1��$��14(�$��5q����� *OwnerDetail.MaritalStatus+$	 TwoWay=��� $��0��$��3��$��Center=�$��14(�.��Occupation:�� $��0��$��4��$��14(�$��5q����� *OwnerDetail.Occupation+$	 TwoWay=��� $��1��$��3��$��Center=�$��14(�.��	Industry:�� $��1��$��4��$��14(�$��5q����� *OwnerDetail.Industry+$	 TwoWay=��� $��2��$��3��$��Center=�$��14(�.��License Date:�� $��2��$��4��$��14(�$��5q����� *OwnerDetail.LicenseDate+$	 TwoWay=��� $��3��$��3��$��Center=�$��14(�.��Email:�� $��3��$��4��$��14(�$��5q����� *OwnerDetail.Email+$	 TwoWay=��� $��4��$��3��$��Center=�$��14(�.��
Address:�� $��4��$��4��$��2��$��14(�$��5q����� *OwnerDetail.Address+$	 TwoWay=���   MaterialDesignDivider#���  $��1��$��Stretch=� J� SnapsToDevicePixels . 9� $��Stretch=�$��Driver Details��#���  y��� *(&QuotationViewModel.DriverDetails.Count+ �� 	Converter# [ .���� $ Vertical=�#���  $��	24,0,20,8q�.+�&   System.Windows.Controls.DataGrid   	 AzureDataGrid#��[	    AutoGenerateColumns .     
IsReadOnly . ���� *" QuotationViewModel.DriverDetails+   Columns 0	  *System.Windows.Controls.DataGridTextColumn	  ,
  &System.Windows.Controls.DataGridColumn 
  Header$ Insured Name�� 
  Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *InsuredName+	  $ Insured NRIC��$	 130  �� *InsuredNRIC+	  $ 
Biz Reg No��$	 120  �� *
BizRegNo+	  $ Date of Birth��$	 160  �� *DateOfBirth+	  $ Gender��$ 80  �� *Gender+	  $ Marital Status��$	 120  �� *MaritalStatus+# [  	  $ 
Occupation��$	 200  �� *
Occupation+	  $ Industry��$	 200  �� *
Industry+	  $ License Date��$	 160  �� *LicenseDate+�� #���  $��1��$��Stretch=� . 9� $��Stretch=�$��Vehicle Details��#���  .���� $ Vertical=�#���  $��	24,0,20,8q�.+�� $��1�� �� *QuotationViewModel+ �� $	��180 ��� $	��300��$	��350 ��� $	��100��$	��120 ��� $	��180 ��� $	��300��$	��350 � �� $
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
��Auto �.+��� $��0��$��0��$��Center=�$��14(�.��Make:�� $��0��$��1��$��14(�$��5q����� *VehicleDetail.Make+$	 TwoWay=��� $��1��$��0��$��Center=�$��14(�.��Model:�� $��1��$��1��$��14(�$��5q����� *VehicleDetail.VehicleModel+$	 TwoWay=��� $��2��$��0��$��Center=�$��14(�.��	Capacity:�� $��2��$��1��$��14(�$��5q����� *VehicleDetail.Capacity+$	 TwoWay=��� $��3��$��0��$��Center=�$��14(�.��
Tonnage:�� $��3��$��1��$��14(�$��5q����� *VehicleDetail.Tonnage+$	 TwoWay=��� $��4��$��0��$��Center=�$��14(�.��Date of Reg:�� $��4��$��1��$��14(�$��5q����� * VehicleDetail.DateOfRegistered+$	 TwoWay=��� $��5��$��0��$��Center=�$��14(�.��
Year Made:�� $��5��$��1��$��14(�$��5q����� *VehicleDetail.YearMade+$	 TwoWay=��� $��6��$��0��$��Center=�$��14(�.��Reg No Plate:�� $��6��$��1��$��14(�$��5q����� *VehicleDetail.RegNo+$	 TwoWay=��� $��0��$��3��$��Center=�$��14(�.��Parallel Import:�� $��0��$��4��$��14(�$��5q����� *VehicleDetail.ParallelImport+$	 TwoWay=��� $��1��$��3��$��Center=�$��14(�.��Off Peak Vehicle:�� $��1��$��4��$��14(�$��5q����� *VehicleDetail.OffPeakVehicle+$	 TwoWay=��� $��2��$��3��$��Center=�$��14(�.��
NCD (%):�� $��2��$��4��$��14(�$��5q����� *VehicleDetail.NCD+$	 TwoWay=��� $��3��$��3��$��Center=�$��14(�.��Existing Insurer:�� $��3��$��4��$��14(�$��5q����� *VehicleDetail.ExistingInsurer+$	 TwoWay=��� $��4��$��3��$��Center=�$��14(�.��Previous Reg No:�� $��4��$��4��$��14(�$��5q����� *VehicleDetail.PreviousRegNo+$	 TwoWay=��� $��5��$��3��$��Center=�$��14(�.��Claims (Past 3 years):�� $��5��$��4��$��3��$��14(�$��5q����� *VehicleDetail.Claims+$	 TwoWay=��� #���  $��1��$��Stretch=� . 9� $��Stretch=�$ ��Existing Insurance Details��#���   �� *QuotationViewModel+y��� *InsuranceDetails.Count+# [ .���� $ Vertical=�#���  $��	24,0,20,8q�.+�  #��[	  .   . ���� *InsuranceDetails+ 	  $ Insurance Expiry Date��$	 180  �� *InsuranceExpiryDate+	  $ Road Tax Expiry Date��$	 180  �� *RoadTaxExpiryDate+	  $ Previous Dealer��$	 120  �� *PreviousDealer+	  $ Agency��$	 120  �� *Agency+	  $ Finance Bank��$	 120  �� *FinanceBank+	  $ Previous Year Premium��$	 250  �� *PrevYearPremium+