   M S B A M L   `   `   `  ����Y  UQuotation.MotorInsuranceModule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:Quotation.MotorInsuranceModule.Views.Wizards,Quotation.MotorInsuranceModule.Views.Wizards  5      S OQuotation.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullyRclr-namespace:Quotation.Infrastructure.Constants;assembly=Quotation.Infrastructure"Quotation.Infrastructure.Constants 5      yRclr-namespace:Quotation.Infrastructure.Behaviors;assembly=Quotation.Infrastructure"Quotation.Infrastructure.Behaviors 5      {Sclr-namespace:Quotation.Infrastructure.Converters;assembly=Quotation.Infrastructure#Quotation.Infrastructure.Converters 5      L HQuotation.Styling, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullbCclr-namespace:Quotation.Styling.Controls;assembly=Quotation.StylingQuotation.Styling.Controls 5      C    =Quotation.MotorInsuranceModule.Views.Wizards.QuotationSummary   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Llocal:clr-namespace:Quotation.MotorInsuranceModule.Views.Wizards     5      T PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f8metro,http://metro.mahapps.com/winfx/xaml/controls  5      U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullX	 TMaterialDesignThemes.MahApps, Version=0.0.11.0, Culture=neutral, PublicKeyToken=nullBmaterial1http://materialdesigninxaml.net/winfx/xaml/themes  	 5      P
 LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8'prismlibhttp://prismlibrary.com/ 
 5	      )prismhttp://www.codeplex.com/prism 
 5
      einfConstantsRclr-namespace:Quotation.Infrastructure.Constants;assembly=Quotation.Infrastructure 
 5      einfBehaviorsRclr-namespace:Quotation.Infrastructure.Behaviors;assembly=Quotation.Infrastructure 
 5      ginfConvertersSclr-namespace:Quotation.Infrastructure.Converters;assembly=Quotation.Infrastructure 
 5      QcontrolCclr-namespace:Quotation.Styling.Controls;assembly=Quotation.Styling 
 5        � DataContext  5   7   ��  � 	Resources 5      A  ;Quotation.Infrastructure.Converters.YesNoToBooleanConverter   YesNoToBooleanConverterE  ?Quotation.Infrastructure.Converters.ZeroCollapsedNonZeroVisible  ZeroCollapsedNonZeroVisible��%:   &	        &	        5   
   60     5   
   64   5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   $
��Auto=�6$   .��5      �  5      �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5       $
��auto �6$   �� 5!      $
��auto �6$   .+�5$      �� $��0��6   $��Owner / Insured Details��6(   .��57      � $��1��6     6(   �� *QuotationViewModel+ � ColumnDefinitions 58      �� 59      $	��180 �6/   �� 5:      $	��300��6/   $	��350 �6>   �� 5;      $	��100��6/   $	��120 �6>   �� 5<      $	��180 �6/   �� 5=      $	��300��6/   $	��350 �6>    5?      �� 5@      $
��Auto �6,   6<   �� 5A      $
��Auto �6,   6<   �� 5B      $
��Auto �6,   6<   �� 5C      $
��Auto �6,   6<   �� 5D      $
��Auto �6,   6<   �� 5E      $
��Auto �6,   6<   �� 5F      $
��Auto �6,   6<   �� 5G      $
��Auto �6,   6<   �� 5H      $
��Auto �6,   6<   �� 5I      $
��Auto �6,   6<   .+�5L      �� $��0��6    $��0��6-   $��Center=�6=   $��14(�6X   .��6f   Insured Name:6u   �� 5M      $��0��6$   $��1��61   $��14(�6p   $��5q�6~   ��6A   �� *OwnerDetail.Name+ �� Mode$ TwoWay=�6~   �� 5O      $��1��6    $��0��6-   $��Center=�6=   $��14(�6X   .��6f   
Contact:6p   �� 5P      $��1��6$   $��1��61   $��14(�6s   $��5q�6�   ��6A   �� *OwnerDetail.Contact+$ TwoWay=�6�   �� 5R      $��2��6    $��0��6-   $��Center=�6=   $��14(�6X   .��6f   NRIC:6m   �� 5S      $��2��6$   $��1��61   $��14(�6A   $��5q�6~   ��6O   �� *OwnerDetail.NRIC+$ TwoWay=�6~   �� 5U      $��3��6    $��0��6-   $��Center=�6=   $��14(�6X   .��6f   Biz Reg No:6s   �� 5V      $��3��6$   $��1��61   $��14(�6A   $��5q�6�   ��6O   �� *OwnerDetail.BizRegNo+$ TwoWay=�6�   �� 5X      $��4��6    $��0��6-   $��Center=�6=   $��14(�6X   .��6f   Date of Birth:6v   �� 5Y      $��4��6$   $��1��61   $��14(�6A   $��5q�6�   ��6O   �� *OwnerDetail.DateOfBirth+$ TwoWay=�6�   �� 5[      $��5��6    $��0��6-   $��Center=�6=   $��14(�6X   .��6f   	Gender:6o   �� 5\      $��5��6$   $��1��61   $��14(�6A   $��5q�6�   ��6P   �� *OwnerDetail.Gender+$ TwoWay=�6�   �� 5^      $��6��6    $��0��6-   $��Center=�6=   $��14(�6X   .��6f   Marital Status:6w   �� 5_      $��6��6$   $��1��61   $��14(�6A   $��5q�6�   ��6P   �� *OwnerDetail.MaritalStatus+$ TwoWay=�6�   �� 5a      $��0��6    $��3��6-   $��Center=�6=   $��14(�6X   .��6f   Occupation:6s   �� 5b      $��0��6$   $��4��61   $��14(�6A   $��5q�6�   ��6P   �� *OwnerDetail.Occupation+$ TwoWay=�6�   �� 5d      $��1��6    $��3��6-   $��Center=�6=   $��14(�6X   .��6f   	Industry:6q   �� 5e      $��1��6$   $��4��61   $��14(�6A   $��5q�6�   ��6P   �� *OwnerDetail.Industry+$ TwoWay=�6�   �� 5g      $��2��6    $��3��6-   $��Center=�6=   $��14(�6X   .��6f   License Date:6u   �� 5h      $��2��6$   $��4��61   $��14(�6A   $��5q�6�   ��6P   �� *OwnerDetail.LicenseDate+$ TwoWay=�6�   �� 5j      $��3��6    $��3��6-   $��Center=�6=   $��14(�6X   .��6f   Email:6n   �� 5k      $��3��6$   $��4��61   $��14(�6A   $��5q�6�   ��6P   �� *OwnerDetail.Email+$ TwoWay=�6�   �� 5m      $��4��6    $��3��6-   $��Center=�6=   $��14(�6X   .��6f   
Address:6p   �� 5n      $��4��6$   $��4��61   $��2��6A   $��14(�6R   $��5q�6�   ��6a   �� *OwnerDetail.Address+$ TwoWay=�6�   5o      5p      �� 5r      $��1��6   $��Driver Details��6(   y�6@   �� *(&QuotationViewModel.DriverDetails.Count+ �� 	Converter# [ .��5�      &   System.Windows.Controls.DataGrid    AzureDataGrid#��[ 6X      AutoGenerateColumns .     
IsReadOnly . ��6   �� *" QuotationViewModel.DriverDetails+   Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Insured Name��61   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 200 6g   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6G   �� *InsuredName+6g     5�      $	 Insured NRIC��61   $	
 130 6g    6G   �� *InsuredNRIC+6g     5�      $	 
Biz Reg No��61   $	
 120 6b    6E   �� *
BizRegNo+6b     5�      $	 Date of Birth��61   $	
 160 6h    6H   �� *DateOfBirth+6h     5�      $	 Gender��61   $
 80 6\    6A   �� *Gender+6\     5�      $	 Marital Status��61   $	
 120 6�    6I   �� *MaritalStatus+# [  6�     5�      $	 
Occupation��61   $	
 200 6d    6E   �� *
Occupation+6d     5�      $	 Industry��61   $	
 200 6`    6C   �� *
