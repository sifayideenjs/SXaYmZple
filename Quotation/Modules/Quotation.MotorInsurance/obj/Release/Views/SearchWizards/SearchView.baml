   M S B A M L   `   `   `  ���� Y  UQuotation.MotorInsuranceModule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullw@clr-namespace:Quotation.MotorInsuranceModule.Views.SearchWizards2Quotation.MotorInsuranceModule.Views.SearchWizards  S OQuotation.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullyRclr-namespace:Quotation.Infrastructure.Constants;assembly=Quotation.Infrastructure"Quotation.Infrastructure.Constants yRclr-namespace:Quotation.Infrastructure.Behaviors;assembly=Quotation.Infrastructure"Quotation.Infrastructure.Behaviors L HQuotation.Styling, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullbCclr-namespace:Quotation.Styling.Controls;assembly=Quotation.StylingQuotation.Styling.Controls C    =Quotation.MotorInsuranceModule.Views.SearchWizards.SearchView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Rlocal@clr-namespace:Quotation.MotorInsuranceModule.Views.SearchWizards     T PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f8metro,http://metro.mahapps.com/winfx/xaml/controls  P LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8'prismlibhttp://prismlibrary.com/  )prismhttp://www.codeplex.com/prism  einfConstantsRclr-namespace:Quotation.Infrastructure.Constants;assembly=Quotation.Infrastructure  einfBehaviorsRclr-namespace:Quotation.Infrastructure.Behaviors;assembly=Quotation.Infrastructure  QcontrolCclr-namespace:Quotation.Styling.Controls;assembly=Quotation.Styling  !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  . ���	#FF252526.���  � RowDefinitions �� $��* ��� $
��auto �.+��� $��0��$
��Auto=�.���  �� $
��auto ��� $��* ��� $
��auto ��� $
��auto �.+��� $��0��$��Insured Details��.��� $��1�� � ColumnDefinitions �� $	��180 ��� $��* � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��0��$��Center=�
�������$��14(�$��SemiBold"�.��Insured Name:�� $��0��$��1��
�������$��14(�$��5q����� *Name+ �� Mode$ TwoWay=��� $��1��$��0��$��Center=�
�������$��14(�.��NRIC / Biz Reg No:�� $��1��$��1��
�������$��14(�$��5q����� *NRIC+$ TwoWay=��� $��3��$��0��$��Center=�
�������$��14(�.��	Gender:�� $��3��$��1��
�������$��14(�$��5q����� *Gender+$ TwoWay=��� $��5��$��0��$��Center=�
�������$��14(�.��Occupation / Industry:�� $��5��$��1��
�������$��14(�$��5q����� *
Occupation+$ TwoWay=��� $��6��$��0��$��Center=�
�������$��14(�.��License Date:�� $��6��$��1��
�������$��14(�$��5q����� *LicenseDate+$ TwoWay=��� $��1��$��Insurance Details��.��&   System.Windows.Controls.DataGrid     AutoGenerateColumns .    AzureDataGrid#��[  ���� *OwnerDetails+�� $��1�� �� Orientation$ 
Horizontal=�$��Center=�$��5q�.+��� $��1��$��50��$��50��  MetroCircleButtonStyle#��[ ���� *RenewInsuranceCommand+.���� $��25��$��25��
������� J� OpacityMask !�  j� Stretch$
 Fill=�  appbar_add_multiple !� Visual# �  �� $��1��$��50��$��50��#��[ ���� *PrintQuotationCommand+.���� $��25��$��25��
������� !� $
 Fill=�  appbar_printer# �  �� $��1��$��50��$��50��#��[ ���� *DeleteQuotationCommand+.���� $��25��$��25��
������� !� $
 Fill=�  appbar_delete# �  