   M S B A M L   `   `   `  ���� P  LQuotation.LoginModule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Quotation.LoginModule.ViewsQuotation.LoginModule.Views  S.clr-namespace:Quotation.LoginModule.ViewModels Quotation.LoginModule.ViewModels  S OQuotation.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullyRclr-namespace:Quotation.Infrastructure.Constants;assembly=Quotation.Infrastructure"Quotation.Infrastructure.Constants yRclr-namespace:Quotation.Infrastructure.Behaviors;assembly=Quotation.Infrastructure"Quotation.Infrastructure.Behaviors O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 1    +Quotation.LoginModule.Views.GroupManagement   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ;local)clr-namespace:Quotation.LoginModule.Views     D	viewmodel.clr-namespace:Quotation.LoginModule.ViewModels     T PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f8metro,http://metro.mahapps.com/winfx/xaml/controls  U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullX	 TMaterialDesignThemes.MahApps, Version=0.0.11.0, Culture=neutral, PublicKeyToken=nullBmaterial1http://materialdesigninxaml.net/winfx/xaml/themes  	 P
 LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8'prismlibhttp://prismlibrary.com/ 
 )prismhttp://www.codeplex.com/prism 
 einfConstantsRclr-namespace:Quotation.Infrastructure.Constants;assembly=Quotation.Infrastructure 
 einfBehaviorsRclr-namespace:Quotation.Infrastructure.Behaviors;assembly=Quotation.Infrastructure 
 3system&clr-namespace:System;assembly=mscorlib 
 ! 
 Prism.Mvvm.ViewModelLocator    AutoWireViewModel  . .���  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��0 ��� $��* �.+�� $��0��
������� � ColumnDefinitions �� $
��auto ��� $��* ��� $
��auto �.+��� $��0��$��40��$��40�� *  &MaterialDesignFloatingActionDarkButton#��[  $��2q����� *DashboardCommand+.���� $��15��$��15��
������� J� OpacityMask !�  j� Stretch$
 Fill=�  appbar_arrow_left !� Visual# �  �� $��1��$��Group Management��
�������$��22(�$��5 0 0 0q�$��Center=��� $��1�� �� Orientation$ 
Horizontal=�$
��Left=�$��5q�.+��� $��50��$��50��#��[  $	��5 0q����� *AddGroupCommand+.��'  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]   Kind$ AccountMultiplePlus=�$��30��$��30��� $��3��$��10 5 0 5q� �� $
��Auto ��� $��* �.+��� $��1��$
��Auto=�.���� ���� *Groups+���� .R��  � Orientation$ 
Horizontal=����� .R�#  MaterialDesignThemes.Wpf.Card    PrimaryHueDarkBrush#���   ! PrimaryHueDarkForegroundBrush#���  $
��auto��$��10q�.���� .+��� $��	16 5 12 5q�$��16(����� *Name+�� $��1��   MaterialDesignLightSeparator#��[ �� 	 � IsSharedSizeScope	 . $��	16 4 16 0q����� *Forms+���� 
 �� DataType9   3Quotation.LoginModule.ViewModels.GroupFormViewModel"
  .R���  ��Name$ Border�� �� Padding$ 8q�._��  ��  z� SharedSizeGroup$ Checkerz���� .+��� $��Center=� ( $MaterialDesignUserForegroundCheckBox#��[  d� 	IsChecked �� *
IsSelected+�� $��8 0 0 0q�$��1��.+��� ���� *Name+�� #��[ �� $��8 0 8 8q�$ 
Horizontal=�$��Right=�.+��� $��Right=� & "MaterialDesignToolForegroundButton#��[ $��30��$��2 0 0 0q�+  %MaterialDesignThemes.Wpf.RippleAssist   
IsCentered . ���� *SaveCommand+.��  $ ContentSave=�)  #MaterialDesignThemes.Wpf.DialogHost     
Identifier$ GroupDialog��$��0��$��4��$��Stretch=�$��Stretch=