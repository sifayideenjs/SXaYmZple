   M S B A M L   `   `   `  ����P  LQuotation.LoginModule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Quotation.LoginModule.ViewsQuotation.LoginModule.Views  5      S OQuotation.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullyRclr-namespace:Quotation.Infrastructure.Constants;assembly=Quotation.Infrastructure"Quotation.Infrastructure.Constants 5      yRclr-namespace:Quotation.Infrastructure.Behaviors;assembly=Quotation.Infrastructure"Quotation.Infrastructure.Behaviors 5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      0    *Quotation.LoginModule.Views.UserManagement   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:Quotation.LoginModule.Views     5      T PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f8metro,http://metro.mahapps.com/winfx/xaml/controls  5      U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullX	 TMaterialDesignThemes.MahApps, Version=0.0.11.0, Culture=neutral, PublicKeyToken=nullBmaterial1http://materialdesigninxaml.net/winfx/xaml/themes  	 5      P
 LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8'prismlibhttp://prismlibrary.com/ 
 5	      )prismhttp://www.codeplex.com/prism 
 5
      einfConstantsRclr-namespace:Quotation.Infrastructure.Constants;assembly=Quotation.Infrastructure 
 5      einfBehaviorsRclr-namespace:Quotation.Infrastructure.Behaviors;assembly=Quotation.Infrastructure 
 5      3system&clr-namespace:System;assembly=mscorlib 
 5      ! 
 Prism.Mvvm.ViewModelLocator    AutoWireViewModel  . .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��0 �6   �� 5      $��* �6   .+�5   
   � $��0��6   
������� � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $��* �6#   �� 5      $
��auto �6#   .+�5      �� $��0��6   $��40��6%   $��40��61    *  &MaterialDesignFloatingActionDarkButton#��[  6a   $��2q�6�   ��6<   �� *DashboardCommand+.��5       �� $��15��6   $��15��6'   
������� J� OpacityMask 5!      !� 5"       j� Stretch$
 Fill=�6&     appbar_arrow_left !� Visual# �  65   5$      5%      �� 5&      $��1��6   $��User Management��6$   
�������$��22(�6Q   $��5 0 0 0q�6_   $��Center=�6p   5'      �� 5)   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $
��Left=�6;   $��5q�6V   .+�5*      �� $��50��6   $��50��6!   #��[  6O   $	��5 0q�6�   ��6,   �� *AddUserCommand+.��5+      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]   Kind$ AccountPlus=�6$   $��30��67   $��30��6C   5,      50      � 52   
   $��3��6   $��10 5 0 5q�6    53      �� 54      $
��Auto �6    �� 55      $��* �6    .+�57      �� $��1��6   $
��Auto=�6(   .��58      �� ��6   �� *Users+��59      �� 5:      .R�5;      � 5<      ��5>      �� 5?      .R�5@      &   MaterialDesignThemes.Wpf.Flipper    MaterialDesignCardFlipper#��[ 6/   $��0 30 0 0q�6b      FrontContent 5A   "   � 5B   &   $	��255��6+   $	��200��68    5C   *   �� 5D   .   $	��160 �6<   �� 5E   .   $��* �6<   .+�5G   *   (  "MaterialDesignThemes.Wpf.ColorZone  	   Mode$	 PrimaryLight=�6=   $��Stretch=�6Q   .��5H   .     $ AccountCircle=�6@   $	��128��6U   $	��128��6b   $��Center=�6n   $��Center=�6�   5I   +   �� 5J   *   $��1��65   $��Center=�6B   $��Center=�6_   .+�5K   .   �� $��Center=�6N   ��68   �� *Name+6N   �� 5L   .   $ 
Horizontal=�69   $��Center=�6R   .+�5M   2   ��   MaterialDesignFlatButton#��[ 69   
   FlipCommand#��Z
 6k   $��0 4 0 0q�6�   .��6�   EDIT6�   �� 5N   2   #��[ 69   $��0 4 0 0q�6�   ��6k   �� *DeleteCommand+.��6�   DELETE6�   5O   /   5P   +   5Q   '      BackContent 5S   "   � 5T   &   $	��255��6+   $	��200��68    5U   *   �� 5V   .   $
��Auto �6<   �� 5W   .   $��* �6<   .+�5Y   *     $	 Accent=�6=   $��6q�6K   .��5Z   .   �� $ 
Horizontal=�69   .+�5[   2   ��  & "MaterialDesignToolForegroundButton#��[ 69   #��Z
 6u   $
��Left=�6�   .��5\   6     $ 	ArrowLeft=�6H   $��Right=�6Y   5]   3   �� 5^   2   $��8 0 0 0q�6<   $��Center=�6M   	EDIT USER6s   5_   /   5`   +   � 5a   *   $��1��6/   $��0 0 0 0q�6<   $��Center=�6M   $	��Top=�6j   $	��172��6�    5b   .   �� 5c   2   �� 5d   2   �� 5e   2   �� 5f   2   �� 5g   2   .+�5i   .   �� )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Username��66      
IsFloating . $��0 5 0 0q�6�   ��6�   �� *
Username+�� 5j   .   $��1��66   $
 Name��6C    . $��0 5 0 0q�6�   ��6�   �� *Name+�� 5k   .   $��2��67   $ Group��6D   $��0 12 0 0q�6e    �� DisplayMemberPath$
 Name��6�   ��6w   �� *Groups+ �� SelectedItem 6�   �� *SelectedGroup+]� 5l   .   $��3��68   .+�5m   2   ��  + 'MaterialDesignFloatingActionLightButton#��[ 69   $��0 5 0 0q�6z   $��Right=�6�   $��30��6�   $��30��6�   ��6�   �� *ResetComand+��6�   ��  �� RelativeSource ��  �� AncestorType" ]�3  -MaterialDesignThemes.Wpf.ButtonProgressAssist   IsIndicatorVisible 66  �� *
IsSaving+   Value 6|  �� *SaveProgress+.��5n   6     $��24��6H   $��24��6T   ��5o   :   �� 5p   >    �� 
TargetType"  6D   .�5q   B   ��  �� Property �@ Kind �� Value$ 	Autorenew=�6Y    �� Triggers 5r   B   �� 5s   F    �� Binding 6R   �� *IsSaveComplete+ �� Value True6u   .a�5t   J   ��  �@ Kind$ Check=�6a    N� EnterActions 5u   J   �� 5v   N   .��5w   R   �� .��5x   V   W�  �� TargetProperty$ Opacity�6f    W� From$ 0X�6�   	 W� To$ 1X�6�    g� Duration$ 0:0:0.8D�6�   5y   S   5z   O   5|   G   5~   ?   5�   7   5�   3   G� 5�   2    G�Name$ passwordTextBox��6>   $��0 5 0 0q�6W   $ Reset Password��6h    ) %MaterialDesignFloatingHintPasswordBox#��[ 6�   5�   /   �� 5�   .   $��4��69   $ 
Horizontal=�6F   $��Center=�6_   .+�5�   2   �� #��[ 69   $��0 4 0 0q�6�   ��6k   �� *SaveCommand+.��6�   SAVE6�   �� 5�   2   #��[ 69   #��Z
 6k   $��0 4 0 0q�6�   .��6�   CANCEL6�   5�   /   5�   +   5�   '   5�      5�      5�      5�      5�      )  #MaterialDesignThemes.Wpf.DialogHost  5�   
       
Identifier$  
UserDialog��6   $��0��66   $��4��6C   $��Stretch=�6T   $��Stretch=�6r   5�      5�      