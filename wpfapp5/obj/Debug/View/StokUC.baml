   M S B A M L   `   `   `  ����C  ?StarNote, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:StarNote.ViewStarNote.View  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5          StarNote.View.StokUC   5      %localclr-namespace:StarNote.View  5      a ]DevExpress.Xpf.Core.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5      a ]DevExpress.Xpf.Grid.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af	 bDevExpress.Xpf.Grid.v18.1.Core, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid  	 5	      Gdxgt<http://schemas.devexpress.com/winfx/2008/xaml/grid/themekeys  5
      0sys&clr-namespace:System;assembly=mscorlib  5      c
 _DevExpress.Xpf.Gauges.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dxga4http://schemas.devexpress.com/winfx/2008/xaml/gauges 
 5      <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5      -   5        $��0q�5      $��0q�6*   ���	#FE9590AD  � 	Resources  5       �� Source�� 5   
   $8 2/StarNote;component/Resources/ButtonResources.xaml?�6   %    5      .��5      &   DevExpress.Xpf.Core.DXTabControl  -   5          Name$ 
tabcontrol��5      ���	#DDFAFAFA�  �DevExpress.Xpf.Core.Native.SelectorBase`2[[DevExpress.Xpf.Core.DXTabControl, DevExpress.Xpf.Core.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a],[DevExpress.Xpf.Core.DXTabItem, DevExpress.Xpf.Core.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a]]   SelectedIndex$ 0��6A      View 5   
   1  +DevExpress.Xpf.Core.TabControlMultiLineView  5      ,  &DevExpress.Xpf.Core.TabControlViewBase   HeaderLocation$
 None=�6)   .@�5   
   #  DevExpress.Xpf.Core.DXTabItem  -   5          Name$ tabtakip��5   (   �  �DevExpress.Xpf.Core.Native.HeaderedSelectorItemBase`2[[DevExpress.Xpf.Core.DXTabControl, DevExpress.Xpf.Core.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a],[DevExpress.Xpf.Core.DXTabItem, DevExpress.Xpf.Core.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a]]   Header$ takip��6   .��5      � ���	#DDFAFAFA$��Stretch=�6+   $��Stretch=�6G    � ColumnDefinitions 5       �� 5!      $��20 �6'   �� 5"      $��* �6'   �� 5#      $��20 �6'   	 � RowDefinitions	 5%      �� 5&      $��40 �6$   �� 5'      $��* �6$   .+�5)      � $��0��6   $��1��6$    5*      �� 5+      $	��300 �6+   �� 5,      $��* �6+   �� 5-      $	��140 �6+   �� 5.      $	��140 �6+   .+�50      �� 
������ 
������ $��DİLLER��6Q   $��Center=�6`   $��18(�6{   $��Times New Roman)�6�   �� 51      -   5        
 ��Name$
 buttonyenikayıt��51   �      btnyenikayıt#��[  6   $��Right=�6D   $��3��6`   $��0,0,10,0q�6p   $��25��6�   $	��120��6�   6�   �� 52      -   5        $
 buttonoutput��52   C     btnsettings#��[ 6   $��2��6Y   $	��140��6j   $��25��6v   $  DevExpress.Xpf.Bars.BarManager   MenuShowMouseButton$ 
LeftButton=�6�      DXContextMenu 53      #  DevExpress.Xpf.Bars.PopupMenu  54      $	��150��6,      Items 55   "   '	  !DevExpress.Xpf.Bars.BarButtonItem	  56   &   -   5         	 Name$ btnpdf��57   )   !
  DevExpress.Xpf.Bars.BarItem 
  Content)  #DevExpress.Xpf.Core.ObjectConverter$ 
PDF ÇIKTI 58   !    
  Glyph$ /Content/pdf.png��59   !   5:   !   	  5;   &   -   5        $ btnxcel��5<   !   $ Excel ÇIKTI 5=   !   $ /Content/excel.png��5>   !   5?   !   	  5@   &   -   5        $ btnayar��5A   !   $ Görünümü Kaydet 5B   !   $  /Content/settings mini.png��5C   !   5D   !   5G      5J      5K      %  DevExpress.Xpf.Grid.GridControl  5L      -	   5          Name$ gridstok��5L   "   $��1��65   $��1��6B   $
