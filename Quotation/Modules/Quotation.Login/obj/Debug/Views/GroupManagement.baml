   M S B A M L   `   `   `  ����P  LQuotation.LoginModule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Quotation.LoginModule.ViewsQuotation.LoginModule.Views  5      S.clr-namespace:Quotation.LoginModule.ViewModels Quotation.LoginModule.ViewModels  5      S OQuotation.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullyRclr-namespace:Quotation.Infrastructure.Constants;assembly=Quotation.Infrastructure"Quotation.Infrastructure.Constants 5      yRclr-namespace:Quotation.Infrastructure.Behaviors;assembly=Quotation.Infrastructure"Quotation.Infrastructure.Behaviors 5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      1    +Quotation.LoginModule.Views.GroupManagement   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:Quotation.LoginModule.Views     5      D	viewmodel.clr-namespace:Quotation.LoginModule.ViewModels     5      T PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f8metro,http://metro.mahapps.com/winfx/xaml/controls  5      U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullX	 TMaterialDesignThemes.MahApps, Version=0.0.11.0, Culture=neutral, PublicKeyToken=nullBmaterial1http://materialdesigninxaml.net/winfx/xaml/themes  	 5	      P
 LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8'prismlibhttp://prismlibrary.com/ 
 5
      )prismhttp://www.codeplex.com/prism 
 5      einfConstantsRclr-namespace:Quotation.Infrastructure.Constants;assembly=Quotation.Infrastructure 
 5      einfBehaviorsRclr-namespace:Quotation.Infrastructure.Behaviors;assembly=Quotation.Infrastructure 
 5      3system&clr-namespace:System;assembly=mscorlib 
 5      ! 
 Prism.Mvvm.ViewModelLocator    AutoWireViewModel  . .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��0 �6   �� 5      $��* �6   .+�5   
   � $��0��6   
������� � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $��* �6#   �� 5      $
��auto �6#   .+�5       �� $��0��6   $��40��6%   $��40��61    *  &MaterialDesignFloatingActionDarkButton#��[  6a   $��2q�6�   ��6<   �� *DashboardCommand+.��5!      �� $��15��6   $��15��6'   
������� J� OpacityMask 5"      !� 5#       j� Stretch$
 Fill=�6&     appbar_arrow_left !� Visual# �  65   5%      5&      �� 5'      $��1��6   $��Group Management��6$   
�������$��22(�6R   $��5 0 0 0q�6`   $��Center=�6q   5(      �� 5*   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $
��Left=�6;   $��5q�6V   .+�5+      �� $��50��6   $��50��6!   #��[  6P   $	��5 0q�6�   ��6,   �� *AddGroupCommand+.��5,      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]   Kind$ AccountMultiplePlus=�6$   $��30��6?   $��30��6K   5-      51      � 53   
   $��3��6   $��10 5 0 5q�6    54      �� 55      $
��Auto �6    �� 56      $��* �6    .+�58      �� $��1��6   $
��Auto=�6(   .��59      �� ��6   �� *Groups+��5:      �� 5;      .R�5<      �  � Orientation$ 
Horizontal=�6)   5=      ��5?      �� 5@      .R�5A      #  MaterialDesignThemes.Wpf.Card    PrimaryHueDarkBrush#���  6,    ! PrimaryHueDarkForegroundBrush#���  6_   $
��auto��6�   $��10q�6�   .��5B   "   �� .+�5C   &   �� $��	16 5 12 5q�60   $��16(�6C   ��6Q   �� *Name+�� 5D   &   $��1��60      MaterialDesignLightSeparator#��[ 6=   �� 5E   &   	 � IsSharedSizeScope	 . $��	16 4 16 0q�6p   ��64   �� *Forms+��5F   *   �� 5G   .   
 �� DataType9   3Quotation.LoginModule.ViewModels.GroupFormViewModel"
  6;   .R�5H   2   ��  ��Name$ Border��69    �� Padding$ 8q�6I   ._�5I   6   �  5J   :   �� 5K   >    z� SharedSizeGroup$ Checkerz��6O   �� 5L   >   .+�5N   :   �� $��Center=�6C    ( $MaterialDesignUserForegroundCheckBox#��[ 6    d� 	IsChecked 6^   �� *
IsSelected+6   �� 5O   :   $��8 0 0 0q�6E   $��1��6V   .+�5P   >   �� ��6H   �� *Name+5Q   ;   5R   7   5S   3   5T   /   5V   '   �� 5W   &   #��[ 60   �� 5X   &   $��8 0 8 8q�61   $ 
Horizontal=�6B   $��Right=�6[   .+�5Y   *   �� $��Right=�61    & "MaterialDesignToolForegroundButton#��[ 6m   $��30��6�   $��2 0 0 0q�6�   +  %MaterialDesignThemes.Wpf.RippleAssist   
IsCentered . ��6M   �� *SaveCommand+.��5Z   .     $ ContentSave=�6@   5[   +   5\   '   5]   #   5^      5_      5f      5g      5h      )  #MaterialDesignThemes.Wpf.DialogHost  5j   
      
Identifier$ GroupDialog��6   $��0��67   $��4��6D   $��Stretch=�6U   $��Stretch=�6s   5k      5l      