   M S B A M L   `   `   `  ���� Y  UQuotation.MotorInsuranceModule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:Quotation.MotorInsuranceModule.Views$Quotation.MotorInsuranceModule.Views  >    8Quotation.MotorInsuranceModule.Views.MotorInsuranceTiles   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Dlocal2clr-namespace:Quotation.MotorInsuranceModule.Views     T PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f8metro,http://metro.mahapps.com/winfx/xaml/controls  U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullX TMaterialDesignThemes.MahApps, Version=0.0.11.0, Culture=neutral, PublicKeyToken=nullBmaterial1http://materialdesigninxaml.net/winfx/xaml/themes   P LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8$prismhttp://prismlibrary.com/  O	 KWPFLocalizeExtension, Version=2.3.2.0, Culture=neutral, PublicKeyToken=null2lex(http://wpflocalizeextension.codeplex.com 	 = 	 7WPFLocalizeExtension.Providers.ResxLocalizationProvider    DefaultAssembly$$  Quotation.MotorInsuranceModule��   DefaultDictionary$ 	Resources��!  Prism.Mvvm.ViewModelLocator   AutoWireViewModel .  � 	Resources     BooleanToVisibilityConverter��%   &	        �� .���  � RowDefinitions �� $
��Auto ��� $
��Auto �.+�� $��0�� � ColumnDefinitions �� $
��Auto ��� $��* �.+��� $��0��
�������$��Center=�$��Center=�.���� 
�������$��30��$��30�� J� OpacityMask !�   appbar_motor !� Visual# [  j� Stretch$ Uniform=��� $��1��$��Motor Insurance��
�������$��22(�$��0q�
�������$��Stretch=��� $��1��	 �� Orientation$	 
Horizontal=�$��	5 15 0 15q�.+�!  MahApps.Metro.Controls.Tile  
   Title$
 New Quotation��$��Center=�$	��Top=�   
TiltFactor$ 1��$	��156��$	��150�����	#FF16B2D6$��Center=�   TitleFontSize$ 14��$��10 0 5 0q�y��� *CanNewProposal+���� *NewProposalCommand+.���� 
�������$��45��$��45�� !�   appbar_add02# [ $ Uniform=�  $
 Create Quotations��$��Center=�$	��Top=�$ 1��$	��156��$	��150�����	#FF16B2D6$��Center=�$ 14��$��10 0 5 0q�y��� *CanAddQuotation+���� *AddQuotationCommand+.���� 
�������$��45��$��45�� !�   
appbar_add# [ $ Uniform=�  $
 Search Quotation��$��Center=�$	��Top=�$ 1��$	��156��$	��150�����	#FF16B2D6$��Center=�$ 14��$��10 0 5 0q�y��� *CanSearchQuotation+���� *SearchQuotationCommand+.���� 
�������$��45��$��45�� !�   tile_search3# [ $ Uniform=