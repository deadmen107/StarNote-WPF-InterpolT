   M S B A M L   `   `   `  ����C  ?StarNote, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:StarNote.ViewStarNote.View  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      $    StarNote.View.FilemanagementUC   5      %localclr-namespace:StarNote.View  5      a ]DevExpress.Xpf.Core.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5	      a ]DevExpress.Xpf.Grid.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af	 bDevExpress.Xpf.Grid.v18.1.Core, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid  	 5
      Gdxgt<http://schemas.devexpress.com/winfx/2008/xaml/grid/themekeys  5      Fdxt<http://schemas.devexpress.com/winfx/2008/xaml/core/themekeys  5      Fdxcn;http://schemas.devexpress.com/winfx/2008/xaml/core/internal  5      0sys&clr-namespace:System;assembly=mscorlib  5      <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5      -   5        $��0q�5      $��0q�6*     � 	Resources  5       �� Source�� 5   
   $8 2/StarNote;component/Resources/ButtonResources.xaml?�6   %    5      .��5      &   DevExpress.Xpf.Core.DXTabControl  -   5          Name$ 
tabcontrol��5      ���	#DDFAFAFA�  �DevExpress.Xpf.Core.Native.SelectorBase`2[[DevExpress.Xpf.Core.DXTabControl, DevExpress.Xpf.Core.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a],[DevExpress.Xpf.Core.DXTabItem, DevExpress.Xpf.Core.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a]]   SelectedIndex$ 0��6A      View 5   
   1  +DevExpress.Xpf.Core.TabControlMultiLineView  5      ,  &DevExpress.Xpf.Core.TabControlViewBase   HeaderLocation$
 None=�6)   .@�5   
   #  DevExpress.Xpf.Core.DXTabItem  -   5          Name$ tabtakip��5   (   �  �DevExpress.Xpf.Core.Native.HeaderedSelectorItemBase`2[[DevExpress.Xpf.Core.DXTabControl, DevExpress.Xpf.Core.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a],[DevExpress.Xpf.Core.DXTabItem, DevExpress.Xpf.Core.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a]]   Header$ takip��6   .��5      � ���	#DDFAFAFA$��Stretch=�6+   $��Stretch=�6G    � RowDefinitions 5       �� 5!      $��40 �6$   �� 5"      $��* �6$   .+�5$      � $��0��6   	 � ColumnDefinitions	 5%      �� 5&      $	��300 �6+   �� 5'      $��* �6+   �� 5(      $	��140 �6+   �� 5)      $	��140 �6+   .+�5+      �� 
������ 
������ $��Dosya Yönetimi��6Q   $��Center=�6h   $��18(�6�   $��Times New Roman)�6�   �� 5,      -   5        
 ��Name$
 buttonyenikayıt��5,   �      btnyenikayıt#��[  6   $��Right=�6D   $��3��6`   $��0,0,10,0q�6p   $��25��6�   $	��120��6�   6�   �� 5.      -   5        $
 buttonoutput��5.   C     btnsettings#��[ 6   $��2��6Y   $	��140��6j   $��25��6v   $  DevExpress.Xpf.Bars.BarManager   MenuShowMouseButton$ 
LeftButton=�6�      DXContextMenu 5/      #  DevExpress.Xpf.Bars.PopupMenu  50         Items 51   "   '	  !DevExpress.Xpf.Bars.BarButtonItem	  52   &   -   5         	 Name$ btnpdf��53   )   !
  DevExpress.Xpf.Bars.BarItem 
  Content)  #DevExpress.Xpf.Core.ObjectConverter$ 
PDF ÇIKTI 54   !    
  Glyph$ /Content/pdf.png��55   !   56   !   	  57   &   -   5        $ btnxcel��58   !   $ Excel ÇIKTI 59   !   $ /Content/excel.png��5:   !   5;   !   	  5<   &   -   5        $ btnayar��5=   !   $ Görünümü Kaydet 5>   !   $  /Content/settings mini.png��5?   !   5@   )   5B      5D      5E      %  DevExpress.Xpf.Grid.GridControl  5F      -	   5          Name$ griddosyatakip��5F   "   $��1��6;   $
