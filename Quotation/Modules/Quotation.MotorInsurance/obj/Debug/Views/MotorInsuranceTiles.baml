   M S B A M L   `   `   `  ����Y  UQuotation.MotorInsuranceModule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:Quotation.MotorInsuranceModule.Views$Quotation.MotorInsuranceModule.Views  5      >    8Quotation.MotorInsuranceModule.Views.MotorInsuranceTiles   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dlocal2clr-namespace:Quotation.MotorInsuranceModule.Views     5      T PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f8metro,http://metro.mahapps.com/winfx/xaml/controls  5      U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullX TMaterialDesignThemes.MahApps, Version=0.0.11.0, Culture=neutral, PublicKeyToken=nullBmaterial1http://materialdesigninxaml.net/winfx/xaml/themes   5      P LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8$prismhttp://prismlibrary.com/  5	      O	 KWPFLocalizeExtension, Version=2.3.2.0, Culture=neutral, PublicKeyToken=null2lex(http://wpflocalizeextension.codeplex.com 	 5
      = 	 7WPFLocalizeExtension.Providers.ResxLocalizationProvider    DefaultAssembly$$  Quotation.MotorInsuranceModule��5         DefaultDictionary$ 	Resources��5      !  Prism.Mvvm.ViewModelLocator   AutoWireViewModel .  � 	Resources 5          BooleanToVisibilityConverter��%   &	        �� 5   
   6'   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#   .+�5      �� $��0��6   
�������$��Center=�66   $��Center=�6X   .��5      �� 
�������$��30��6)   $��30��65    J� OpacityMask 5       !� 5!        appbar_motor !� Visual# [ 6&    j� Stretch$ Uniform=�6M   5#      5$      �� 5%      $��1��6   $��Motor Insurance��6$   
�������$��22(�6Q   $��0q�6_   
�������$��Stretch=�6|   5&      �� 5)   
   $��1��6   	 �� Orientation$	 
Horizontal=�6"   $��	5 15 0 15q�6;   .+�5*      !  MahApps.Metro.Controls.Tile  
   Title$
 New Quotation��6   $��Center=�5,      $	��Top=�5-         
TiltFactor$ 1��5.      $	��156��5/      $	��150��50      ���	#FF16B2D6$��Center=�51   0      TitleFontSize$ 14��6T   $��10 0 5 0q�6g   y�5*   /   �� *CanNewProposal+��5+      �� *NewProposalCommand+.��52      �� 
�������$��45��6)   $��45��65    53      !� 54        appbar_add02# [ 6&   $ Uniform=�6M   56      57        58      $
 Create Quotations��6   $��Center=�5:      $	��Top=�5;      $ 1��5<      $	��156��5=      $	��150��5>      ���	#FF16B2D6$��Center=�5?   0   $ 14��6T   $��10 0 5 0q�6g   y�58   4   �� *CanAddQuotation+��59      �� *AddQuotationCommand+.��5@      �� 
�������$��45��6)   $��45��65    5A      !� 5B        
appbar_add# [ 6&   $ Uniform=�6K   5D      5E        5F      $
 Search Quotation��6   $��Center=�5H      $	��Top=�5I      $ 1��5J      $	��156��5K      $	��150��5L      ���	#FF16B2D6$��Center=�5M   0   $ 14��6T   $��10 0 5 0q�6g   y�5F   2   �� *CanSearchQuotation+��5G      �� *SearchQuotationCommand+.��5N      �� 
�������$��45��6)   $��45��65    5O      !� 5P        tile_search3# [ 6&   $ Uniform=�6M   5R      5S      5d      5e      5g      