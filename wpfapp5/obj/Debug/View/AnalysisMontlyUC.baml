   M S B A M L   `   `   `  ����C  ?StarNote, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:StarNote.ViewStarNote.View  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      $    StarNote.View.AnalysisMontlyUC   5      %localclr-namespace:StarNote.View  5      a ]DevExpress.Xpf.Core.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5      a ]DevExpress.Xpf.Grid.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af	 bDevExpress.Xpf.Grid.v18.1.Core, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid  	 5	      Gdxgt<http://schemas.devexpress.com/winfx/2008/xaml/grid/themekeys  5
      0sys&clr-namespace:System;assembly=mscorlib  5      c
 _DevExpress.Xpf.Gauges.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dxga4http://schemas.devexpress.com/winfx/2008/xaml/gauges 
 5      c _DevExpress.Xpf.Charts.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxc4http://schemas.devexpress.com/winfx/2008/xaml/charts  5      <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5      -   5        $��0q�5      $��0q�6*   ���	#FE9590AD  � 	Resources  5       �� Source�� 5   
   $8 2/StarNote;component/Resources/ButtonResources.xaml?�6   %    5      .��5      � $��10,10q�6   $��Stretch=�6   $��Stretch=�66    � RowDefinitions 5   
   �� 5      $	��160 �6   �� 5      $��* �6   .+�5   
   � -   5         �Name$ 	gridModel��5      $��0��6   {�.  5       �� 5!      $��25 �6    �� 5"      $��* �6    �� 5#      $��25 �6    �� 5$      $��* �6    �� 5%      $��5 �6     � ColumnDefinitions 5(      �� 5)      $	��150 �6#   �� 5*      $	��150 �6#   �� 5+      $��* �6#   �� 5,      $��* �6#   �� 5-      $��* �6#   .+�51      0 
 *DevExpress.Xpf.Gauges.CircularGaugeControl  -   5        $��circularGaugeControl1��51   X   $��1��6(   $��0��66   $��3��6F   , 
 &DevExpress.Xpf.Gauges.GaugeControlBase   EnableAnimation .    Scales 52      $ 
 DevExpress.Xpf.Gauges.ArcScale  53      ! 
 DevExpress.Xpf.Gauges.Scale   
StartValue$ 0Q�54         EndValue$	 100Q�6(   	   
StartAngle$	 0Q�55   (   
   EndAngle$	
 360Q�67      MajorIntervalCount$ 1��56   (      MinorIntervalCount$ 1��6?      
ShowLabels] YDevExpress.Data.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a5  /DevExpress.Utils.Design.DefaultBooleanConverter$ false 57   (      ShowLine$ false 6;      ShowMajorTickmarks$
 true 58   (      ShowMinorTickmarks$ false 59   (      ShowSpindleCap$ False 5:   (      Layers 5<      ) 
 #DevExpress.Xpf.Gauges.ArcScaleLayer  5=      * 
 $DevExpress.Xpf.Gauges.ScaleLayerBase   Options 5>   "   ( 
 "DevExpress.Xpf.Gauges.LayerOptions  5?   &   5A         Ranges 5C      )	 
 #DevExpress.Xpf.Gauges.ArcScaleRange	  5D      %
 
 DevExpress.Xpf.Gauges.RangeBase 
  EndValue 61   ��  �� Path$ Gaugepurchase� �� Mode$ TwoWay=� 
  Options 5E   "   ( 
 "DevExpress.Xpf.Gauges.RangeOptions  5F   &      Offset$	 -10Q�68      	Thickness$ 10��6E    	  Presentation 5H   "   < 
 6DevExpress.Xpf.Gauges.DefaultArcScaleRangePresentation  5I   &   ? 
 9DevExpress.Xpf.Gauges.PredefinedArcScaleRangePresentation   Fill �	#FF0D2A936L   5K         SpindleCapOptions 5M      - 
 'DevExpress.Xpf.Gauges.SpindleCapOptions  5N         ZIndex$	 100��65   5P      5R      �� 5S      $��0��6   $��0��6!   $��Center=�61   .��6N   Aylık Harcamalar6`     5T      -   5        $ ��circularGaugeControlKazanc��5T   W   $��1��6(   $��1��66   $��3��6F    5U        5V      $ 0Q�6$   $	 100Q�63   $	 0Q�5W   (   $	
 360Q�67   $ 1��5X   (   $ 1��6?   $ false 5Y   (   $ false 6;   $
 true 5Z   )   $ false 5[   (   $ False 5\   (    5_        5`       5a   "     5b   &   5d       5f      	  5g       61   �� $ 
Gaugesales�$ TwoWay=� 5h   "     5i   &   $	 -10Q�68   $ 10��6E    5k   "     5l   &    �	#FF0D2A936L   5n       5p        5q      $	 100��65   5s      5u      �� 5v      $��0��6   $��1��6!   $��Center=�61   .��6N   Aylık Kazançlar6_   �� 5x      $��2��6   $��2��6!   $��Center=�61   .��6N   Aylık Net Gelir6_   �� 5y      $��3��6   $��2��6$   
�������$��
10,5,10,11q�6H   
���   �$��1q�6q    �� CornerRadius$ 7��6�     �� Padding$  5q�6�   ._�5z      %  DevExpress.Xpf.Editors.TextEdit  %  DevExpress.Xpf.Editors.BaseEdit!   
IsReadOnly! . $��17(�61   $��Center=�6?   $��times new roman)�6d   "   
ShowBorder" .  )  #DevExpress.Xpf.Editors.TextEditBase#   TextWrapping$
# Wrap=�6�   $   Text$ 6�   �� $ Textnet�6�   5{      �� 5|      $��2��6   $��3��6"   $��Center=�62   .��6O   Aylık Toplam Harcama6e   �� 5}      $��3��6   $��3��6$   
�������$��
10,5,10,11q�6H   
���   �$��1q�6q   $ 7��6�   $  5q�6�   ._�5~        ! . $��17(�61   $��Center=�6?   $��times new roman)�6d   " .  $
# Wrap=�6�   $ 6�   �� $ Textpurchase�6�   5      �� 5�      $��0��6   $��3��6!   $��Center=�61   .��6N   Aylık Gerçek Kazanç6c   �� 5�      $��1��6   $��3��6%   
�������$��
10,5,10,11q�6I   
���   �$��1q�6r   $ 7��6�   $  5q�6�   ._�5�        ! . $��17(�61   $��Center=�6?   $��times new roman)�6d   " .  $
# Wrap=�6�   $ 6�   �� $ 	Textsales�6�   5�      �� 5�      $��0��6   $��2��6!   $��Center=�61   .��6N   Aylık Potansiyel Kazanç6g   �� 5�      $��1��6   $��2��6%   
�������$��
10,5,10,11q�6I   
���   �$��1q�6r   $ 7��6�   $  5q�6�   ._�5�        ! . $��17(�61   $��Center=�6?   $��times new roman)�6d   " .  $
# Wrap=�6�   $ 6�   �� $ Textpotansial�6�   5�      �� 5�      -   5        % ��Name$% buttonoutput��5�   ;      btnsettings#��[  6   $��1��6Q   $��Right=�6^   $��Bottom=�6z   $��4��6�   $	��120��6�   $��25��6�   $  DevExpress.Xpf.Bars.BarManager&   MenuShowMouseButton$& 
LeftButton=�6�   '   DXContextMenu' 5�      #  DevExpress.Xpf.Bars.PopupMenu  5�      $	��150��6$   (   Items( 5�      '  !DevExpress.Xpf.Bars.BarButtonItem  5�      -   5        )  Name$) btnpdf��5�   )   !  DevExpress.Xpf.Bars.BarItem*   Content)  #DevExpress.Xpf.Core.ObjectConverter$* 
PDF ÇIKTI 5�   !   +   Glyph$+ /Content/pdf.png��5�   !   5�   !     5�      -   5        $) btnxcel��5�   !   $* Excel ÇIKTI 5�   !   $+ /Content/excel.png��5�   !   5�   !   5�      5�      � 5�      $��2��6   $��2��6    $��4��61   $��Right=�6A    5�      �� 5�      �� 5�      .+�5�      �� $��0��6   $��Center=�6%   $��2��6@   .��6Q   Gösterilen Ay6`   (  "System.Windows.Controls.DatePicker  5�      -   5        ,  Name$, filtregünü��5�      $��1��62   $��Center=�6A   6]   5�      5�      %  DevExpress.Xpf.Grid.GridControl  5�   
   -	   5        -  Name$- 	grdsatıs��5�      $��1��6.   $
��2000��6p   $
��2000��6�   $��Stretch=�6�   $��Stretch=�6�   $��0,0,0,0q�6�   ) 	 #DevExpress.Xpf.Grid.DataControlBase.   ItemsSource. 6;   �� *Montlyanalysis+$ TwoWay=�/   View/ 5�      #  DevExpress.Xpf.Grid.TableView  5�      -
   5        0  Name$0 tablesatıs��5�       1   AllowPerPixelScrolling1 . 2   BestFitMode$2 AllRows=�6T   3   	AutoWidth3 . & 	  DevExpress.Xpf.Grid.DataViewBase4   ShowSearchPanelMode$4 Always=�6|   5   AllowEditing5 .  &   DevExpress.Xpf.Grid.GridViewBase6   ShowGroupPanel6 .  7   ShowTotalSummary7 . 6�   8   Columns.8 5�      $  DevExpress.Xpf.Grid.GridColumn  $ 	 DevExpress.Xpf.Grid.BaseColumn9   Header$9 ID 6   :   Width2 	 ,DevExpress.Xpf.Grid.GridColumnWidthConverter$: 50 6/   $  	 DevExpress.Xpf.Grid.ColumnBase;    	FieldName$; ID��6;   <   
FixedWidth< . =    Binding= 6`   �� $ Id�  5�      $9 ÜRÜN 6   $	: 120 6/   $; ÜRÜN��6;   < . = 6`   �� $
 Urun�  5�      $9 1 6   $: 50 6/   $; 1��6;   < . = 6`   �� $
 Gun1�  5�      $9 2 6   $: 50 6/   $; 2��6;   < . = 6`   �� $
 Gun2�  5�      $9 3 6   $: 50 6/   $; 3��6;   < . = 6`   �� $
 Gun3�  5�      $9 4 6   $: 50 6/   $; 4��6;   < . = 6`   �� $
 Gun4�  5�      $9 5 6   $: 50 6/   $; 5��6;   < . = 6`   �� $
 Gun5�  5�      $9 6 6   $: 50 6/   $; 6��6;   < . = 6`   �� $
 Gun6�  5�      $9 7 6   $: 50 6/   $; 7��6;   < . = 6`   �� $
 Gun7�  5�      $9 8 6   $: 50 6/   $; 8��6;   < . = 6`   �� $
 Gun8�  5�      $9 9 6   $: 50 6/   $; 9��6;   < . = 6`   �� $
 Gun9�  5�      $9 10 6   $: 50 6/   $; 10��6;   < . = 6`   �� $ Gun10�  5�      $9 11 6   $: 50 6/   $; 11��6;   < . = 6`   �� $ Gun11�  5�      $9 12 6   $: 50 6/   $; 12��6;   < . = 6`   �� $ Gun12�  5�      $9 13 6   $: 50 6/   $; 13��6;   < . = 6`   �� $ Gun13�  5�      $9 14 6   $: 50 6/   $; 14��6;   < . = 6`   �� $ Gun14�  5�      $9 15 6   $: 50 6/   $; 15��6;   < . = 6`   �� $ Gun15�  5�      $9 16 6   $: 50 6/   $; 16��6;   < . = 6`   �� $ Gun16�  5�      $9 17 6   $: 50 6/   $; 17��6;   < . = 6`   �� $ Gun17�  5�      $9 18 6   $: 50 6/   $; 18��6;   < . = 6`   �� $ Gun18�  5�      $9 19 6   $: 50 6/   $; 19��6;   < . = 6`   �� $ Gun19�  5�      $9 20 6   $: 50 6/   $; 20��6;   < . = 6`   �� $ Gun20�  5�      $9 21 6   $: 50 6/   $; 21��6;   < . = 6`   �� $ Gun21�  5�      $9 22 6   $: 50 6/   $; 22��6;   < . = 6`   �� $ Gun22�  5�      $9 23 6   $: 50 6/   $; 23��6;   < . = 6`   �� $ Gun23�  5�      $9 24 6   $: 50 6/   $; 24��6;   < . = 6`   �� $ Gun24�  5�      $9 25 6   $: 50 6/   $; 25��6;   < . = 6`   �� $ Gun25�  5�      $9 26 6   $: 50 6/   $; 26��6;   < . = 6`   �� $ Gun26�  5�      $9 27 6   $: 50 6/   $; 27��6;   < . = 6`   �� $ Gun27�  5�      $9 28 6   $: 50 6/   $; 28��6;   < . = 6`   �� $ Gun28�  5�      $9 29 6   $: 50 6/   $; 29��6;   < . = 6`   �� $ Gun29�  5�      $9 30 6   $: 50 6/   $; 30��6;   < . = 6`   �� $ Gun30�  5�      $9 31 6   $: 50 6/   $; 31��6;   < . = 6`   �� $ Gun31�5�      5�      5�      