   M S B A M L   `   `   `  ����C  ?StarNote, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:StarNote.ViewStarNote.View  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      $    StarNote.View.ReportSettingsUC   5      %localclr-namespace:StarNote.View  5      a ]DevExpress.Xpf.Core.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5      a ]DevExpress.Xpf.Grid.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af	 bDevExpress.Xpf.Grid.v18.1.Core, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid  	 5	      Gdxgt<http://schemas.devexpress.com/winfx/2008/xaml/grid/themekeys  5
      Fdxt<http://schemas.devexpress.com/winfx/2008/xaml/core/themekeys  5      Fdxcn;http://schemas.devexpress.com/winfx/2008/xaml/core/internal  5      0sys&clr-namespace:System;assembly=mscorlib  5      <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5      -   5        $��0q�5      $��0q�6*     � 	Resources  5       �� Source�� 5   
   $8 2/StarNote;component/Resources/ButtonResources.xaml?�6   %    5      .��5      &   DevExpress.Xpf.Core.DXTabControl  -   5          Name$ 
tabcontrol��5      ���	#DDFAFAFA�  �DevExpress.Xpf.Core.Native.SelectorBase`2[[DevExpress.Xpf.Core.DXTabControl, DevExpress.Xpf.Core.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a],[DevExpress.Xpf.Core.DXTabItem, DevExpress.Xpf.Core.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a]]   SelectedIndex$ 0��6A      View 5   
   1  +DevExpress.Xpf.Core.TabControlMultiLineView  5      ,  &DevExpress.Xpf.Core.TabControlViewBase   HeaderLocation$
 None=�6)   .@�5   
   #  DevExpress.Xpf.Core.DXTabItem  -   5          Name$ tabtakip��5   >   ���	#DDFAFAFA�  �DevExpress.Xpf.Core.Native.HeaderedSelectorItemBase`2[[DevExpress.Xpf.Core.DXTabControl, DevExpress.Xpf.Core.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a],[DevExpress.Xpf.Core.DXTabItem, DevExpress.Xpf.Core.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a]]   Header$ takip��6/   .��5      � ���	#DDFAFAFA$��Stretch=�6+   $��Stretch=�6G    � RowDefinitions 5      �� 5       $��40 �6$   �� 5!      $��* �6$   .+�5#      � $��0��6   	 � ColumnDefinitions	 5$      �� 5%      $	��300 �6+   �� 5&      $��* �6+   �� 5'      $	��140 �6+   �� 5(      $	��140 �6+   .+�5*      �� 
������ 
������ $��Rapor Ayarları��6Q   $��Center=�6h   $��18(�6�   $��Times New Roman)�6�   �� 5+      -   5        
 ��Name$
 buttonyenikayıt��5+   �      btnyenikayıt#��[  6   $��Right=�6D   $��3��6`   $��0,0,10,0q�6p   $��25��6�   $	��120��6�   6�   5,      %  DevExpress.Xpf.Grid.GridControl  5-      -   5          Name$ 	gridhedef��5-   "   $��1��66   $