��2000��6w   $
��2000��6�   $��Stretch=�6�   $��Stretch=�6�   $��0,0,0,0q�6�   ) 	 #DevExpress.Xpf.Grid.DataControlBase   ItemsSource 6J   �� *
Filelist+ �� Mode$ TwoWay=�   View 5G      #  DevExpress.Xpf.Grid.TableView  5H      -
   5          Name$ 	tableAcik��5H   (      AllowPerPixelScrolling .    BestFitMode$ AllRows=�6�      	AutoWidth . & 	  DevExpress.Xpf.Grid.DataViewBase   ShowSearchPanelMode$ Always=�6�      AllowEditing .  &   DevExpress.Xpf.Grid.GridViewBase   ShowGroupPanel .     ShowTotalSummary .     RowCellMenuCustomizations 5I      	  5J   "   -   5        $ btnindir��5J   4   $ Dosyayı İndir    6F   6a   	  5K   "   -   5        $ btnsil��5K   4   $ Dosyayı Sil     6D   6_   5M         Columns 5O      $  DevExpress.Xpf.Grid.GridColumn  5P      -   5          Name$ Id��5P   )   $ 	 DevExpress.Xpf.Grid.BaseColumn    Header$  ID 65   !   Width2 	 ,DevExpress.Xpf.Grid.GridColumnWidthConverter$! 80 6e   $ 	 DevExpress.Xpf.Grid.ColumnBase"   	FieldName$" ID��6r   #   ReadOnly# . $   Binding$ 6F   �� % �� Path$% Id�&   EditSettings& 5Q      6  0DevExpress.Xpf.Editors.Settings.TextEditSettings  5R   "   6  0DevExpress.Xpf.Editors.Settings.BaseEditSettings!'   HorizontalContentAlignment$
' Left=�67   5T        5U      $  MÜŞTERİ TÜRÜ 6)   $ 6?   �� $% Türadı�& 5V        5W   "   $
' Left=�67   5Y        5Z      $  MAHKEME TÜRÜ 6*   $ 6@   �� $% 	Türdetay�& 5[        5\   "   $
' Left=�67   5^        5_      $  ESAS NO 6*   $ 6;   �� $% Kayıtdetay�& 5`        5a   "   $
' Left=�67   5c        5d      $  
FİRMA ADI 6*   $ 6=   �� $% Firmadı�& 5e        5f      $
' Left=�63   5h        5i      $  KLASÖR ADI 6*   $ 6>   �� $% 	Klasörno�& 5j   "     5k   &   $
' Left=�6;   5m        5n      $  MÜŞTERİ ADI 6)   $ 6>   �� $% Müşteriadı�& 5o        5p   "   $
' Left=�67   5r        5s      $  	DOSYA ADI 6*   $ 6=   �� $% 	Dosyaadı�& 5t        5u   "   $
' Left=�67   5w      5y      5z      5{        5|   
   -   5        $ tabgüncelleme��5|   *   $ 	güncelle��6   .��5}      �� $	��-12q�6   ���	#FE9590AD$
