   M S B A M L   `   `   `  ����C  ?StarNote, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:StarNote.ViewStarNote.View  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5          StarNote.View.CompanyUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:StarNote.View     5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5	      a ]DevExpress.Xpf.Grid.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af	 bDevExpress.Xpf.Grid.v18.1.Core, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid  	 5
      Gdxgt<http://schemas.devexpress.com/winfx/2008/xaml/grid/themekeys  5      Fdxt<http://schemas.devexpress.com/winfx/2008/xaml/core/themekeys  5      Fdxcn;http://schemas.devexpress.com/winfx/2008/xaml/core/internal  5      0sys&clr-namespace:System;assembly=mscorlib  5      <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5      ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      -   5        $��0q�5      $��0q�6*     � 	Resources  5       �� Source�� 5   
   $8 2/StarNote;component/Resources/ButtonResources.xaml?�6   %    5      .��5      &   DevExpress.Xpf.Core.DXTabControl  -   5          Name$ 
tabcontrol��5      ���	#DDFAFAFA�  �DevExpress.Xpf.Core.Native.SelectorBase`2[[DevExpress.Xpf.Core.DXTabControl, DevExpress.Xpf.Core.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a],[DevExpress.Xpf.Core.DXTabItem, DevExpress.Xpf.Core.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a]]   SelectedIndex$ 0��6A      View 5   
   1  +DevExpress.Xpf.Core.TabControlMultiLineView  5      ,  &DevExpress.Xpf.Core.TabControlViewBase   HeaderLocation$
 None=�6)   .@�5   
   #  DevExpress.Xpf.Core.DXTabItem  -   5          Name$ tabtakip��5   (   �  �DevExpress.Xpf.Core.Native.HeaderedSelectorItemBase`2[[DevExpress.Xpf.Core.DXTabControl, DevExpress.Xpf.Core.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a],[DevExpress.Xpf.Core.DXTabItem, DevExpress.Xpf.Core.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a]]   Header$ takip��6   .��5       � ���	#DDFAFAFA$��Stretch=�6+   $��Stretch=�6G    � RowDefinitions 5!      �� 5"      $��40 �6$   �� 5#      $��* �6$   .+�5%      � $��0��6   	 � ColumnDefinitions	 5&      �� 5'      $	��300 �6+   �� 5(      $��* �6+   �� 5)      $	��140 �6+   �� 5*      $	��140 �6+   .+�5,      �� 
������ 
������ $��ŞİRKETLER��6Q   $��Center=�6c   $��18(�6~   $��Times New Roman)�6�   �� 5-      -   5        
 ��Name$
 buttonyenikayıt��5-   �      btnyenikayıt#��[  6   $��Right=�6D   $��3��6`   $��0,0,10,0q�6p   $��25��6�   $	��120��6�   6�   �� 5.      -   5        $
 buttonoutput��5.   D     btnsettings#��[ 6   $��2��6Z   $	��140��6k   $��25��6w   $  DevExpress.Xpf.Bars.BarManager   MenuShowMouseButton$ 
LeftButton=�6�      DXContextMenu 5/      #  DevExpress.Xpf.Bars.PopupMenu  50         Items 51   "   '	  !DevExpress.Xpf.Bars.BarButtonItem	  52   &   -   5         	 Name$ btnpdf��53   )   !
  DevExpress.Xpf.Bars.BarItem 
  Content)  #DevExpress.Xpf.Core.ObjectConverter$ 
PDF ÇIKTI 54   !    
  Glyph$ /Content/pdf.png��55   !   56   !   	  57   &   -   5        $ btnxcel��58   !   $ Excel ÇIKTI 59   !   $ /Content/excel.png��5:   !   5;   !   5=      5@      5A      %  DevExpress.Xpf.Grid.GridControl  5B      -   5          Name$ 	gridhedef��5B   "   $��1��66   $
