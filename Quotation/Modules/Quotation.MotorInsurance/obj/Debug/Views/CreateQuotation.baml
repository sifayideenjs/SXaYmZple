   M S B A M L   `   `   `  ����Y  UQuotation.MotorInsuranceModule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:Quotation.MotorInsuranceModule.Views$Quotation.MotorInsuranceModule.Views  5      S OQuotation.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullyRclr-namespace:Quotation.Infrastructure.Constants;assembly=Quotation.Infrastructure"Quotation.Infrastructure.Constants 5      yRclr-namespace:Quotation.Infrastructure.Behaviors;assembly=Quotation.Infrastructure"Quotation.Infrastructure.Behaviors 5      {Sclr-namespace:Quotation.Infrastructure.Converters;assembly=Quotation.Infrastructure#Quotation.Infrastructure.Converters 5      L HQuotation.Styling, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullbCclr-namespace:Quotation.Styling.Controls;assembly=Quotation.StylingQuotation.Styling.Controls 5      :    4Quotation.MotorInsuranceModule.Views.CreateQuotation   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dlocal2clr-namespace:Quotation.MotorInsuranceModule.Views     5      T PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f8metro,http://metro.mahapps.com/winfx/xaml/controls  5      U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullX	 TMaterialDesignThemes.MahApps, Version=0.0.11.0, Culture=neutral, PublicKeyToken=nullBmaterial1http://materialdesigninxaml.net/winfx/xaml/themes  	 5      P
 LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8'prismlibhttp://prismlibrary.com/ 
 5	      )prismhttp://www.codeplex.com/prism 
 5
      einfConstantsRclr-namespace:Quotation.Infrastructure.Constants;assembly=Quotation.Infrastructure 
 5      einfBehaviorsRclr-namespace:Quotation.Infrastructure.Behaviors;assembly=Quotation.Infrastructure 
 5      ginfConvertersSclr-namespace:Quotation.Infrastructure.Converters;assembly=Quotation.Infrastructure 
 5      QcontrolCclr-namespace:Quotation.Styling.Controls;assembly=Quotation.Styling 
 5      ! 
 Prism.Mvvm.ViewModelLocator    AutoWireViewModel  .  � 	Resources 5      A  ;Quotation.Infrastructure.Converters.YesNoToBooleanConverter   YesNoToBooleanConverterE  ?Quotation.Infrastructure.Converters.ZeroCollapsedNonZeroVisible  ZeroCollapsedNonZeroVisible��%:   &	        &	        5   
   60     5   
   64   5      .��5      � -   5         �Name$
 root��5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   � $��0��6   
������� � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5       $��* �6#   �� 5!      $
��auto �6#   .+�5#      �� $��0��6   $��40��6%   $��40��61    * &MaterialDesignFloatingActionDarkButton#��[ 6a   $��2q�6�   ��6<   �� *DashboardCommand+.��5$      �� $��15��6   $��15��6'   
������� J� OpacityMask 5%      !� 5&       j� Stretch$
 Fill=�6&     appbar_arrow_left !� Visual# �  65   5(      5)      �� 5*      $��1��6   $��Create Quotation��6$   
�������$��22(�6R   $��5 0 0 0q�6`   $��Center=�6q   5+      � 5-   
   $��1��6   $��45 0 0 0q�6    5.      �� 5/      $	��250 �6#   �� 50      $	��250 �6#   �� 51      $
��auto �6#    54      �� 55      $
��Auto �6    �� 56      $
��Auto �6    .+�59      �� $��0��6   $��0��6!   $
��NRIC��61   $��14(�6@   �� 5:      $��1��6   $��0��6#   *  $MahApps.Metro.Controls.TextBoxHelper   ClearTextButton . 	   	Watermark$	 Enter NRIC number��6^   $��Center=�6�   $��30��6�   $��5 0 0 0q�6�   ��6�   �� *
SearchText+
 �� UpdateSourceTrigger$
 PropertyChanged=� �� Mode$ TwoWay=��� 5<      $��1��6   $��1��6"   $��45��62   $��45��6>   #��[ 6t   $
��Left=�6�   $��5 0 0 0q�6�   ��6I   �� *SearchQuotationCommand+.��5=      �� $��20��6   $��20��6'   
������� 5>      !� 5?      $
 Fill=�6&     appbar_arrow_right# �  65   5A      5B      5C      � 5E   
   $��2��6   $��25 0 0 0q�6   .+�5F      �� -   5         ��Name$ MotorRenewQuotationRegion��5F      4  .Quotation.Infrastructure.Constants.RegionNames    MotorRenewQuotationRegion! 
 Prism.Regions.RegionManager   
RegionName# Z 6@   $��Stretch=�6�   $��Stretch=�6�   5G      5H      5I      