Industry+6`     5�      $	 License Date��61   $	
 160 6g    6G   �� *LicenseDate+6g   5�      5�      �� 5�      $��2��6   $��Vehicle Details��6(   .��5�      � $��1��6     6(   �� *QuotationViewModel+ 5�      �� 5�      $	��180 �6/   �� 5�      $	��300��6/   $	��350 �6>   �� 5�      $	��100��6/   $	��120 �6>   �� 5�      $	��180 �6/   �� 5�      $	��300��6/   $	��350 �6>    5�      �� 5�      $
��Auto �6,   6<   �� 5�      $
��Auto �6,   6<   �� 5�      $
��Auto �6,   6<   �� 5�      $
��Auto �6,   6<   �� 5�      $
��Auto �6,   6<   �� 5�      $
��Auto �6,   6<   �� 5�      $
��Auto �6,   6<   �� 5�      $
��Auto �6,   6<   �� 5�      $
��Auto �6,   6<   �� 5�      $
��Auto �6,   6<   �� 5�      $
��Auto �6,   6<   �� 5�      $
��Auto �6,   6<   .+�5�      �� $��0��6    $��0��6-   $��Center=�6=   $��14(�6X   .��6f   Make:6m   �� 5�      $��0��6$   $��1��61   $��14(�6A   $��5q�6�   ��6O   �� *VehicleDetail.Make+$ TwoWay=�6�   �� 5�      $��1��6    $��0��6-   $��Center=�6=   $��14(�6X   .��6f   Model:6n   �� 5�      $��1��6$   $��1��61   $��14(�6A   $��5q�6�   ��6O   �� *VehicleDetail.VehicleModel+$ TwoWay=�6�   �� 5�      $��2��6    $��0��6-   $��Center=�6=   $��14(�6X   .��6f   	Capacity:6q   �� 5�      $��2��6$   $��1��61   $��14(�6A   $��5q�6�   ��6O   �� *VehicleDetail.Capacity+$ TwoWay=�6�   �� 5�      $��3��6    $��0��6-   $��Center=�6=   $��14(�6X   .��6f   
Tonnage:6p   �� 5�      $��3��6$   $��1��61   $��14(�6A   $��5q�6�   ��6O   �� *VehicleDetail.Tonnage+$ TwoWay=�6�   �� 5�      $��4��6    $��0��6-   $��Center=�6=   $��14(�6X   .��6f   Date of Reg:6t   �� 5�      $��4��6$   $��1��61   $��14(�6A   $��5q�6�   ��6O   �� * VehicleDetail.DateOfRegistered+$ TwoWay=�6�   �� 5�      $��5��6    $��0��6-   $��Center=�6=   $��14(�6X   .��6f   
Year Made:6r   �� 5�      $��5��6$   $��1��61   $��14(�6A   $��5q�6�   ��6O   �� *VehicleDetail.YearMade+$ TwoWay=�6�   �� 5�      $��6��6    $��0��6-   $��Center=�6=   $��14(�6X   .��6f   Reg No Plate:6u   �� 5�      $��6��6$   $��1��61   $��14(�6A   $��5q�6�   ��6O   �� *VehicleDetail.RegNo+$ TwoWay=�6�   �� 5�      $��0��6    $��3��6-   $��Center=�6=   $��14(�6X   .��6f   Parallel Import:6x   �� 5�      $��0��6$   $��4��61   $��14(�6A   $��5q�6�   ��6O   �� *VehicleDetail.ParallelImport+$ TwoWay=�6�   �� 5�      $��1��6    $��3��6-   $��Center=�6=   $��14(�6X   .��6f   Off Peak Vehicle:6y   �� 5�      $��1��6$   $��4��61   $��14(�6A   $��5q�6�   ��6O   �� *VehicleDetail.OffPeakVehicle+$ TwoWay=�6�   �� 5�      $��2��6    $��3��6-   $��Center=�6=   $��14(�6X   .��6f   
NCD (%):6p   �� 5�      $��2��6$   $��4��61   $��14(�6A   $��5q�6   ��6O   �� *VehicleDetail.NCD+$ TwoWay=�6   �� 5�      $��3��6    $��3��6-   $��Center=�6=   $��14(�6X   .��6f   Existing Insurer:6y   �� 5�      $��3��6$   $��4��61   $��14(�6A   $��5q�6�   ��6O   �� *VehicleDetail.ExistingInsurer+$ TwoWay=�6�   �� 5�      $��4��6    $��3��6-   $��Center=�6=   $��14(�6X   .��6f   Previous Reg No:6x   �� 5�      $��4��6$   $��4��61   $��14(�6A   $��5q�6�   ��6O   �� *VehicleDetail.PreviousRegNo+$ TwoWay=�6�   �� 5�      $��5��6    $��3��6-   $��Center=�6=   $��14(�6X   .��6f   Claims (Past 3 years):6~   �� 5�      $��5��6$   $��4��61   $��3��6A   $��14(�6R   $��5q�6�   ��6`   �� *VehicleDetail.Claims+$ TwoWay=�6�   5�      5�      �� 5�      $��3��6   $��Insurance Details��6(   .��5     � $��1��6     6(   �� *QuotationViewModel+ 5     �� 5     $	��180 �6/   �� 5     $	��300��6/   $	��350 �6>   �� 5     $	��100��6/   $	��120 �6>   �� 5	     $	��180 �6/   �� 5
     $	��300��6/   $	��350 �6>    5     �� 5     $
��Auto �6,   6<   �� 5     $
��Auto �6,   6<   �� 5     $
��Auto �6,   6<   �� 5     $
��Auto �6,   6<   �� 5     $
��Auto �6,   6<   �� 5     $
��Auto �6,   6<   �� 5     $
��Auto �6,   6<   �� 5     $
��Auto �6,   6<   .+�5     �� $��0��6    $��0��6-   $��Center=�6=   $��14(�6X   .��6f   Insurance Expiry Date:6~   �� 5     $��0��6$   $��1��61   $��14(�6A   $��5q�6�   ��6O   �� *,*CurrentInsuranceDetail.InsuranceExpiryDate+$ TwoWay=�6�   �� 5     $��1��6    $��0��6-   $��Center=�6=   $��14(�6X   .��6f   Road Tax Expiry Date:6}   �� 5     $��1��6$   $��1��61   $��14(�6A   $��5q�6�   ��6O   �� **(CurrentInsuranceDetail.RoadTaxExpiryDate+$ TwoWay=�6�   �� 5     $��2��6    $��0��6-   $��Center=�6=   $��14(�6X   .��6f   Previous Dealer:6x   �� 5     $��2��6$   $��1��61   $��14(�6A   $��5q�6�   ��6O   �� *'%CurrentInsuranceDetail.PreviousDealer+$ TwoWay=�6�   �� 5      $��0��6    $��3��6-   $��Center=�6=   $��14(�6X   .��6f   	Agency:6o   �� 5!     $��0��6$   $��4��61   $��14(�6A   $��5q�6�   ��6O   �� *CurrentInsuranceDetail.Agency+$ TwoWay=�6�   �� 5#     $��1��6    $��3��6-   $��Center=�6=   $��14(�6X   .��6f   Finance Bank:6u   �� 5$     $��1��6$   $��4��61   $��14(�6A   $��5q�6�   ��6O   �� *$"CurrentInsuranceDetail.FinanceBank+$ TwoWay=�6�   �� 5&     $��2��6    $��3��6-   $��Center=�6=   $��14(�6X   .��6f   Previous Year Premium:6~   �� 5'     $��2��6$   $��4��61   $��14(�6A   $��5q�6�   ��6O   �� *(&CurrentInsuranceDetail.PrevYearPremium+$ TwoWay=�6�   5(     5)     5*     5+     �� 5-  
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��5q�6X   .+�5C     �� $��1��6   $��50��6%   $��50��61    * &MaterialDesignFloatingActionDarkButton#��[ 6a   $	��5 0q�6�   ��6<   �� *DashboardCommand+.��5I     '  !MaterialDesignThemes.Wpf.PackIcon  �	  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]] 	  Kind$
 Home=�6$   $��30��61   $��30��6=   5J     �� 5K     $��1��6   $��50��6%   $��50��61   #��[ 6f   $	��5 0q�6�   ��6<   �� *PrintQuotationCommand+.��5L     �� $��25��6   $��25��6'   
������� J� OpacityMask 5M     !� 5N      j� Stretch$
 Fill=�6&     appbar_printer !� Visual# �  65   5P     5R     5S     5T     5U     