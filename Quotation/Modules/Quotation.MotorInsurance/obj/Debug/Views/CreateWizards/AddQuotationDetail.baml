   M S B A M L   `   `   `  ����Y  UQuotation.MotorInsuranceModule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullw@clr-namespace:Quotation.MotorInsuranceModule.Views.CreateWizards2Quotation.MotorInsuranceModule.Views.CreateWizards  5      S OQuotation.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullyRclr-namespace:Quotation.Infrastructure.Constants;assembly=Quotation.Infrastructure"Quotation.Infrastructure.Constants 5      yRclr-namespace:Quotation.Infrastructure.Behaviors;assembly=Quotation.Infrastructure"Quotation.Infrastructure.Behaviors 5      {Sclr-namespace:Quotation.Infrastructure.Converters;assembly=Quotation.Infrastructure#Quotation.Infrastructure.Converters 5      L HQuotation.Styling, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullbCclr-namespace:Quotation.Styling.Controls;assembly=Quotation.StylingQuotation.Styling.Controls 5      K    EQuotation.MotorInsuranceModule.Views.CreateWizards.AddQuotationDetail   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Rlocal@clr-namespace:Quotation.MotorInsuranceModule.Views.CreateWizards     5      T PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f8metro,http://metro.mahapps.com/winfx/xaml/controls  5      U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullX	 TMaterialDesignThemes.MahApps, Version=0.0.11.0, Culture=neutral, PublicKeyToken=nullBmaterial1http://materialdesigninxaml.net/winfx/xaml/themes  	 5      P
 LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8'prismlibhttp://prismlibrary.com/ 
 5	      )prismhttp://www.codeplex.com/prism 
 5
      einfConstantsRclr-namespace:Quotation.Infrastructure.Constants;assembly=Quotation.Infrastructure 
 5      einfBehaviorsRclr-namespace:Quotation.Infrastructure.Behaviors;assembly=Quotation.Infrastructure 
 5      ginfConvertersSclr-namespace:Quotation.Infrastructure.Converters;assembly=Quotation.Infrastructure 
 5      QcontrolCclr-namespace:Quotation.Styling.Controls;assembly=Quotation.Styling 
 5        � DataContext  5   8   ��  � 	Resources 5      F  @Quotation.Infrastructure.Converters.BooleanToVisibilityConverter    BooleanToVisibilityConverterA  ;Quotation.Infrastructure.Converters.YesNoToBooleanConverter  YesNoToBooleanConverter>  8Quotation.Infrastructure.Converters.YesNoToByteConverter  YesNoToByteConverter��%W   &	        &	      &	 &       5   
   65     5   
   60     5   
   6-   5      .��5      � -   5         �Name$
 root��5       � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� $
��Auto=�6     6<   �� *QuotationViewModel+.��5      �  5      �� 5      $
��Auto �6$   �� 5       $
��Auto �6$   �� 5!      $
��Auto �6$   .+�5$      �  5%      �� 5&      $
��Auto �6(   �� 5'      $��* �6(    � ColumnDefinitions 5*      �� 5+      $��* �6+   �� 5,      $
��auto �6+   .+�5/      �� $��0��6   $��2��6)   $��20(�6=     HeaderFontFamily#���  6K   .��6{   Named Driver Details6�   &   System.Windows.Controls.DataGrid  51      $��1��6   $	��100��6,      AutoGenerateColumns .  -  'MaterialDesignThemes.Wpf.DataGridAssist   EnableEditBoxAssist .  
���������6<   �� *DriverDetails+ �� SelectedItem 6b   �� *SelectedDriverDetail+   Columns 52      0  *System.Windows.Controls.DataGridTextColumn  53      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Insured Name��61   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 150 6g   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6G   �� *InsuredName+6g     54      $	 Insured NRIC��61   $	
 100 6g    6G   �� *InsuredNRIC+6g     55      $	 
Biz Reg No��61   $	
 100 6b    6E   �� *
BizRegNo+6b   4
  .System.Windows.Controls.DataGridTemplateColumn
  56      $	 Date of Birth��65   $	
 150 6L    
  CellTemplate 57   "   �� 58   &   .R�59   *   (  "System.Windows.Controls.DatePicker  $��Center=�65      SelectedDate 6W   �� *DateOfBirth+ �� Mode$ TwoWay=�5:   '   5<      
  5=      $	 Gender��65   $
 80 6E    5>   "   �� 5?   &   .R�5@   *   �� ��63   �� *GenderTypes+ 6W   �� *Gender+$ TwoWay=�5A   '   5C      
  5D      $	 Marital Status��65   $	
 120 6M    5E   "   �� 5F   &   .R�5G   *   �� ��63   �� *MaritalStatusTypes+ 6^   �� *MaritalStatus+$ TwoWay=� �� 	Converter# [ 5H   '   5J        5K      $	 
Occupation��61   $	
 150 6d    6E   �� *
Occupation+6d     5L      $	 Industry��61   $	
 150 6`    6C   �� *
