   M S B A M L   `   `   `  ����Y  UQuotation.MotorInsuranceModule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullw@clr-namespace:Quotation.MotorInsuranceModule.Views.SearchWizards2Quotation.MotorInsuranceModule.Views.SearchWizards  5      S OQuotation.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullyRclr-namespace:Quotation.Infrastructure.Constants;assembly=Quotation.Infrastructure"Quotation.Infrastructure.Constants 5
      yRclr-namespace:Quotation.Infrastructure.Behaviors;assembly=Quotation.Infrastructure"Quotation.Infrastructure.Behaviors 5      L HQuotation.Styling, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullbCclr-namespace:Quotation.Styling.Controls;assembly=Quotation.StylingQuotation.Styling.Controls 5      O    IQuotation.MotorInsuranceModule.Views.SearchWizards.InsuranceRenewalDetail   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Rlocal@clr-namespace:Quotation.MotorInsuranceModule.Views.SearchWizards     5      T PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f8metro,http://metro.mahapps.com/winfx/xaml/controls  5      P LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8'prismlibhttp://prismlibrary.com/  5      )prismhttp://www.codeplex.com/prism  5	      einfConstantsRclr-namespace:Quotation.Infrastructure.Constants;assembly=Quotation.Infrastructure  5
      einfBehaviorsRclr-namespace:Quotation.Infrastructure.Behaviors;assembly=Quotation.Infrastructure  5      QcontrolCclr-namespace:Quotation.Styling.Controls;assembly=Quotation.Styling  5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  . .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $
��Auto=�6   .��5      �  5      �� 5      $
��Auto �6$   �� 5      $��* �6$   .+�5      �� $��0q�6   $��0��6#   $��20(�5         HeaderFontFamily#���   5      
�������.��5       Insurance Renewal Details64   � 5"      $��5 5 5 5q�6   $��1��6(    � ColumnDefinitions 5#      �� 5$      $	��180 �6+   �� 5%      $��* �6+   �� 5&      $��* �6+    5(      �� 5)      $
��Auto �6(   68   �� 5*      $
��Auto �6(   68   �� 5+      $
��Auto �6(   68   �� 5,      $
��Auto �6(   68   �� 5-      $
��Auto �6(   68   �� 5.      $
��Auto �6(   68   �� 5/      $
��Auto �6(   68   �� 50      $
��Auto �6(   68   �� 51      $
��Auto �6(   68   .+�54      �� $��0��6   $��0��6)   $��Center=�69   
�������$��14(�6k   .��6y   Insurance Expiry Date:6�   (  "System.Windows.Controls.DatePicker  55      $��0��6!   $��1��6.   $��Center=�6>   $��5q�56         SelectedDate 55   `   �� *-+CurrentInsuranceDetails.InsuranceExpiryDate+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnExceptions .  �� NotifyOnValidationError .  �� ValidatesOnDataErrors . 56      �� 5;      $��2��6   $��0��6)   $��Center=�69   
�������$��14(�6k   .��6y   Road Tax Expiry Date:6�     5<      $��2��6!   $��1��6.   $��Center=�6>   $��5q�5=       5<   `   �� *+)CurrentInsuranceDetails.RoadTaxExpiryDate+$ TwoWay=�$ PropertyChanged=� .  .  . 5=      �� 5B      $��4��6   $��0��6)   $��Center=�69   
�������$��14(�6k   .��6y   Previous Dealer:6�   �� 5C      $��4��6   $��1��6+   *  $MahApps.Metro.Controls.TextBoxHelper	   ClearTextButton	 . $��Center=�6f   $��5q�5D      ��5C   �   �� *(&CurrentInsuranceDetails.PreviousDealer+$ TwoWay=�$ PropertyChanged=� .  .  . 5D      �� 5F      $��5��6   $��0��6)   $��Center=�69   
�������$��14(�6k   .��6y   	Agency:6�   �� 5G      $��5��6   $��1��6+   	 . $��Center=�6f   $��5q�5H      ��5G   �   �� * CurrentInsuranceDetails.Agency+$ TwoWay=�$ PropertyChanged=� .  .  . 5H      �� 5J      $��6��6   $��0��6)   $��Center=�69   
�������$��14(�6k   .��6y   Finance Bank:6�   �� 5K      $��6��6   $��1��6+   	 . $��Center=�6f   $��5q�5L      ��5K   �   �� *%#CurrentInsuranceDetails.FinanceBank+$ TwoWay=�$ PropertyChanged=� .  .  . 5L      �� 5N      $��7��6   $��0��6)   $��Center=�69   
�������$��14(�6k   .��6y   Previous Year Premium:6�   �� 5O      $��7��6   $��1��6+   	 . $	��Top=�6f   
 �� TextWrapping$

 Wrap=�6�    �� AcceptsReturn . $	��100��6�   $��5q�5Q      ��5P      �� *)'CurrentInsuranceDetails.PrevYearPremium+$ TwoWay=�$ PropertyChanged=� .  .  . 5Q      5T      5U      5V      �� 5X   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��5q�6X   .+�5Y      �� $��1��6   $��50��6%   $��50��61     MetroCircleButtonStyle#��[ 6d   ��6<   �� *AddInsuranceCommand+.��5Z      �� $��25��6   $��25��6'   
������� J� OpacityMask 5[      !� 5\       j� Stretch$
 Fill=�6&     appbar_save !� Visual# �  65   5^      5_      5`      5a      5b      