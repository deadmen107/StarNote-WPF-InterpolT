   M S B A M L   `   `   `  ����C  ?StarNote, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:StarNote.ViewStarNote.View  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5          StarNote.View.PasswordUC   5      %localclr-namespace:StarNote.View  5      a ]DevExpress.Xpf.Core.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5      a ]DevExpress.Xpf.Grid.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af	 bDevExpress.Xpf.Grid.v18.1.Core, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid  	 5	      Gdxgt<http://schemas.devexpress.com/winfx/2008/xaml/grid/themekeys  5
      Fdxt<http://schemas.devexpress.com/winfx/2008/xaml/core/themekeys  5      Fdxcn;http://schemas.devexpress.com/winfx/2008/xaml/core/internal  5      0sys&clr-namespace:System;assembly=mscorlib  5      $��0q�5      $��0q�6*   ���	#FFEEEEEE  � 	Resources  5       �� Source�� 5   
   $8 2/StarNote;component/Resources/ButtonResources.xaml?�6   %    5      .��5      &   DevExpress.Xpf.Core.DXTabControl  -   5          Name$ 
tabcontrol��5      �  �DevExpress.Xpf.Core.Native.SelectorBase`2[[DevExpress.Xpf.Core.DXTabControl, DevExpress.Xpf.Core.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a],[DevExpress.Xpf.Core.DXTabItem, DevExpress.Xpf.Core.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a]]   SelectedIndex$ 0��6*      View 5   
   1  +DevExpress.Xpf.Core.TabControlMultiLineView  5      ,  &DevExpress.Xpf.Core.TabControlViewBase   HeaderLocation$
 None=�6)   .@�5   
   #  DevExpress.Xpf.Core.DXTabItem  -   5          Name$ tabgüncelleme��5   *   �  �DevExpress.Xpf.Core.Native.HeaderedSelectorItemBase`2[[DevExpress.Xpf.Core.DXTabControl, DevExpress.Xpf.Core.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a],[DevExpress.Xpf.Core.DXTabItem, DevExpress.Xpf.Core.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a]]   Header$ 	güncelle��6   .��5!      �� $	��-12q�6   ���	#FE9590AD$
��Auto=�6C   $
��Auto=�6f     5"       �� 
TargetType	 �� Property
 �� Value �� Triggers P� Property P� Value��%�  '��       �� 5#      " ��67   .�5$      �� 	 �@��IsFlicksEnabled
 . 6C    5%      P� 5&       �@��Orientation$ 
Horizontal=�6=   . �5'   "   �� 	 � ��$
 7��6;   �� 5(   "   	 � ��$
 7��6>   5)      P� 5*       �@��Orientation$ Vertical=�6=   . �5+   "   �� 	 � ��$
 12��6:   �� 5,   "   	 � ��$
 12��6=   5-      5/      50      .��51      � $��Stretch=�6   $��Stretch=�65    � ColumnDefinitions 52      �� 53      $��20 �6+   �� 54      $��* �6+   �� 55      $��20 �6+    � RowDefinitions 57      �� 58      $��40 �6(   �� 59      $��* �6(   .+�5;      � $��0��6   $��1��6(    5<      �� 5=      $	��300 �60   �� 5>      $��* �6/   �� 5?      $	��300 �6/   .+�5A      �� -   5         ��Name$ kayıtekrantext��5A   "   
������ 
������ $��Parola Güncelleme��6m   $��Center=�6�   $��18(�6�   $��Times New Roman)�6�   5B      � 5C      $��1��6   $��1��6(    5D      �� 5E      $	��100 �6,   �� 5F      $��30 �6,   �� 5G      $	��100 �6,   �� 5H      $��30 �6,   �� 5I      $��50 �6,   �� 5J      $��30 �6,   .+�5L      �� ���	#FFFAFAFA$��0��68    �� CornerRadius$ 19��6G    �� Padding$ 0q�6Y   ._�5M      �  5N   "   �� 5O   &   �� 5P   &   $	��140 �67    5R   "   �� 5S   &   $��47 �64   �� 5T   &   $��* �65   .+�5V   "   �� $	��Top=�6(   $��
10,0,10,10q�6@   $��13(�6T   $
��Bold"�6b   $
��Left=�6t   $��0��6�   $��0��6�   .��6�   Hedef Bilgileri6�   �� 5W   "   $��0��6,   $��4��6<   $��0��6P   $��
5,25,10,10q�6]   6t   �� 5X   "   $��Bottom=�6)   $��
10,0,10,-4q�6D   $��11(�6X   $
��left=�6g   $��0��6�   $��0��6�   .��6�   Güncel Parola6�   �� 5Y   "   $��0��6*   $��1��6:   
�������$��10,10,10,11q�6Z   
���   �$��1q�6�   $ 7��6�   $ 5q�6�   ._�5Z   &   ,  &DevExpress.Xpf.Editors.PasswordBoxEdit  -   5        $��txtgüncelparola��5Z   :   %  DevExpress.Xpf.Editors.BaseEdit   
ShowBorder .     NullText$ Güncel Parola��6g   6�   5[   #   &	   DevExpress.Xpf.Core.SimpleButton	  5\   "   -   5         	 Name$ btnsifredegistir��5\   [      FlatButtonStyle#��[  62   $��1��6u   $��1��6�   $
��Left=�6�   $��25��6�   $	��120��6�   .��6�   
Değiştir6�   5]      5^      �� 5_      ���	#FFFAFAFA$��2��68   $ 19��6G   $ 0q�6Y   ._�5`      �  5a   "   �� 5b   &   �� 5c   &    5e   "   �� 5f   &   $��47 �64   �� 5g   &   $��* �65   .+�5i   "   �� $	��Top=�6(   $��
10,0,10,10q�6@   $��13(�6T   $
��Bold"�6b   $
��Left=�6t   $��0��6�   $��0��6�   .��6�   Yeni Parola6�   �� 5j   "   $��0��6,   $��4��6<   $��0��6P   $��
5,25,10,10q�6]   6t   �� 5k   "   $��Bottom=�6)   $��
10,0,10,-4q�6D   $��11(�6X   $
��left=�6g   $��0��6�   $��0��6�   .��6�   Yeni Parola6�   �� 5l   "   $��Bottom=�6(   $��
10,0,10,-4q�6C   $��11(�6W   $
��left=�6f   $��1��6�   $��0��6�   .��6�   Yeni Parola Yeniden6�   �� 5m   "   $��0��6*   $��1��6:   
�������$��10,10,10,11q�6Z   
���   �$��1q�6�   $ 7��6�   $ 5q�6�   ._�5n   &     -   5        $��txtyeniparola��5n   :    .  $ Yeni Parola��6e   6   5o   #   �� 5p   "   $��1��6*   $��1��6:   
�������$��10,10,10,11q�6Z   
���   �$��1q�6�   $ 7��6�   $ 5q�6�   ._�5q   &     -   5        $��txtyeniparolayeniden��5q   :    .  $ Yeni Parola Yeniden��6j   6�   5r   #   5s      5t      �� 5u      ���	#FFFAFAFA$��4��69   $��1��6F   $ 19��6V   $ 0q�6h   ._�5v      �  5w   "   �� 5x   &   �� 5y   &   �� 5z   &   �� 5{   &   .+�5}   "   	  -   5        $ btngüncelle��5}   [   #��[  62   $��3��6p   $��25��6�   $	��120��6�   $��Right=�6�   $��0,0,10,0q�6�   .��6�   	Güncelle6�   5~      5      5�      5�      5�      5�      5�      5�      