��Auto=�6C   $
��Auto=�6f     5~      ( �� 
TargetType) �� Property* �� Value+ �� Triggers, P� Property- P� Value��%�  '��       �� 5      "( ��67   .�5�      �� ) �@��IsFlicksEnabled* . 6C   + 5�      P� 5�      , �@��Orientation$- 
Horizontal=�6=   . �5�   "   �� ) � ��$* 7��6;   �� 5�   "   ) � ��$* 7��6>   5�      P� 5�      , �@��Orientation$- Vertical=�6=   . �5�   "   �� ) � ��$* 12��6:   �� 5�   "   ) � ��$* 12��6=   5�      5�      5�      .��5�      � $��Stretch=�6   $��Stretch=�65   	 5�      �� 5�      $��20 �6+   �� 5�      $��* �6+   �� 5�      $��20 �6+    5�      �� 5�      $��40 �6(   �� 5�      $��* �6(   .+�5�      � $��0��6   $��1��6(   	 5�      �� 5�      $	��300 �60   �� 5�      $��* �6/   �� 5�      $	��300 �6/   .+�5�      �� -   5        . ��Name$. kayıtekrantext��5�   "   
������ 
������ $��Dosya Takip > Yeni Kayıt��6m   $��Center=�6�   $��18(�6�   $��Times New Roman)�6�   5�      � 5�      $��1��6   $��1��6(    5�      �� 5�      $	��100 �6,   �� 5�      $��30 �6,   �� 5�      $	��100 �6,   �� 5�      $��30 �6,   �� 5�      $��50 �6,   �� 5�      $��30 �6,   .+�5�      �� ���	#FFFAFAFA$��0��68   / �� CornerRadius$/ 19��6G   0 �� Padding$0 0q�6Y   ._�5�      � 	 5�   "   �� 5�   &   �� 5�   &    5�   "   �� 5�   &   $��47 �64   �� 5�   &   $��* �65   .+�5�   "   �� $	��Top=�6(   $��
10,0,10,10q�6@   $��13(�6T   $
��Bold"�6b   $
��Left=�6t   $��0��6�   $��0��6�   .��6�   Dosya Konum Bilgileri6�   �� 5�   "   $��0��6,   $��4��6<   $��0��6P   $��
5,25,10,10q�6]   6t   �� 5�   "   $��Bottom=�6)   $��
10,0,10,-4q�6D   $��11(�6X   $
��left=�6g   $��0��6�   $��0��6�   .��6�   Üst Başlık(Tür Adı)6�   �� 5�   "   $��1��6*   $��1��6:   
�������$��10,10,10,11q�6Z   
���   �$��1q�6�   $/ 7��6�   $0 5q�6�   ._�5�   &   %  DevExpress.Xpf.Editors.TextEdit  -   5        $��
txtfirmaad��5�   3   %  DevExpress.Xpf.Editors.BaseEdit1   
ShowBorder1 .  2   NullText$2 Alt Başlık��6[   )  #DevExpress.Xpf.Editors.TextEditBase3   Text3 6r   �� $% Currentdata.Görevliadı�6�   5�   #   �� 5�   "   $��Bottom=�6)   $��
10,0,10,-4q�6D   $��11(�6X   $
��left=�6g   $��1��6�   $��0��6�   .��6�   Alt Başlık(Firma Adı)6�   �� 5�   "   $��0��6*   $��1��6:   
�������$��10,10,10,11q�6Z   
���   �$��1q�6�   $/ 7��6�   $0 5q�6�   ._�5�   &     -   5        $��txtaltbaslık��5�   3   1 .  $2 Üst Başlık��6]   3 6t   �� $% Currentdata.Görevliadı�6�   5�   #   5�      5�      �� 5�      ���	#FFFAFAFA$��2��68   $/ 19��6G   $0 0q�6Y   ._�5�      � 	 5�   "   �� 5�   &    5�   "   �� 5�   &   $��47 �64   �� 5�   &   $��* �65   .+�5�   "   �� $	��Top=�6(   $��
10,0,10,10q�6@   $��13(�6T   $
��Bold"�6b   $
��Left=�6t   $��0��6�   $��0��6�   .��6�   Dosya Bilgileri6�   �� 5�   "   $��0��6,   $��4��6<   $��0��6P   $��
5,25,10,10q�6]   6t   �� 5�   "   $��Bottom=�6)   $��
10,0,10,-4q�6D   $��11(�6X   $
��left=�6g   $��0��6�   $��0��6�   .��6�   Dosya Adı ve Konumu6�   �� 5�   "   $��0��6*   $��1��6:   
�������$��10,10,10,11q�6Z   
���   �$��1q�6�   $/ 7��6�   $0 5q�6�   ._�5�   &     -   5        $��
txtdosyaad��5�   3   1 .  $2 
Dosya Adı��6[   3 6q   �� $% Currentdata.Görevliadı�6�   5�   #   5�      5�      �� 5�      ���	#FFFAFAFA$��4��69   $��1��6F   $/ 19��6V   $0 0q�6h   ._�5�      � 	 5�   "   �� 5�   &   �� 5�   &   �� 5�   &   �� 5�   &   .+�5�   "   &   DevExpress.Xpf.Core.SimpleButton  -   5        4  Name$4 	btnkayıt��5�   S     btnsave#��[ 62   $��3��6e   $��25��6u   $	��120��6�   $��Right=�6�   $��0,0,10,0q�6�   6�     5�   "   -   5        $4 btnyenidizin��5�   \     FlatButtonStyle#��[ 62   $��2��6r   $��25��6�   $	��150��6�   $��Right=�6�   $��0,0,0,0q�6�   .��6�   Otomatik Dosya Seç6�     5�   "   -   5        $4 buttonvazgec��5�   V     	btngoback#��[ 62   $��	10,0,10,0q�6�   $��0��6�   $
��Left=�6�   $��25��6�   $	��120��6�   6�   5�      5�      5�      5�      5�      5�      5�      5�      