��2000��6u   $
��2000��6�   $��Stretch=�6�   $��Stretch=�6�   $��0,0,0,0q�6�   ) 	 #DevExpress.Xpf.Grid.DataControlBase   ItemsSource 6E   �� *Companylist+ �� Mode$ TwoWay=�   View 5C      #  DevExpress.Xpf.Grid.TableView  5D      -	   5          Name$ 	tableAcik��5D   (      AllowPerPixelScrolling .    BestFitMode$ AllRows=�6�      	AutoWidth . & 	  DevExpress.Xpf.Grid.DataViewBase   ShowSearchPanelMode$ Never=�6�      AllowEditing .  &   DevExpress.Xpf.Grid.GridViewBase   ShowGroupPanel .     ShowTotalSummary .     RowCellMenuCustomizations 5E      	  5F   "   -
   5        $ btnsil��5F   4   $ Firmayı Sil     6D   6_   5H         Columns 5J      $  DevExpress.Xpf.Grid.GridColumn  5K      $ 	 DevExpress.Xpf.Grid.BaseColumn   Header$ ID 6)       Width2 	 ,DevExpress.Xpf.Grid.GridColumnWidthConverter$  50 6G   $ 	 DevExpress.Xpf.Grid.ColumnBase!   	FieldName$! ID��6U   "   Binding" 6w   �� # �� Path$# Id�  5L      $ 
FİRMA ADI 6)   $
  auto 6G   $! CN��6U   " 6w   �� $# Companyname�  5M      $ FİRMA ADRESİ 6)   $
  auto 6K   $! CA��6Y   " 6w   �� $# Companyadress�  5N      $ 	VERGİ NO 6)   $
  auto 6I   $! TN��6W   " 6w   �� $# Taxno�  5O      $ VERGİ DAİRESİ 6)   $
  auto 6N   $! TNAME��6\   " 6w   �� $# Taxname�5Q      5R      5S        5U   
   -   5        $ tabgüncelleme��5U   *   $ 	güncelle��6   .��5V      �� $	��-12q�6   ���	#FE9590AD$