��2000��6�   $
��2000��6�   $��Stretch=�6�   $��Stretch=�6�   $��0,0,0,0q�6�   ) 	 #DevExpress.Xpf.Grid.DataControlBase   ItemsSource 6E   �� *List+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�   View 5.      #	  DevExpress.Xpf.Grid.TableView	  5/      -   5         	 Name$ 	tableAcik��5/   (    	  AllowPerPixelScrolling .  	  BestFitMode$ AllRows=�6�    	  	AutoWidth . &
 	  DevExpress.Xpf.Grid.DataViewBase 
  ShowSearchPanelMode$ Never=�6�    
  AllowEditing .  &   DevExpress.Xpf.Grid.GridViewBase   ShowGroupPanel .   
  ShowTotalSummary .   
  RowCellMenuCustomizations 50      '  !DevExpress.Xpf.Bars.BarButtonItem  51   "   -   5          Name$ btnsil��51   4   !  DevExpress.Xpf.Bars.BarItem   Content)  #DevExpress.Xpf.Core.ObjectConverter$ Ayarı Sil     6D   6]   53         Columns 55      $  DevExpress.Xpf.Grid.GridColumn  56      $ 	 DevExpress.Xpf.Grid.BaseColumn   Header$ ID 6)      Width2 	 ,DevExpress.Xpf.Grid.GridColumnWidthConverter$ 80 6Y   $ 	 DevExpress.Xpf.Grid.ColumnBase   	FieldName$ ID��6f      ReadOnly .     Binding  6:   �� ! �� Path$! Id�"   EditSettings" 57      6  0DevExpress.Xpf.Editors.Settings.TextEditSettings  58   "   6  0DevExpress.Xpf.Editors.Settings.BaseEditSettings!#   HorizontalContentAlignment$
# Left=�67   5:        5;      $ Ayar Numarası 6)     6@   �� $! ConcurrencyStamp�" 5<        5=   "   $
# Left=�67   5?        5@      $ 
Rapor Adı 6)     6<   �� $! 
Reportname�" 5A        5B   "   $
# Left=�67   5D        5E      $ Rapor No 6)     6;   �� $! Reportid�" 5F        5G   "   $
# Left=�67   5I        5J      $ Rapor Türü 6)     6=   �� $! Reporttypename�" 5K        5L   "   $
# Left=�67   5N        5O      $ En Son Gönderilme Tarihi 6)     6K   �� $! Lastsendtime�" 5P        5Q   "   $
# Left=�67   5S        5T      $' !Mail Gönderilecek Kullanıcılar 6)     6Q   �� $! 	Mailusers�" 5U        5V   "   $
# Left=�67   5X      5[      5\      5]        5^   
   -   5        $ tabgüncelleme��5^   *   $ 	güncelle��6   .��5_      �� $	��-12q�6   ���	#FE9590AD$
