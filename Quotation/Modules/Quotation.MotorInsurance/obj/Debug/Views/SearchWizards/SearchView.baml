   M S B A M L   `   `   `  ����Y  UQuotation.MotorInsuranceModule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullw@clr-namespace:Quotation.MotorInsuranceModule.Views.SearchWizards2Quotation.MotorInsuranceModule.Views.SearchWizards  5      S OQuotation.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullyRclr-namespace:Quotation.Infrastructure.Constants;assembly=Quotation.Infrastructure"Quotation.Infrastructure.Constants 5
      yRclr-namespace:Quotation.Infrastructure.Behaviors;assembly=Quotation.Infrastructure"Quotation.Infrastructure.Behaviors 5      L HQuotation.Styling, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullbCclr-namespace:Quotation.Styling.Controls;assembly=Quotation.StylingQuotation.Styling.Controls 5      C    =Quotation.MotorInsuranceModule.Views.SearchWizards.SearchView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Rlocal@clr-namespace:Quotation.MotorInsuranceModule.Views.SearchWizards     5      T PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f8metro,http://metro.mahapps.com/winfx/xaml/controls  5      P LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8'prismlibhttp://prismlibrary.com/  5      )prismhttp://www.codeplex.com/prism  5	      einfConstantsRclr-namespace:Quotation.Infrastructure.Constants;assembly=Quotation.Infrastructure  5
      einfBehaviorsRclr-namespace:Quotation.Infrastructure.Behaviors;assembly=Quotation.Infrastructure  5      QcontrolCclr-namespace:Quotation.Styling.Controls;assembly=Quotation.Styling  5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  . ���	#FF252526.��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   $
��Auto=�6$   .��5      �  5      �� 5      $
��auto �6$   �� 5      $��* �6$   �� 5      $
��auto �6$   �� 5      $
��auto �6$   .+�5      �� $��0��6   $��Insured Details��6(   .��5       � $��1��6    � ColumnDefinitions 5!      �� 5"      $	��180 �6/   �� 5#      $��* �6/    5%      �� 5&      $
��Auto �6,   6<   �� 5'      $
��Auto �6,   6<   �� 5(      $
��Auto �6,   6<   �� 5)      $
��Auto �6,   6<   �� 5*      $
��Auto �6,   6<   �� 5+      $
��Auto �6,   6<   �� 5,      $
��Auto �6,   6<   �� 5-      $
��Auto �6,   6<   �� 5.      $
��Auto �6,   6<   �� 5/      $
��Auto �6,   6<   .+�52      �� $��0��6    $��0��6-   $��Center=�6=   
�������$��14(�6o   $��SemiBold"�6}   .��6�   Insured Name:6�   �� 53      $��0��6$   $��1��61   
�������$��14(�6{   $��5q�6�   ��6A   �� *Name+ �� Mode$ TwoWay=�6�   �� 55      $��1��6    $��0��6-   $��Center=�6=   
�������$��14(�6o   .��6}   NRIC / Biz Reg No:6�   �� 56      $��1��6$   $��1��61   
�������$��14(�6X   $��5q�6�   ��6f   �� *NRIC+$ TwoWay=�6�   �� 58      $��3��6    $��0��6-   $��Center=�6=   
�������$��14(�6o   .��6}   	Gender:6�   �� 59      $��3��6$   $��1��61   
�������$��14(�6X   $��5q�6�   ��6g   �� *Gender+$ TwoWay=�6�   �� 5;      $��5��6    $��0��6-   $��Center=�6=   
�������$��14(�6o   .��6}   Occupation / Industry:6�   �� 5<      $��5��6$   $��1��61   
�������$��14(�6X   $��5q�6�   ��6g   �� *
Occupation+$ TwoWay=�6�   �� 5>      $��6��6    $��0��6-   $��Center=�6=   
�������$��14(�6o   .��6}   License Date:6�   �� 5?      $��6��6$   $��1��61   
�������$��14(�6X   $��5q�6�   ��6g   �� *LicenseDate+$ TwoWay=�6�   5@      5A      �� 5C      $��1��6   $��Insurance Details��6(   .��5D      &   System.Windows.Controls.DataGrid     AutoGenerateColumns .    AzureDataGrid#��[  6_   ��6   �� *OwnerDetails+6_   5E      5F      5G      �� 5I   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��5q�6X   .+�5J      �� $��1��6   $��50��6%   $��50��61     MetroCircleButtonStyle#��[ 6f   ��6<   �� *RenewInsuranceCommand+.��5K      �� $��25��6   $��25��6'   
������� J� OpacityMask 5L      !� 5M       j� Stretch$
 Fill=�6&     appbar_add_multiple !� Visual# �  65   5O      5P      �� 5Q      $��1��6   $��50��6%   $��50��61   #��[ 6f   ��6<   �� *PrintQuotationCommand+.��5R      �� $��25��6   $��25��6'   
������� 5S      !� 5T      $
 Fill=�6&     appbar_printer# �  65   5V      5W      �� 5X      $��1��6   $��50��6%   $��50��61   #��[ 6g   ��6<   �� *DeleteQuotationCommand+.��5Y      �� $��25��6   $��25��6'   
������� 5Z      !� 5[      $
 Fill=�6&     appbar_delete# �  65   5]      5^      5_      5`      5a      