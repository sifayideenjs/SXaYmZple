   M S B A M L   `   `   `  ���� Y  UQuotation.MotorInsuranceModule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:Quotation.MotorInsuranceModule.Views$Quotation.MotorInsuranceModule.Views  S OQuotation.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullyRclr-namespace:Quotation.Infrastructure.Constants;assembly=Quotation.Infrastructure"Quotation.Infrastructure.Constants yRclr-namespace:Quotation.Infrastructure.Behaviors;assembly=Quotation.Infrastructure"Quotation.Infrastructure.Behaviors L HQuotation.Styling, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullbCclr-namespace:Quotation.Styling.Controls;assembly=Quotation.StylingQuotation.Styling.Controls :    4Quotation.MotorInsuranceModule.Views.SearchQuotation   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Dlocal2clr-namespace:Quotation.MotorInsuranceModule.Views     T PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f8metro,http://metro.mahapps.com/winfx/xaml/controls  P LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8'prismlibhttp://prismlibrary.com/  )prismhttp://www.codeplex.com/prism  einfConstantsRclr-namespace:Quotation.Infrastructure.Constants;assembly=Quotation.Infrastructure  einfBehaviorsRclr-namespace:Quotation.Infrastructure.Behaviors;assembly=Quotation.Infrastructure  QcontrolCclr-namespace:Quotation.Styling.Controls;assembly=Quotation.Styling  O	 KWPFLocalizeExtension, Version=2.3.2.0, Culture=neutral, PublicKeyToken=null2lex(http://wpflocalizeextension.codeplex.com 	 4 	 .WPFLocalizeExtension.Engine.LocalizeDictionary    DesignCulture$  de-DE��= 	 7WPFLocalizeExtension.Providers.ResxLocalizationProvider   DefaultAssembly$ Quotation.DashboardModule��   DefaultDictionary$ 	Resources��!  Prism.Mvvm.ViewModelLocator   AutoWireViewModel . .���  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto �.+�� $��1��
������� � ColumnDefinitions �� $
��auto ��� $��* ��� $
��auto �.+��� $��0��$��40��$��40�� *  &MaterialDesignFloatingActionDarkButton#��[  $��2q����� *DashboardCommand+.���� $��15��$��15��
������� J� OpacityMask !�  j� Stretch$
 Fill=�  appbar_arrow_left !� Visual# �  �� $��1��$��Search Quotation��$��5 0 0 0q�$��20(�  HeaderFontFamily#���  
�������$��Center=�� $��2��$��0q� �� $
��Auto ��� $��10 ��� $��* ��� $
��Auto �.+�� $��0��$��20 0 0 0q� �� $	��250 ��� $��10 ��� $	��250 ��� $	��250 ��� $
��auto � �� $
��Auto ��� $
��Auto �.+��� $��0��$��0��$��Search Type��$��14(��� $��1��*  $MahApps.Metro.Controls.TextBoxHelper	   	Watermark$	 Select Search type��$��30��$��5 0 0 0q�
 �� SelectedIndex$
 0�� �� SelectedItem �� *
SearchType+ �� Mode$ TwoWay=�����  �� Path$ SearchTypes��� $��0��$��2��$��Search Text��$��14(��� $��1��$��2��   ClearTextButton . $	 Enter Search text��$��Center=�$��30��$��5 0 0 0q����� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=�$ TwoWay=��� $��1��$��3��$��45��$��45��#��[  $
��Left=�$��5 0 0 0q����� *SearchQuotationCommand+.���� $��20��$��20��
������� !� $
 Fill=�  appbar_arrow_right# �  � $��2��$��2��$��0 0 0 0q�.+��� -    ��Name$ MotorWizardRegion��4  .Quotation.Infrastructure.Constants.RegionNames   MotorSearchRegion!  Prism.Regions.RegionManager   
RegionName# Z $��Stretch=�$��Stretch=