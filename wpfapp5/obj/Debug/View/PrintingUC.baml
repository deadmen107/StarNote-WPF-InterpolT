   M S B A M L   `   `   `  ����C  ?StarNote, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:StarNote.ViewStarNote.View  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5          StarNote.View.PrintingUC   5      %localclr-namespace:StarNote.View  5      a ]DevExpress.Xpf.Core.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5      a ]DevExpress.Xpf.Grid.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af	 bDevExpress.Xpf.Grid.v18.1.Core, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid  	 5	      Gdxgt<http://schemas.devexpress.com/winfx/2008/xaml/grid/themekeys  5
      Fdxt<http://schemas.devexpress.com/winfx/2008/xaml/core/themekeys  5      Fdxcn;http://schemas.devexpress.com/winfx/2008/xaml/core/internal  5      0sys&clr-namespace:System;assembly=mscorlib  5      -   5        $��0q�5      $��0q�6*   ���	#FE9590AD  � 	Resources  5       �� Source�� 5   
   $8 2/StarNote;component/Resources/ButtonResources.xaml?�6   %    5      .��5      &   DevExpress.Xpf.Core.DXTabControl  -   5          Name$ 
tabcontrol��5      ���	#DDFAFAFA�  �DevExpress.Xpf.Core.Native.SelectorBase`2[[DevExpress.Xpf.Core.DXTabControl, DevExpress.Xpf.Core.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a],[DevExpress.Xpf.Core.DXTabItem, DevExpress.Xpf.Core.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a]]   SelectedIndex$ 0��6A      View 5   
   1  +DevExpress.Xpf.Core.TabControlMultiLineView  5      ,  &DevExpress.Xpf.Core.TabControlViewBase   HeaderLocation$
 None=�6)   .@�5   
   #  DevExpress.Xpf.Core.DXTabItem  -   5          Name$ tabtakip��5   '   �  �DevExpress.Xpf.Core.Native.HeaderedSelectorItemBase`2[[DevExpress.Xpf.Core.DXTabControl, DevExpress.Xpf.Core.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a],[DevExpress.Xpf.Core.DXTabItem, DevExpress.Xpf.Core.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a]]   Header$ takip��6   .��5      � ���	#DDFAFAFA$��Stretch=�6+   $��Stretch=�6G    � RowDefinitions 5       �� 5!      $��40 �6$   �� 5"      $��* �6$   .+�5$      � $��0��6   	 � ColumnDefinitions	 5%      �� 5&      $	��300 �6+   �� 5'      $��* �6+   �� 5(      $	��300 �6+   .+�5*      �� 
������ 
������ $��Dosya Kayıt ��6Q   $��Center=�6f   $��18(�6�   $��Times New Roman)�6�   5+      %  DevExpress.Xpf.Grid.GridControl  5,      -   5        
  Name$
 	gridhedef��5,   "   $��1��66   $
��2000��6s   $
��2000��6�   $��Stretch=�6�   $��Stretch=�6�   $��0,0,0,0q�6�   ) 	 #DevExpress.Xpf.Grid.DataControlBase   ItemsSource 6E   �� *	Printlist+ �� Mode$ TwoWay=�   View 5.      #	  DevExpress.Xpf.Grid.TableView	  5/      -   5         	 Name$ 	tableAcik��5/        	  AllowPerPixelScrolling .  	  BestFitMode$ AllRows=�6}    	  	AutoWidth . &
 	  DevExpress.Xpf.Grid.DataViewBase 
  ShowSearchPanelMode$ Never=�6�    
  AllowEditing .  &   DevExpress.Xpf.Grid.GridViewBase   ShowGroupPanel .   
  ShowTotalSummary . 6�      Columns 52      $  DevExpress.Xpf.Grid.GridColumn  54      $ 	 DevExpress.Xpf.Grid.BaseColumn   Header)  #DevExpress.Xpf.Core.ObjectConverter$ ID 6!      Width2 	 ,DevExpress.Xpf.Grid.GridColumnWidthConverter$ 80 6Q   $ 	 DevExpress.Xpf.Grid.ColumnBase   	FieldName$ ID��6^      ReadOnly .    Binding 62   ��  �� Path$ Id�   EditSettings 55      6  0DevExpress.Xpf.Editors.Settings.TextEditSettings  56      6  0DevExpress.Xpf.Editors.Settings.BaseEditSettings!   HorizontalContentAlignment$
 Left=�6/   58        59      $ 
Rapor Adı 6!   $ HA��6T    64   �� $ Rapor� 5:        5;      $
 Left=�6/   5=        5>      $ 
Dosya Yolu 6!   $ HM��6\    67   �� $ 	Dosyayolu� 5?        5@      $
 Left=�6/   5B      5D      5E      5F        5G   
   -   5        $ tabgüncelleme��5G   )   $ 	güncelle��6   .��5I      �� $	��-12q�6   ���	#FE9590AD$
