   M S B A M L   `   `   `  ���� Y  UQuotation.MotorInsuranceModule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullw@clr-namespace:Quotation.MotorInsuranceModule.Views.SearchWizards2Quotation.MotorInsuranceModule.Views.SearchWizards  S OQuotation.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullyRclr-namespace:Quotation.Infrastructure.Constants;assembly=Quotation.Infrastructure"Quotation.Infrastructure.Constants yRclr-namespace:Quotation.Infrastructure.Behaviors;assembly=Quotation.Infrastructure"Quotation.Infrastructure.Behaviors L HQuotation.Styling, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullbCclr-namespace:Quotation.Styling.Controls;assembly=Quotation.StylingQuotation.Styling.Controls O    IQuotation.MotorInsuranceModule.Views.SearchWizards.InsuranceRenewalDetail   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Rlocal@clr-namespace:Quotation.MotorInsuranceModule.Views.SearchWizards     T PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f8metro,http://metro.mahapps.com/winfx/xaml/controls  P LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8'prismlibhttp://prismlibrary.com/  )prismhttp://www.codeplex.com/prism  einfConstantsRclr-namespace:Quotation.Infrastructure.Constants;assembly=Quotation.Infrastructure  einfBehaviorsRclr-namespace:Quotation.Infrastructure.Behaviors;assembly=Quotation.Infrastructure  QcontrolCclr-namespace:Quotation.Styling.Controls;assembly=Quotation.Styling  !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  . .���  � RowDefinitions �� $��* ��� $
��auto ��� $
��auto �.+��� $
��Auto=�.���  �� $
��Auto ��� $��* �.+��� $��0q�$��0��$��20(�   HeaderFontFamily#���   
�������.��Insurance Renewal Details� $��5 5 5 5q�$��1�� � ColumnDefinitions �� $	��180 ��� $��* ��� $��* � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��0��$��Center=�
�������$��14(�.��Insurance Expiry Date:(  "System.Windows.Controls.DatePicker  $��0��$��1��$��Center=�$��5q�   SelectedDate �� *-+CurrentInsuranceDetails.InsuranceExpiryDate+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnExceptions .  �� NotifyOnValidationError .  �� ValidatesOnDataErrors . �� $��2��$��0��$��Center=�
�������$��14(�.��Road Tax Expiry Date:  $��2��$��1��$��Center=�$��5q� �� *+)CurrentInsuranceDetails.RoadTaxExpiryDate+$ TwoWay=�$ PropertyChanged=� .  .  . �� $��4��$��0��$��Center=�
�������$��14(�.��Previous Dealer:�� $��4��$��1��*  $MahApps.Metro.Controls.TextBoxHelper	   ClearTextButton	 . $��Center=�$��5q����� *(&CurrentInsuranceDetails.PreviousDealer+$ TwoWay=�$ PropertyChanged=� .  .  . �� $��5��$��0��$��Center=�
�������$��14(�.��	Agency:�� $��5��$��1��	 . $��Center=�$��5q����� * CurrentInsuranceDetails.Agency+$ TwoWay=�$ PropertyChanged=� .  .  . �� $��6��$��0��$��Center=�
�������$��14(�.��Finance Bank:�� $��6��$��1��	 . $��Center=�$��5q����� *%#CurrentInsuranceDetails.FinanceBank+$ TwoWay=�$ PropertyChanged=� .  .  . �� $��7��$��0��$��Center=�
�������$��14(�.��Previous Year Premium:�� $��7��$��1��	 . $	��Top=�
 �� TextWrapping$

 Wrap=� �� AcceptsReturn . $	��100��$��5q����� *)'CurrentInsuranceDetails.PrevYearPremium+$ TwoWay=�$ PropertyChanged=� .  .  . �� $��1�� �� Orientation$ 
Horizontal=�$��Center=�$��5q�.+��� $��1��$��50��$��50��  MetroCircleButtonStyle#��[ ���� *AddInsuranceCommand+.���� $��25��$��25��
������� J� OpacityMask !�  j� Stretch$
 Fill=�  appbar_save !� Visual# �  