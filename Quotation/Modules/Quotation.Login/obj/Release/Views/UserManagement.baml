   M S B A M L   `   `   `  ���� P  LQuotation.LoginModule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Quotation.LoginModule.ViewsQuotation.LoginModule.Views  S OQuotation.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullyRclr-namespace:Quotation.Infrastructure.Constants;assembly=Quotation.Infrastructure"Quotation.Infrastructure.Constants yRclr-namespace:Quotation.Infrastructure.Behaviors;assembly=Quotation.Infrastructure"Quotation.Infrastructure.Behaviors O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 0    *Quotation.LoginModule.Views.UserManagement   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ;local)clr-namespace:Quotation.LoginModule.Views     T PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f8metro,http://metro.mahapps.com/winfx/xaml/controls  U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullX	 TMaterialDesignThemes.MahApps, Version=0.0.11.0, Culture=neutral, PublicKeyToken=nullBmaterial1http://materialdesigninxaml.net/winfx/xaml/themes  	 P
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
 Fill=�  appbar_arrow_left !� Visual# �  �� $��1��$��User Management��
�������$��22(�$��5 0 0 0q�$��Center=��� $��1�� �� Orientation$ 
Horizontal=�$
��Left=�$��5q�.+��� $��50��$��50��#��[  $	��5 0q����� *AddUserCommand+.��'  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]   Kind$ AccountPlus=�$��30��$��30��� $��3��$��10 5 0 5q� �� $
��Auto ��� $��* �.+��� $��1��$
��Auto=�.���� ���� *Users+���� .R�� ���� .R�&   MaterialDesignThemes.Wpf.Flipper    MaterialDesignCardFlipper#��[ $��0 30 0 0q�   FrontContent � $	��255��$	��200�� �� $	��160 ��� $��* �.+�(  "MaterialDesignThemes.Wpf.ColorZone  	   Mode$	 PrimaryLight=�$��Stretch=�.��  $ AccountCircle=�$	��128��$	��128��$��Center=�$��Center=��� $��1��$��Center=�$��Center=�.+��� $��Center=����� *Name+�� $ 
Horizontal=�$��Center=�.+���   MaterialDesignFlatButton#��[ 
   FlipCommand#��Z
 $��0 4 0 0q�.��EDIT�� #��[ $��0 4 0 0q����� *DeleteCommand+.��DELETE   BackContent � $	��255��$	��200�� �� $
��Auto ��� $��* �.+�  $	 Accent=�$��6q�.���� $ 
Horizontal=�.+���  & "MaterialDesignToolForegroundButton#��[ #��Z
 $
��Left=�.��  $ 	ArrowLeft=�$��Right=��� $��8 0 0 0q�$��Center=�	EDIT USER� $��1��$��0 0 0 0q�$��Center=�$	��Top=�$	��172�� �� �� �� �� �� .+��� )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Username��   
IsFloating . $��0 5 0 0q����� *
Username+�� $��1��$
 Name�� . $��0 5 0 0q����� *Name+�� $��2��$ Group��$��0 12 0 0q� �� DisplayMemberPath$
 Name������ *Groups+ �� SelectedItem �� *SelectedGroup+]� $��3��.+���  + 'MaterialDesignFloatingActionLightButton#��[ $��0 5 0 0q�$��Right=�$��30��$��30������ *ResetComand+����  �� RelativeSource ��  �� AncestorType" ]�3  -MaterialDesignThemes.Wpf.ButtonProgressAssist   IsIndicatorVisible �� *
IsSaving+   Value �� *SaveProgress+.��  $��24��$��24������  �� 
TargetType"  .���  �� Property �@ Kind �� Value$ 	Autorenew=� �� Triggers ��  �� Binding �� *IsSaveComplete+ �� Value True.a���  �@ Kind$ Check=� N� EnterActions �� .���� .��W�  �� TargetProperty$ Opacity� W� From$ 0X�	 W� To$ 1X� g� Duration$ 0:0:0.8D�G�  G�Name$ passwordTextBox��$��0 5 0 0q�$ Reset Password�� ) %MaterialDesignFloatingHintPasswordBox#��[ �� $��4��$ 
Horizontal=�$��Center=�.+��� #��[ $��0 4 0 0q����� *SaveCommand+.��SAVE�� #��[ #��Z
 $��0 4 0 0q�.��CANCEL)  #MaterialDesignThemes.Wpf.DialogHost      
Identifier$  
UserDialog��$��0��$��4��$��Stretch=�$��Stretch=