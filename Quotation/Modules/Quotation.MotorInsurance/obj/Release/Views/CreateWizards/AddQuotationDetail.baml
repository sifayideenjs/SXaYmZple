   M S B A M L   `   `   `  ���� Y  UQuotation.MotorInsuranceModule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullw@clr-namespace:Quotation.MotorInsuranceModule.Views.CreateWizards2Quotation.MotorInsuranceModule.Views.CreateWizards  S OQuotation.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullyRclr-namespace:Quotation.Infrastructure.Constants;assembly=Quotation.Infrastructure"Quotation.Infrastructure.Constants yRclr-namespace:Quotation.Infrastructure.Behaviors;assembly=Quotation.Infrastructure"Quotation.Infrastructure.Behaviors {Sclr-namespace:Quotation.Infrastructure.Converters;assembly=Quotation.Infrastructure#Quotation.Infrastructure.Converters L HQuotation.Styling, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullbCclr-namespace:Quotation.Styling.Controls;assembly=Quotation.StylingQuotation.Styling.Controls K    EQuotation.MotorInsuranceModule.Views.CreateWizards.AddQuotationDetail   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Rlocal@clr-namespace:Quotation.MotorInsuranceModule.Views.CreateWizards     T PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f8metro,http://metro.mahapps.com/winfx/xaml/controls  U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullX	 TMaterialDesignThemes.MahApps, Version=0.0.11.0, Culture=neutral, PublicKeyToken=nullBmaterial1http://materialdesigninxaml.net/winfx/xaml/themes  	 P
 LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8'prismlibhttp://prismlibrary.com/ 
 )prismhttp://www.codeplex.com/prism 
 einfConstantsRclr-namespace:Quotation.Infrastructure.Constants;assembly=Quotation.Infrastructure 
 einfBehaviorsRclr-namespace:Quotation.Infrastructure.Behaviors;assembly=Quotation.Infrastructure 
 ginfConvertersSclr-namespace:Quotation.Infrastructure.Converters;assembly=Quotation.Infrastructure 
 QcontrolCclr-namespace:Quotation.Styling.Controls;assembly=Quotation.Styling 
   � DataContext  ��  � 	Resources F  @Quotation.Infrastructure.Converters.BooleanToVisibilityConverter    BooleanToVisibilityConverterA  ;Quotation.Infrastructure.Converters.YesNoToBooleanConverter  YesNoToBooleanConverter>  8Quotation.Infrastructure.Converters.YesNoToByteConverter  YesNoToByteConverter��%-   &	        &	      &	 
           .��� -    �Name$
 root�� � RowDefinitions �� $��* ��� $
��auto �.+��� $
��Auto=�  �� *QuotationViewModel+.���  �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��  �� $
��Auto ��� $��* � � ColumnDefinitions �� $��* ��� $
��auto �.+��� $��0��$��2��$��20(�  HeaderFontFamily#���  .��Named Driver Details&   System.Windows.Controls.DataGrid  $��1��$	��100��   AutoGenerateColumns .  -  'MaterialDesignThemes.Wpf.DataGridAssist   EnableEditBoxAssist .  
����������� *DriverDetails+ �� SelectedItem �� *SelectedDriverDetail+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn	   Header$	 Insured Name��
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 150 1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding �� *InsuredName+  $	 Insured NRIC��$	
 100  �� *InsuredNRIC+  $	 
Biz Reg No��$	
 100  �� *
BizRegNo+4
  .System.Windows.Controls.DataGridTemplateColumn
  $	 Date of Birth��$	
 150  
  CellTemplate �� .R�(  "System.Windows.Controls.DatePicker  $��Center=�   SelectedDate �� *DateOfBirth+ �� Mode$ TwoWay=�
  $	 Gender��$
 80  �� .R��� ���� *GenderTypes+ �� *Gender+$ TwoWay=�
  $	 Marital Status��$	
 120  �� .R��� ���� *MaritalStatusTypes+ �� *MaritalStatus+$ TwoWay=� �� 	Converter# [   $	 
Occupation��$	
 150  �� *
Occupation+  $	 Industry��$	
 150  �� *
Industry+
  $	 License Date��$	
 150  �� .R�  $��Center=� �� *LicenseDate+$ TwoWay=��� $��10��$��3�� �� Orientation$ Vertical=�$��Center=�$��	0 0 10 10q�.+��� $��1��$��40��$��40��  MetroCircleButtonStyle#��[ ���� *DataContext.AddDriverCommand+ �� ElementName$
 root��.���� $��15��$��15��
���   � J� OpacityMask !�  j� Stretch$
 Fill=�  
appbar_add !� Visual# �  �� $��1��$��40��$��40��#��[ ���� *!DataContext.DeleteDriverCommand+$
 root��.���� $��15��$��15��
���   � !� $
 Fill=�  appbar_delete# �  � $��1��$��0 10 0 0q� �� $
��auto ��� $��* �.+��� $��0q�$��0��$��20(�#���  .��Vehicle Details� $��1�� �� $	��180 ��� $	��300��$	��350 ��� $	��100��$	��120 ��� $	��180 ��� $	��300��$	��350 � �� $
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
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��0��$��Center=�$��14(�.��Make:�� $��0��$��1��*  $MahApps.Metro.Controls.TextBoxHelper   ClearTextButton . $��Center=�$��5q����� *VehicleDetail.Make+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnExceptions .  �� NotifyOnValidationError .  �� ValidatesOnDataErrors . �� $��1��$��0��$��Center=�$��14(�.��Model:�� $��1��$��1�� . $��Center=�$��5q����� *VehicleDetail.VehicleModel+$ TwoWay=�$ PropertyChanged=� .  .  . �� $��2��$��0��$��Center=�$��14(�.��	Capacity:�� $��2��$��1�� . $��Center=�$��5q����� *VehicleDetail.Capacity+$ TwoWay=�$ PropertyChanged=� .  .  . �� $��3��$��0��$��Center=�$��14(�.��
Tonnage:�� $��3��$��1�� . $��Center=�$��5q����� *VehicleDetail.Tonnage+$ TwoWay=�$ PropertyChanged=� .  .  . �� $��4��$��0��$��Center=�$��14(�.��Date of Reg:  $��4��$��1��$��Center=�$��5q� �� * VehicleDetail.DateOfRegistered+$ TwoWay=� . $ PropertyChanged=� .  . �� $��5��$��0��$��Center=�$��14(�.��
Year Made:�� $��5��$��1�� . $��Center=�$��5q����� *VehicleDetail.YearMade+$ TwoWay=�$ PropertyChanged=� .  .  . �� $��6��$��0��$��Center=�$��14(�.��Reg No Plate:�� $��6��$��1�� . $��Center=�$��5q����� *VehicleDetail.RegNo+$ TwoWay=�$ PropertyChanged=� .  .  . �� $��7��$��0��$��Center=�$��14(�.��Parallel Import:�� $��7��$��1�� �� SelectedIndex$ 0��$��5q����� *VehicleDetail.YesNos+ �� *VehicleDetail.ParallelImport+$ TwoWay=�# [ �� $��0��$��3��$��Center=�$��14(�.��Off Peak Vehicle:�� $��0��$��4��$ 0��$��5q����� *VehicleDetail.YesNos+ �� *VehicleDetail.OffPeakVehicle+$ TwoWay=�# [ �� $��1��$��3��$��Center=�$��14(�.��
NCD (%):�� $��1��$��4�� . $��Center=�$��5q����� *VehicleDetail.NCD+$ TwoWay=�$ PropertyChanged=� .  .  . �� $��2��$��3��$��Center=�$��14(�.��Existing Insurer:�� $��2��$��4�� . $��Center=�$��5q����� *VehicleDetail.ExistingInsurer+$ TwoWay=�$ PropertyChanged=� .  .  . �� $��3��$��3��$��Center=�$��14(�.��Previous Reg No:�� $��3��$��4�� . $��Center=�$��5q����� *VehicleDetail.PreviousRegNo+$ TwoWay=�$ PropertyChanged=� .  .  . �� $��4��$��3��$��Center=�$��14(�.��Claims (Past 3 years):�� $��4��$��4��$��4�� . $	��Top=� �� TextWrapping$
 Wrap=� �� AcceptsReturn . $��5q����� *VehicleDetail.Claims+$ TwoWay=�$ PropertyChanged=� .  .  . � $��2��$��0 10 0 0q� �� $
��Auto ��� $��* �.+��� $��0q�$��0��$��20(�#���  .��Insurance Details� $��1�� �� $	��180 ��� $	��300��$	��350 ��� $	��100��$	��120 ��� $	��180 ��� $	��300��$	��350 � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��0��$��Center=�$��14(�.��Insurance Expiry Date:  $��0��$��1��$��Center=�$��5q� �� *,*CurrentInsuranceDetail.InsuranceExpiryDate+$ TwoWay=�$ PropertyChanged=� .  .  . �� $��1��$��0��$��Center=�$��14(�.��Road Tax Expiry Date:  $��1��$��1��$��Center=�$��5q� �� **(CurrentInsuranceDetail.RoadTaxExpiryDate+$ TwoWay=�$ PropertyChanged=� .  .  . �� $��2��$��0��$��Center=�$��14(�.��Previous Dealer:�� $��2��$��1�� . $��Center=�$��5q����� *'%CurrentInsuranceDetail.PreviousDealer+$ TwoWay=�$ PropertyChanged=� .  .  . �� $��3��$��0��$��Center=�$��14(�.��	Agency:�� $��3��$��1�� . $��Center=�$��5q����� *CurrentInsuranceDetail.Agency+$ TwoWay=�$ PropertyChanged=� .  .  . �� $��0��$��3��$��Center=�$��14(�.��Finance Bank:�� $��0��$��4�� . $��Center=�$��5q����� *$"CurrentInsuranceDetail.FinanceBank+$ TwoWay=�$ PropertyChanged=� .  .  . �� $��1��$��3��$��Center=�$��14(�.��Previous Year Premium:�� $��1��$��4��$��3�� . $	��Top=�$
 Wrap=� . $��5q����� *(&CurrentInsuranceDetail.PrevYearPremium+$ TwoWay=�$ PropertyChanged=� .  .  . �� $��1��$ 
Horizontal=�$��Center=�$��5q�.+��� $��1��$��50��$��50�� * &MaterialDesignFloatingActionDarkButton#��[ $	��5 0q����� *PreviousCommand+.���� $��25��$��25��
������� !� $
 Fill=�  appbar_arrow_left# �  �� $��1��$��50��$��50��#��[ $	��5 0q����� *AddQuotationCommand+.���� $��25��$��25��
������� !� $
 Fill=� 	 appbar_save# � 	 