��2000��6�   $
��2000��6�   $��Stretch=�6�   $��Stretch=�6�   $��0,0,0,0q�6  ) 	 #DevExpress.Xpf.Grid.DataControlBase   ItemsSource 6R   ��  �� Path$ Stoklist� �� Mode$ TwoWay=�   View 5N      #  DevExpress.Xpf.Grid.TableView  5O      -
   5          Name$ 	tablestok��5O   (      AllowPerPixelScrolling .    BestFitMode$ AllRows=�6[      	AutoWidth . & 	  DevExpress.Xpf.Grid.DataViewBase   ShowSearchPanelMode$ Always=�6�      AllowEditing .  &   DevExpress.Xpf.Grid.GridViewBase   ShowGroupPanel .     ShowTotalSummary . 6�      Columns 5R      $  DevExpress.Xpf.Grid.GridColumn  5S      -   5          Name$ ID��5S   )   $ 	 DevExpress.Xpf.Grid.BaseColumn    Header$  ID 65   !   Width2 	 ,DevExpress.Xpf.Grid.GridColumnWidthConverter$! 50 6H   $ 	 DevExpress.Xpf.Grid.ColumnBase"   	FieldName$" ID��6V   #   Binding# 6x   �� $ Id�  5T      -   5        $ Stokkod��5T   )   $  	DİL KODU 6:   $
! auto 6W   $" SK��6e   # 6�   �� $ Stokkod�  5U      -   5        $ Stokadı��5U   )   $  DİL ADI 6:   $
! auto 6W   $" SA��6e   # 6�   �� $ Stokadı�  5V      -   5        $ Miktar��5V   )   $  MİKTAR 69   $
! auto 6W   $" SM��6e   # 6�   �� $ Miktar�  5W      -   5        $ Birim��5W   )   $  BİRİM 68   $
! auto 6V   $" SB��6d   # 6�   �� $ Birim�  5X      -   5        $ Alışfiyat��5X   )   $  ALIŞ FİYATI 6<   $
! auto 6Z   $	" SAL��6h   # 6�   �� $ Alışfiyat�  5Y      -   5        $ Satışfiyat��5Y   )   $  SATIŞ FİYATI 6=   $
! auto 6[   $	" SSA��6i   # 6�   �� $ Satışfiyat�  5Z      -   5        $	 Kdv��5Z   )   $	  KDV 66   $
! auto 6T   $
" SKDV��6b   # 6�   �� $	 Kdv�  5[      -   5        $ İskonto��5[   )   $  İSKONTO 6:   $
! auto 6X   $" SF��6f   # 6�   �� $ İskonto�5]      5^      5_        5`   
   -   5        $ tabgüncelleme��5`   )   $ 	güncelle��6   .��5b      �� $	��-12q�6   ���	#FE9590AD$
��Auto=�6C   $
��Auto=�6f     5c      $ �� 
TargetType% �� Property& �� Value' �� Triggers( P� Property) P� Value��%�  '��       �� 5d      "$ ��67   .�5e      �� % �@��IsFlicksEnabled& . 6C   ' 5f      P� 5g      ( �@��Orientation$) 
Horizontal=�6=   . �5h   "   �� % � ��$& 7��6;   �� 5i   "   % � ��$& 7��6>   5j      P� 5k      ( �@��Orientation$) Vertical=�6=   . �5l   "   �� % � ��$& 12��6:   �� 5m   "   % � ��$& 12��6=   5n      5p      5q      .��5r      � $��Stretch=�6   $��Stretch=�65    5s      �� 5t      $��20 �6+   �� 5u      $��* �6+   �� 5v      $��20 �6+   	 5x      �� 5y      $��40 �6(   �� 5z      $��* �6(   .+�5|      � $��0��6   $��1��6(    5}      �� 5~      $	��300 �60   �� 5      $��* �6/   �� 5�      $	��300 �6/   .+�5�      �� -   5        * ��Name$* kayıtekrantext��5�   "   
������ 
������ $��Yeni Kayıt Ekleme��6m   $��Center=�6�   $��18(�6�   $��Times New Roman)�6�   5�      � 5�      $��1��6   $��1��6(   	 5�      �� 5�      $	��100 �6,   �� 5�      $��30 �6,   �� 5�      $	��200 �6,   �� 5�      $��30 �6,   �� 5�      $��50 �6,   �� 5�      $��30 �6,   .+�5�      �� ���	#FFFAFAFA$��0��68   + �� CornerRadius$+ 19��6G   , �� Padding$, 0q�6Y   ._�5�      �  5�   "   �� 5�   &   �� 5�   &   	 5�   "   �� 5�   &   $��47 �64   �� 5�   &   $��* �65   .+�5�   "   �� $	��Top=�6(   $��
10,0,10,10q�6@   $��13(�6T   $
��Bold"�6b   $
��Left=�6t   $��0��6�   $��0��6�   .��6�   Dil Tanım Bilgileri6�   �� 5�   "   $��0��6,   $��4��6<   $��0��6P   $��
5,25,10,10q�6]   6t   �� 5�   "   $��Bottom=�6(   $��
10,0,10,-4q�6C   $��11(�6W   $
��left=�6f   $��0��6�   $��0��6�   .��6�   	DİL KODU6�   �� 5�   "   $��Bottom=�6(   $��
10,0,10,-4q�6C   $��11(�6W   $
��left=�6f   $��1��6�   $��0��6�   .��6�   
DİL ADI6�   �� 5�   "   $��0��6*   $��1��6:   
�������$��10,10,10,11q�6Z   
���   �$��1q�6�   $+ 7��6�   $, 5q�6�   ._�5�   &   %  DevExpress.Xpf.Editors.TextEdit  -   5        $��
txtstokkod��5�   [   %  DevExpress.Xpf.Editors.BaseEdit-   NullText$- Dil Kodu��63   .   
ShowBorder. .  )  #DevExpress.Xpf.Editors.TextEditBase/   Text/ 6n   �� $ Currentdata.Stokkod�6�   5�   #   �� 5�   "   $��1��6*   $��1��6:   
�������$��10,10,10,11q�6Z   
���   �$��1q�6�   $+ 7��6�   $, 5q�6�   ._�5�   &     -   5        $��txtstokadı��5�   Y   $- Dil Adı��63   . .  / 6n   �� $ Currentdata.Stokadı�6�   5�   #   5�      5�      �� 5�      ���	#FFFAFAFA$��2��68   $+ 19��6E   $, 0q�6W   ._�5�      �  5�   "   �� 5�   &   �� 5�   &   	 5�   "   �� 5�   &   $��47 �64   �� 5�   &   $��53 �64   �� 5�   &   $��47 �64   �� 5�   &   $��* �65   .+�5�   "   �� $	��Top=�6(   $��
10,0,10,10q�6@   $��13(�6T   $
��Bold"�6b   $
��Left=�6t   $��0��6�   $��0��6�   .��6�   Dil Satış Bilgileri6�   �� 5�   "   $��0��6,   $��4��6<   $��0��6P   $��
5,25,10,10q�6]   6t   �� 5�   "   $��Bottom=�6(   $��10,10,10,-4q�6C   $��11(�6Y   $
��left=�6g   $��0��6�   $��0��6�   .��6�   ALIŞ FİYATI6�   �� 5�   "   $��Bottom=�6(   $��10,10,10,-4q�6C   $��11(�6Y   $
��left=�6g   $��1��6�   $��0��6�   .��6�   SATIŞ FİYATI6�   �� 5�   "   $��Bottom=�6(   $��10,10,10,-4q�6C   $��11(�6X   $
��left=�6g   $��0��6�   $��2��6�   .��6�   KDV6�   �� 5�   "   $��Bottom=�6(   $��10,10,10,-4q�6C   $��11(�6X   $
��left=�6h   $��1��6�   $��2��6�   .��6�   
İSKONTO6�   �� 5�   "   $��0��6*   $��1��6:   
�������$��10,10,10,11q�6Z   
���   �$��1q�6�   $+ 7��6�   $, 5q�6�   ._�5�   &     -   5        $��txtstokalısfiyat��5�   J   $- Alış Fiyatı��63   . .  / 6u   �� $ Currentdata.Alışfiyat�6�   5�   #   �� 5�   "   $��1��6*   $��1��6:   
�������$��10,10,10,11q�6Z   
���   �$��1q�6�   $+ 7��6�   $, 5q�6�   ._�5�   &     -   5        $��txtstoksatısfiyat��5�   K   $- Satış Fiyatı��63   . .  / 6w   �� $ Currentdata.Satışfiyat�6�   5�   #   �� 5�   "   $��0��6*   $��3��6:   
�������$��10,10,10,11q�6[   
���   �$��1q�6�   $+ 7��6�   $, 5q�6�   ._�5�   &   )  #DevExpress.Xpf.Editors.ComboBoxEdit  -   5        $��cmbkdv��5�   ]   $	- KDV��67   '  !DevExpress.Xpf.Editors.ButtonEdit0   IsTextEditable$0 FalseX�6F   . .  / 6�   �� $ Currentdata.Kdv�+  %DevExpress.Xpf.Editors.LookUpEditBase1   ItemsSource1 6�   �� $ Kdvsourcelist�6�   5�   #   �� 5�   "   $��1��6)   $��3��69   
�������$��10,10,10,11q�6Y   
���   �$��1q�6�   $+ 7��6�   $, 5q�6�   ._�5�   &     -   5        $��txtstokiskonto��5�   F   $- İskonto��63   . .  / 6r   �� $ Currentdata.İskonto�6�   5�   #   5�      5�      �� 5�      ���	#FFFAFAFA$��4��69   $+ 19��6G   $, 0q�6Y   ._�5�      �  5�   "   �� 5�   &   �� 5�   &   �� 5�   &   �� 5�   &   .+�5�   "   &   DevExpress.Xpf.Core.SimpleButton  -   5        2  Name$2 	btnkayıt��5�   v     btnsave#��[ 62   #��[ 6S   $��3��6�   $��25��6�   $	��120��6�   $��Right=�6�   $��0,0,10,0q�6�   6�     5�   "   -   5        $2 btngüncelle��5�   z     	btnupdate#��[ 62   #��[ 6U   $��3��6�   $��25��6�   $	��120��6�   $��Right=�6�   $��0,0,10,0q�6�   6    5�   "   -   5        $2 buttonvazgec��5�   z     	btngoback#��[ 62   #��[ 6U   $��	10,0,10,0q�6�   $��0��6�   $
��Left=�6�   $��25��6�   $	��120��6�   6  5�      5�      5�      5�      5�      5�      5�      5�      