   M S B A M L   `   `   `  ����Y  UQuotation.MotorInsuranceModule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:Quotation.MotorInsuranceModule.Views$Quotation.MotorInsuranceModule.Views  5      S OQuotation.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullyRclr-namespace:Quotation.Infrastructure.Constants;assembly=Quotation.Infrastructure"Quotation.Infrastructure.Constants 5
      yRclr-namespace:Quotation.Infrastructure.Behaviors;assembly=Quotation.Infrastructure"Quotation.Infrastructure.Behaviors 5      L HQuotation.Styling, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullbCclr-namespace:Quotation.Styling.Controls;assembly=Quotation.StylingQuotation.Styling.Controls 5      :    4Quotation.MotorInsuranceModule.Views.SearchQuotation   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dlocal2clr-namespace:Quotation.MotorInsuranceModule.Views     5      T PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f8metro,http://metro.mahapps.com/winfx/xaml/controls  5      P LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8'prismlibhttp://prismlibrary.com/  5      )prismhttp://www.codeplex.com/prism  5	      einfConstantsRclr-namespace:Quotation.Infrastructure.Constants;assembly=Quotation.Infrastructure  5
      einfBehaviorsRclr-namespace:Quotation.Infrastructure.Behaviors;assembly=Quotation.Infrastructure  5      QcontrolCclr-namespace:Quotation.Styling.Controls;assembly=Quotation.Styling  5      O	 KWPFLocalizeExtension, Version=2.3.2.0, Culture=neutral, PublicKeyToken=null2lex(http://wpflocalizeextension.codeplex.com 	 5      4 	 .WPFLocalizeExtension.Engine.LocalizeDictionary    DesignCulture$  de-DE��5      = 	 7WPFLocalizeExtension.Providers.ResxLocalizationProvider   DefaultAssembly$ Quotation.DashboardModule��5         DefaultDictionary$ 	Resources��5      !  Prism.Mvvm.ViewModelLocator   AutoWireViewModel . .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   � $��1��6   
������� � ColumnDefinitions 5       �� 5!      $
��auto �6#   �� 5"      $��* �6#   �� 5#      $
��auto �6#   .+�5%      �� $��0��6   $��40��6%   $��40��61    *  &MaterialDesignFloatingActionDarkButton#��[  6a   $��2q�6�   ��6<   �� *DashboardCommand+.��5&      �� $��15��6   $��15��6'   
������� J� OpacityMask 5'      !� 5(       j� Stretch$
 Fill=�6&     appbar_arrow_left !� Visual# �  65   5*      5+      �� 5,      $��1��6   $��Search Quotation��6$   $��5 0 0 0q�6?   $��20(�6P     HeaderFontFamily#���  6^   
�������$��Center=�6�   5-      � 5/   
   $��2��6   $��0q�6    50      �� 51      $
��Auto �6    �� 52      $��10 �6    �� 53      $��* �6    �� 54      $
��Auto �6    .+�57      � $��0��6   $��20 0 0 0q�6     58      �� 59      $	��250 �6'   �� 5:      $��10 �6'   �� 5;      $	��250 �6'   �� 5<      $	��250 �6'   �� 5=      $
��auto �6'    5@      �� 5A      $
��Auto �6$   �� 5B      $
��Auto �6$   .+�5E      �� $��0��6   $��0��6%   $��Search Type��65   $��14(�6K   �� 5F      $��1��6   *  $MahApps.Metro.Controls.TextBoxHelper	   	Watermark$	 Select Search type��6(   $��30��6[   $��5 0 0 0q�6g   
 �� SelectedIndex$
 0��6�    �� SelectedItem 6x   �� *
SearchType+ �� Mode$ TwoWay=���6�   ��  �� Path$ SearchTypes�5G      �� 5I      $��0��6   $��2��6%   $��Search Text��65   $��14(�6K   �� 5J      $��1��6   $��2��6'      ClearTextButton . $	 Enter Search text��6b   $��Center=�6�   $��30��6�   $��5 0 0 0q�6�   ��6�   �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=�$ TwoWay=��� 5L      $��1��6   $��3��6&   $��45��66   $��45��6B   #��[  6x   $
��Left=�6�   $��5 0 0 0q�6�   ��6M   �� *SearchQuotationCommand+.��5M      �� $��20��6    $��20��6+   
������� 5N      !� 5O      $
 Fill=�6*     appbar_arrow_right# �  69   5Q      5R      5S      � 5U      $��2��6   $��2��6    $��0 0 0 0q�64   .+�5V      �� -   5         ��Name$ MotorWizardRegion��5V   !   4  .Quotation.Infrastructure.Constants.RegionNames   MotorSearchRegion!  Prism.Regions.RegionManager   
RegionName# Z 6<   $��Stretch=�6�   $��Stretch=�6�   5W      5X      5Y      5Z      