��Auto=�6C   $
��Auto=�6f     5W      $ �� 
TargetType% �� Property& �� Value' �� Triggers( P� Property) P� Value��%�  '��       �� 5X      "$ ��67   .�5Y      �� % �@��IsFlicksEnabled& . 6C   ' 5Z      P� 5[      ( �@��Orientation$) 
Horizontal=�6=   . �5\   "   �� % � ��$& 7��6;   �� 5]   "   % � ��$& 7��6>   5^      P� 5_      ( �@��Orientation$) Vertical=�6=   . �5`   "   �� % � ��$& 12��6:   �� 5a   "   % � ��$& 12��6=   5b      5d      5e      .��5f      � $��Stretch=�6   $��Stretch=�65   	 5g      �� 5h      $��20 �6+   �� 5i      $��* �6+   �� 5j      $��20 �6+    5l      �� 5m      $��40 �6(   �� 5n      $��* �6(   .+�5p      � $��0��6   $��1��6(   	 5q      �� 5r      $	��300 �60   �� 5s      $��* �6/   �� 5t      $	��300 �6/   .+�5v      �� -   5        * ��Name$* kayıtekrantext��5v   "   
������ 
������ $&�� Satış Görevlileri > Güncelle��6m   $��Center=�6�   $��18(�6�   $��Times New Roman)�6�   5y      � 5z      $��1��6   $��1��6(    5{      �� 5|      $	��100 �6,   �� 5}      $��30 �6,   �� 5~      $	��100 �6,   �� 5      $��30 �6,   �� 5�      $��50 �6,   .+�5�      �� ���	#FFFAFAFA$��0��68   + �� CornerRadius$+ 19��6G   , �� Padding$, 0q�6Y   ._�5�      � 	 5�   "   �� 5�   &   �� 5�   &    5�   "   �� 5�   &   $��47 �64   �� 5�   &   $��* �65   .+�5�   "   �� $	��Top=�6(   $��
10,0,10,10q�6@   $��13(�6T   $
��Bold"�6b   $
��Left=�6t   $��0��6�   $��0��6�   .��6�   Firma Bilgileri6�   �� 5�   "   $��0��6,   $��4��6<   $��0��6P   $��
5,25,10,10q�6]   6t   �� 5�   "   $��Bottom=�6(   $��
10,0,10,-4q�6C   $��11(�6W   $
��left=�6f   $��0��6�   $��0��6�   .��6�   FİRMA ADI *6�   �� 5�   "   $��Bottom=�6(   $��
10,0,10,-4q�6C   $��11(�6W   $
��left=�6f   $��1��6�   $��0��6�   .��6�   FİRMA ADRESİ6�   �� 5�   "   $��0��6*   $��1��6:   
�������$��10,10,10,11q�6Z   
���   �$��1q�6�   $+ 7��6�   $, 5q�6�   ._�5�   &   %  DevExpress.Xpf.Editors.TextEdit  -   5        $��
txtfirmaad��5�   \   %  DevExpress.Xpf.Editors.BaseEdit-   NullText$- 
Firma Adı��63   .   
ShowBorder. .  )  #DevExpress.Xpf.Editors.TextEditBase/   Text/ 6o   �� $# Currentdata.Companyname�6�   5�   #   �� 5�   "   $��1��6*   $��1��6:   
�������$��10,10,10,11q�6Z   
���   �$��1q�6�   $+ 7��6�   $, 5q�6�   ._�5�   &     -   5        $��txtfirmaadres��5�   ^   $- Firma Adresi��63   . .  / 6v   �� $# Currentdata.Companyadress�6�   5�   #   5�      5�      �� 5�      ���	#FFFAFAFA$��2��68   $+ 19��6F   $, 0q�6X   ._�5�      � 	 5�   "   �� 5�   &   �� 5�   &    5�   "   �� 5�   &   $��47 �64   �� 5�   &   $��* �65   .+�5�   "   �� $	��Top=�6(   $��
10,0,10,10q�6@   $��13(�6T   $
��Bold"�6b   $
��Left=�6t   $��0��6�   $��0��6�   .��6�   Cari Bilgiler6�   �� 5�   "   $��0��6,   $��4��6<   $��0��6P   $��
5,25,10,10q�6]   6t   �� 5�   "   $��Bottom=�6(   $��10,10,10,-4q�6C   $��11(�6X   $
��left=�6g   $��0��6�   $��0��6�   .��6�   
Vergi No6�   �� 5�   "   $��Bottom=�6(   $��10,10,10,-4q�6C   $��11(�6X   $
��left=�6g   $��1��6�   $��0��6�   .��6�   Vergi Dairesi6�   �� 5�   "   $��0��6+   $��1��6;   
�������$��10,10,10,11q�6\   
���   �$��1q�6�   $+ 7��6�   $, 5q�6�   ._�5�   &     -   5        $��txttaxno��5�   M   $- Vergi Numarası��63   . .  / 6q   �� $# Currentdata.Taxno�6�   5�   #   �� 5�   "   $��1��6,   $��1��6<   
�������$��10,10,10,11q�6]   
���   �$��1q�6�   $+ 7��6�   $, 5q�6�   ._�5�   &     -   5        $��
txttaxname��5�   M   $- Vergi Dairesi��63   . .  / 6z   �� $# Currentdata.Taxname�6�   5�   #   5�      5�      �� 5�      ���	#FFFAFAFA$��6��69   $+ 19��6G   $, 0q�6Y   ._�5�      � 	 5�   "   �� 5�   &   �� 5�   &   �� 5�   &   �� 5�   &   .+�5�   "   &   DevExpress.Xpf.Core.SimpleButton  -   5        0  Name$0 	btnkayıt��5�   U     btnsave#��[ 63   $��3��6g   $��25��6w   $	��120��6�   $��Right=�6�   $��0,0,10,0q�6�   6�     5�   "   -   5        $0 btngüncelle��5�   W     	btnupdate#��[ 63   $��3��6l   $��25��6|   $	��120��6�   $��Right=�6�   $��0,0,10,0q�6�   6�     5�   "   -   5        $0 buttonvazgec��5�   W     	btngoback#��[ 63   $��	10,0,10,0q�6�   $��0��6�   $
��Left=�6�   $��25��6�   $	��120��6�   6�   5�      5�      5�      5�      5�      5�      5�      5�      