��Auto=�6C   $
��Auto=�6f     5J       �� 
TargetType  �� Property! �� Value" �� Triggers# P� Property$ P� Value��%�  '��       �� 5K      " ��67   .�5L      ��   �@��IsFlicksEnabled! . 6C   " 5M      P� 5N      # �@��Orientation$$ 
Horizontal=�6=   . �5O   "   ��   � ��$! 7��6;   �� 5P   "     � ��$! 7��6>   5Q      P� 5R      # �@��Orientation$$ Vertical=�6=   . �5S   "   ��   � ��$! 12��6:   �� 5T   "     � ��$! 12��6=   5U      5W      5X      .��5Y      � $��Stretch=�6   $��Stretch=�65   	 5Z      �� 5[      $��20 �6+   �� 5\      $��* �6+   �� 5]      $��20 �6+    5_      �� 5`      $��40 �6(   �� 5a      $��* �6(   .+�5c      � $��0��6   $��1��6(   	 5d      �� 5e      $	��300 �60   �� 5f      $��* �6/   �� 5g      $	��300 �6/   .+�5i      �� -   5        % ��Name$% kayıtekrantext��5i   "   
������ 
������ $��Dosya Kayıt > Güncelle��6m   $��Center=�6�   $��18(�6�   $��Times New Roman)�6�   5j      � 5k      $��1��6   $��1��6(    5l      �� 5m      $	��100 �6,   �� 5n      $��30 �6,   �� 5o      $	��100 �6,   �� 5p      $��30 �6,   �� 5q      $��30 �6,   .+�5s      �� ���	#FFFAFAFA$��0��68   & �� CornerRadius$& 19��6G   ' �� Padding$' 0q�6Y   ._�5t      � 	 5u   "   �� 5v   &   �� 5w   &    5z   "   �� 5{   &   $��47 �64   �� 5|   &   $��* �65   .+�5~   "   �� $	��Top=�6(   $��
10,0,10,10q�6@   $��13(�6T   $
��Bold"�6b   $
��Left=�6t   $��0��6�   $��0��6�   .��6�   Müşteri Bilgileri6�   �� 5   "   $��0��6,   $��4��6<   $��0��6P   $��
5,25,10,10q�6]   6t   �� 5�   "   $��Bottom=�6(   $��
10,0,10,-4q�6C   $��11(�6W   $
��left=�6f   $��0��6�   $��0��6�   .��6�   Dosya Adı:6�   �� 5�   "   $��Bottom=�6(   $��
10,0,10,-4q�6C   $��11(�6W   $
��left=�6f   $��1��6�   $��0��6�   .��6�   Dosya Yolu:6�   �� 5�   "   $��0��6*   $��1��6:   
�������$��10,10,10,11q�6Z   
���   �$��1q�6�   $& 7��6�   $' 5q�6�   ._�5�   &   %  DevExpress.Xpf.Editors.TextEdit  -   5        $��txtisim��5�   3   %  DevExpress.Xpf.Editors.BaseEdit(   
ShowBorder( .  )   
IsReadOnly) . *   NullText$* 
Rapor Adı��6i   )  #DevExpress.Xpf.Editors.TextEditBase+   Text+ 6   �� $ Currentdata.Rapor�6�   5�   #   �� 5�   "   $��1��6*   $��1��6:   
�������$��10,10,10,11q�6Z   
���   �$��1q�6�   $& 7��6�   $' 5q�6�   ._�5�   &     -	   5        $��	dosyayolu��5�   3   ( .  $* 
Dosya Yolu��6X   + 6n   �� $ Currentdata.Dosyayolu�6�   5�   #   5�      5�      �� 5�      ���	#FFFAFAFA$��2��69   $��1��6F   $& 19��6V   $' 0q�6h   ._�5�      � 	 5�   "   �� 5�   &   $	��140 �67   �� 5�   &   $��* �67   �� 5�   &   $	��140 �67   �� 5�   &   $	��140 �67   .+�5�   "   &   DevExpress.Xpf.Core.SimpleButton  -
   5        ,  Name$, btngüncelle��5�   V      	btnupdate#��[  62   $��3��6k   $��25��6{   $	��120��6�   $
��Left=�6�   $��0,0,0,0q�6�   6�     5�   "   -   5        $, buttonvazgec��5�   V     	btngoback#��[ 62   $��	10,0,10,0q�6�   $��0��6�   $
��Left=�6�   $��25��6�   $	��120��6�   6�   �� 5�   "   -   5        - ��Name$- dosyayolusec��5�   S     FlatButtonStyle#��[ 6)   $��0,0,10,0q�6�   $��2��6�   $��1��6�   $��Right=�6�   $��Center=�6�   $��25��6�   $	��120��6�   .��6  Yeni Dizin Seç6  5�      5�      5�      5�      5�      5�      5�      5�      