Industry+6`   
  5M      $	 License Date��65   $	
 150 6K    5N   "   �� 5O   &   .R�5P   *     $��Center=�65    6W   �� *LicenseDate+$ TwoWay=�5Q   '   5S      5U      �� 5W      $��10��6!   $��3��6/    �� Orientation$ Vertical=�6?   $��Center=�6V   $��	0 0 10 10q�6s   .+�5X      �� $��1��6!   $��40��61   $��40��6=     MetroCircleButtonStyle#��[ 6�   ��6H   �� *DataContext.AddDriverCommand+ �� ElementName$
 root��.��5Y      �� $��15��6(   $��15��63   
���   � J� OpacityMask 5Z   "   !� 5[   &    j� Stretch$
 Fill=�62     
appbar_add !� Visual# �  6A   5]      5^      �� 5_      $��1��6!   $��40��61   $��40��6=   #��[ 6�   ��6H   �� *!DataContext.DeleteDriverCommand+$
 root��.��5`      �� $��15��6(   $��15��63   
���   � 5a   "   !� 5b   &   $
 Fill=�62     appbar_delete# �  6A   5d      5e      5f      5g      � 5i      $��1��6   $��0 10 0 0q�6$    5j      �� 5k      $
��auto �6(   �� 5l      $��* �6(   .+�5n      �� $��0q�6   $��0��6'   $��20(�5o      #���  5p      .��5r      Vehicle Details6*   � 5t      $��1��6    5u      �� 5v      $	��180 �6/   �� 5w      $	��300��6/   $	��350 �6>   �� 5x      $	��100��6/   $	��120 �6>   �� 5y      $	��180 �6/   �� 5z      $	��300��6/   $	��350 �6>    5|      �� 5}      $
��Auto �6,   6<   �� 5~      $
��Auto �6,   6<   �� 5      $
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
��Auto �6,   6<   .+�5�      �� $��0��6    $��0��6-   $��Center=�6=   $��14(�6X   .��6f   Make:6m   �� 5�      $��0��6"   $��1��6/   *  $MahApps.Metro.Controls.TextBoxHelper   ClearTextButton . $��Center=�6j   $��5q�5�      ��5�   �   �� *VehicleDetail.Make+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnExceptions .  �� NotifyOnValidationError .  �� ValidatesOnDataErrors . 5�      �� 5�      $��1��6    $��0��6-   $��Center=�6=   $��14(�6X   .��6f   Model:6n   �� 5�      $��1��6"   $��1��6/    . $��Center=�6j   $��5q�5�      ��5�   �   �� *VehicleDetail.VehicleModel+$ TwoWay=�$ PropertyChanged=� .  .  . 5�      �� 5�      $��2��6    $��0��6-   $��Center=�6=   $��14(�6X   .��6f   	Capacity:6q   �� 5�      $��2��6"   $��1��6/    . $��Center=�6j   $��5q�5�      ��5�   �   �� *VehicleDetail.Capacity+$ TwoWay=�$ PropertyChanged=� .  .  . 5�      �� 5�      $��3��6    $��0��6-   $��Center=�6=   $��14(�6X   .��6f   
Tonnage:6p   �� 5�      $��3��6"   $��1��6/    . $��Center=�6j   $��5q�5�      ��5�   �   �� *VehicleDetail.Tonnage+$ TwoWay=�$ PropertyChanged=� .  .  . 5�      �� 5�      $��4��6    $��0��6-   $��Center=�6=   $��14(�6X   .��6f   Date of Reg:6t     5�      $��4��6%   $��1��62   $��Center=�6B   $��5q�5�       5�   d   �� * VehicleDetail.DateOfRegistered+$ TwoWay=� . $ PropertyChanged=� .  . 5�      �� 5�      $��5��6    $��0��6-   $��Center=�6=   $��14(�6X   .��6f   
Year Made:6r   �� 5�      $��5��6"   $��1��6/    . $��Center=�6j   $��5q�5�      ��5�   �   �� *VehicleDetail.YearMade+$ TwoWay=�$ PropertyChanged=� .  .  . 5�      �� 5�      $��6��6    $��0��6-   $��Center=�6=   $��14(�6X   .��6f   Reg No Plate:6u   �� 5�      $��6��6"   $��1��6/    . $��Center=�6j   $��5q�5�      ��5�   �   �� *VehicleDetail.RegNo+$ TwoWay=�$ PropertyChanged=� .  .  . 5�      �� 5�      $��7��6    $��0��6-   $��Center=�6=   $��14(�6X   .��6f   Parallel Import:6x   �� 5�      $��7��6#   $��1��60    �� SelectedIndex$ 0��6�   $��5q�6�   ��6@   �� *VehicleDetail.YesNos+ 6m   �� *VehicleDetail.ParallelImport+$ TwoWay=�# [ 6�   �� 5�      $��0��6    $��3��6-   $��Center=�6=   $��14(�6X   .��6f   Off Peak Vehicle:6y   �� 5�      $��0��6#   $��4��60   $ 0��6�   $��5q�6�   ��6@   �� *VehicleDetail.YesNos+ 6m   �� *VehicleDetail.OffPeakVehicle+$ TwoWay=�# [ 6�   �� 5�      $��1��6    $��3��6-   $��Center=�6=   $��14(�6X   .��6f   
NCD (%):6p   �� 5�      $��1��6"   $��4��6/    . $��Center=�6j   $��5q�67  ��6�   �� *VehicleDetail.NCD+$ TwoWay=�$ PropertyChanged=� .  .  . 67  �� 5�      $��2��6    $��3��6-   $��Center=�6=   $��14(�6X   .��6f   Existing Insurer:6y   �� 5�      $��2��6"   $��4��6/    . $��Center=�6j   $��5q�6C  ��6�   �� *VehicleDetail.ExistingInsurer+$ TwoWay=�$ PropertyChanged=� .  .  . 6C  �� 5�      $��3��6    $��3��6-   $��Center=�6=   $��14(�6X   .��6f   Previous Reg No:6x   �� 5�      $��3��6"   $��4��6/    . $��Center=�6j   $��5q�6A  ��6�   �� *VehicleDetail.PreviousRegNo+$ TwoWay=�$ PropertyChanged=� .  .  . 6A  �� 5�      $��4��6    $��3��6-   $��Center=�6=   $��14(�6X   .��6f   Claims (Past 3 years):6~   �� 5�      $��4��6"   $��4��6/   $��4��6?    . $	��Top=�6{    �� TextWrapping$
 Wrap=�6�    �� AcceptsReturn . $��5q�6q  ��6�   �� *VehicleDetail.Claims+$ TwoWay=�$ PropertyChanged=� .  .  . 6q  5�      5�      � 5�      $��2��6   $��0 10 0 0q�6$    5�      �� 5�      $
��Auto �6(   �� 5�      $��* �6(   .+�5�      �� $��0q�6   $��0��6'   $��20(�64   #���  6B   .��6r   Insurance Details6�   � 5�      $��1��6    5�      �� 5�      $	��180 �6/   �� 5�      $	��300��6/   $	��350 �6>   �� 5�      $	��100��6/   $	��120 �6>   �� 5�      $	��180 �6/   �� 5�      $	��300��6/   $	��350 �6>    5�      �� 5�      $
��Auto �6,   6<   �� 5�      $
��Auto �6,   6<   �� 5�      $
��Auto �6,   6<   �� 5�      $
��Auto �6,   6<   �� 5�      $
��Auto �6,   6<   �� 5�      $
��Auto �6,   6<   �� 5�      $
��Auto �6,   6<   �� 5�      $
��Auto �6,   6<   �� 5�      $
��Auto �6,   6<   .+�5�      �� $��0��6    $��0��6-   $��Center=�6=   $��14(�6X   .��6f   Insurance Expiry Date:6~     5�      $��0��6%   $��1��62   $��Center=�6B   $��5q�60   6d   �� *,*CurrentInsuranceDetail.InsuranceExpiryDate+$ TwoWay=�$ PropertyChanged=� .  .  . 60  �� 5�      $��1��6    $��0��6-   $��Center=�6=   $��14(�6X   .��6f   Road Tax Expiry Date:6}     5�      $��1��6%   $��1��62   $��Center=�6B   $��5q�6.   6d   �� **(CurrentInsuranceDetail.RoadTaxExpiryDate+$ TwoWay=�$ PropertyChanged=� .  .  . 6.  �� 5�      $��2��6    $��0��6-   $��Center=�6=   $��14(�6X   .��6f   Previous Dealer:6x   �� 5�      $��2��6"   $��1��6/    . $��Center=�6j   $��5q�6K  ��6�   �� *'%CurrentInsuranceDetail.PreviousDealer+$ TwoWay=�$ PropertyChanged=� .  .  . 6K  �� 5�      $��3��6    $��0��6-   $��Center=�6=   $��14(�6X   .��6f   	Agency:6o   �� 5�      $��3��6"   $��1��6/    . $��Center=�6j   $��5q�6C  ��6�   �� *CurrentInsuranceDetail.Agency+$ TwoWay=�$ PropertyChanged=� .  .  . 6C  �� 5�      $��0��6    $��3��6-   $��Center=�6=   $��14(�6X   .��6f   Finance Bank:6u   �� 5�      $��0��6"   $��4��6/    . $��Center=�6j   $��5q�6H  ��6�   �� *$"CurrentInsuranceDetail.FinanceBank+$ TwoWay=�$ PropertyChanged=� .  .  . 6H  �� 5�      $��1��6    $��3��6-   $��Center=�6=   $��14(�6X   .��6f   Previous Year Premium:6~   �� 5�      $��1��6"   $��4��6/   $��3��6?    . $	��Top=�6{   $
 Wrap=�6�    . $��5q�6�  ��6�   �� *(&CurrentInsuranceDetail.PrevYearPremium+$ TwoWay=�$ PropertyChanged=� .  .  . 6�  5�      5�      5�      5�      �� 5�   
   $��1��6   $ 
Horizontal=�6"   $��Center=�6;   $��5q�6X   .+�5�      �� $��1��6   $��50��6%   $��50��61    * &MaterialDesignFloatingActionDarkButton#��[ 6`   $	��5 0q�6�   ��6<   �� *PreviousCommand+.��5�      �� $��25��6   $��25��6'   
������� 5�      !� 5�      $
 Fill=�6&     appbar_arrow_left# �  65   5�      5�      �� 5�      $��1��6   $��50��6%   $��50��61   #��[ 6d   $	��5 0q�6�   ��6<   �� *AddQuotationCommand+.��5�      �� $��25��6   $��25��6'   
������� 5�      !� 5�      $
 Fill=�6&    	 appbar_save# � 	 65   5�      5�      5�      5�      5�      