��Auto=�6C   $
��Auto=�6f     5`      $ �� 
TargetType% �� Property& �� Value' �� Triggers( P� Property) P� Value��%�  '��       �� 5a      "$ ��67   .�5b      �� % �@��IsFlicksEnabled& . 6C   ' 5c      P� 5d      ( �@��Orientation$) 
Horizontal=�6=   . �5e   "   �� % � ��$& 7��6;   �� 5f   "   % � ��$& 7��6>   5g      P� 5h      ( �@��Orientation$) Vertical=�6=   . �5i   "   �� % � ��$& 12��6:   �� 5j   "   % � ��$& 12��6=   5k      5m      5n      .��5o      � $��Stretch=�6   $��Stretch=�65   	 5p      �� 5q      $��20 �6+   �� 5r      $��* �6+   �� 5s      $��20 �6+    5u      �� 5v      $��40 �6(   �� 5w      $��* �6(   .+�5y      � $��0��6   $��1��6(   	 5z      �� 5{      $	��300 �60   �� 5|      $��* �6/   �� 5}      $	��300 �6/   .+�5      �� -	   5        * ��Name$* kayıtekrantext��5   "   
������ 
������ $!��Rapor Ayarları > Güncelle��6m   $��Center=�6�   $��18(�6�   $��Times New Roman)�6�   5�      � 5�      $��1��6   $��1��6(    5�      �� 5�      $	��300 �6,   �� 5�      $��30 �6,   �� 5�      $��50 �6,   �� 5�      $��30 �6,   .+�5�      �� ���	#FFFAFAFA$��0��68   + �� CornerRadius$+ 19��6G   , �� Padding$, 0q�6Y   ._�5�      � 	 5�   "   �� 5�   &    5�   "   �� 5�   &   $��47 �64   �� 5�   &   $��53 �64   �� 5�   &   $��47 �64   �� 5�   &   $��53 �64   �� 5�   &   $��47 �64   �� 5�   &   $��* �65   .+�5�   "   �� $	��Top=�6(   $��
10,0,10,10q�6@   $��13(�6T   $
��Bold"�6b   $
��Left=�6t   $��0��6�   $��0��6�   .��6�   Rapor Ayar Bilgileri6�   �� 5�   "   $��0��6,   $��4��6<   $��0��6P   $��
5,25,10,10q�6]   6t   �� 5�   "   $��Bottom=�6)   $��
10,0,10,-4q�6D   $��11(�6X   $
��left=�6g   $��0��6�   $��0��6�   .��6�   Rapor Seçimi6�   �� 5�   "   $��0��6*   $��1��6:   
�������$��10,10,10,11q�6Z   
���   �$��1q�6�   $+ 7��6�   $, 5q�6�   ._�5�   &   )  #DevExpress.Xpf.Editors.ComboBoxEdit  '  !DevExpress.Xpf.Editors.ButtonEdit-   IsTextEditable$- falseX�5�   )   %  DevExpress.Xpf.Editors.BaseEdit.   
ShowBorder. .  $��0q�5�   +   +  %DevExpress.Xpf.Editors.LookUpEditBase/   DisplayMember$
/ Name��5�   +   0   ValueMember$	0 Key��5�   +   1   ItemsSource1 5�   +   �� $! 
Reportlist�$ OneTime=�2   	EditValue2 5�   +   �� $! Currentdata.Reportid�$ TwoWay=�5�   '   5�   #   �� 5�   "   $��Bottom=�6)   $��
10,0,10,-4q�6D   $��11(�6X   $
��left=�6g   $��0��6�   $��2��6�   .��6�   Rapor Periyot Seçimi6�   �� 5�   "   $��0��6*   $��3��6:   
�������$��10,10,10,11q�6Z   
���   �$��1q�6�   $+ 7��6�   $, 5q�6�   ._�5�   &     . .  $- falseX�5�   +   $��0q�5�   +   $
/ Name��5�   +   $	0 Key��5�   +   2 5�   +   �� $! Currentdata.Reporttype�$ TwoWay=�1 5�   +   �� $! Reporttypelist�$ OneTime=�5�   '   5�   #   �� 5�   "   $��Bottom=�6)   $��
10,0,10,-4q�6D   $��11(�6X   $
��left=�6g   $��0��6�   $��4��6�   .��6�   #!Mail Gönderilecek Kullanıcılar6�   �� 5�   "   $��0��6*   $��5��6:   
�������$��10,10,10,11q�6Z   
���   �$��1q�6�   $+ 7��6�   $, 5q�6�   ._�5�   &   %  DevExpress.Xpf.Editors.TextEdit  . .  3   NullText$-3 'Aralarına virgül bırakarak yazınız��6I   )  #DevExpress.Xpf.Editors.TextEditBase4   Text4 6x   �� $! Currentdata.Mailusers�6�   5�   #   5�      5�      �� 5�      ���	#FFFAFAFA$��2��69   $��1��6F   $+ 19��6V   $, 0q�6h   ._�5�      � 	 5�   "   �� 5�   &   �� 5�   &   �� 5�   &   �� 5�   &   .+�5�   "   &   DevExpress.Xpf.Core.SimpleButton  -
   5        5  Name$5 	btnkayıt��5�   V     btnsave#��[ 62   $��3��6h   $��25��6x   $	��120��6�   $��Right=�6�   $��0,0,10,0q�6�   6�     5�   "   -   5        $5 btngüncelle��5�   V     	btnupdate#��[ 62   $��3��6k   $��25��6{   $	��120��6�   $��Right=�6�   $��0,0,10,0q�6�   6�     5�   "   -   5        $5 buttonvazgec��5�   V     	btngoback#��[ 62   $��	10,0,10,0q�6�   $��0��6�   $
��Left=�6�   $��25��6�   $	��120��6�   6�   5�      5�      5�      5�      5�      5�      5�      5�      