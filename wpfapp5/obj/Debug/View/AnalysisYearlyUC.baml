   M S B A M L   `   `   `  ����C  ?StarNote, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:StarNote.ViewStarNote.View  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      $    StarNote.View.AnalysisYearlyUC   5      %localclr-namespace:StarNote.View  5      a ]DevExpress.Xpf.Core.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5      a ]DevExpress.Xpf.Grid.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af	 bDevExpress.Xpf.Grid.v18.1.Core, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid  	 5	      Gdxgt<http://schemas.devexpress.com/winfx/2008/xaml/grid/themekeys  5
      0sys&clr-namespace:System;assembly=mscorlib  5      c
 _DevExpress.Xpf.Gauges.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dxga4http://schemas.devexpress.com/winfx/2008/xaml/gauges 
 5      c _DevExpress.Xpf.Charts.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxc4http://schemas.devexpress.com/winfx/2008/xaml/charts  5      <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5      -   5        $��0q�5      $��0q�6*   ���	#FE9590AD  � 	Resources  5       �� Source�� 5   
   $8 2/StarNote;component/Resources/ButtonResources.xaml?�6   %    5      .��5      � $��10,10q�6   $��Stretch=�6   $��Stretch=�66    � RowDefinitions 5   
   �� 5      $	��160 �6   �� 5      $��* �6   .+�5   
   � -   5         �Name$ 	gridModel��5      $��0��6   {�.  5      �� 5      $��25 �6    �� 5       $��* �6    �� 5!      $��25 �6    �� 5"      $��* �6    �� 5#      $��5 �6     � ColumnDefinitions 5&      �� 5'      $	��150 �6#   �� 5(      $	��150 �6#   �� 5)      $��* �6#   �� 5*      $��* �6#   �� 5+      $��* �6#   .+�5/      0 
 *DevExpress.Xpf.Gauges.CircularGaugeControl  -   5        $��circularGaugeControl1��5/   X   $��1��6(   $��0��66   $��3��6F   , 
 &DevExpress.Xpf.Gauges.GaugeControlBase   EnableAnimation .    Scales 50      $ 
 DevExpress.Xpf.Gauges.ArcScale  51      ! 
 DevExpress.Xpf.Gauges.Scale   
StartValue$ 0Q�52         EndValue$	 100Q�6(   	   
StartAngle$	 0Q�53   (   
   EndAngle$	
 360Q�67      MajorIntervalCount$ 1��54   (      MinorIntervalCount$ 1��6?      
ShowLabels] YDevExpress.Data.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a5  /DevExpress.Utils.Design.DefaultBooleanConverter$ false 55   (      ShowLine$ false 6;      ShowMajorTickmarks$
 true 56   (      ShowMinorTickmarks$ false 57   (      ShowSpindleCap$ False 58   (      Layers 5:      ) 
 #DevExpress.Xpf.Gauges.ArcScaleLayer  5;      * 
 $DevExpress.Xpf.Gauges.ScaleLayerBase   Options 5<   "   ( 
 "DevExpress.Xpf.Gauges.LayerOptions  5=   &   5?         Ranges 5A      )	 
 #DevExpress.Xpf.Gauges.ArcScaleRange	  5B      %
 
 DevExpress.Xpf.Gauges.RangeBase 
  EndValue 61   ��  �� Path$ Gaugepurchase� �� Mode$ TwoWay=� 
  Options 5C   "   ( 
 "DevExpress.Xpf.Gauges.RangeOptions  5D   &      Offset$	 -10Q�68      	Thickness$ 10��6E    	  Presentation 5F   "   < 
 6DevExpress.Xpf.Gauges.DefaultArcScaleRangePresentation  5G   &   ? 
 9DevExpress.Xpf.Gauges.PredefinedArcScaleRangePresentation   Fill �	#FF0D2A936L   5I         SpindleCapOptions 5K      - 
 'DevExpress.Xpf.Gauges.SpindleCapOptions  5L         ZIndex$	 100��65   5N      5P      �� 5Q      $��0��6   $��0��6!   $��Center=�61   .��6N   Yıllık Harcamalar6a     5R      -   5        $ ��circularGaugeControlKazanc��5R   W   $��1��6(   $��1��66   $��3��6F    5S        5T      $ 0Q�6$   $	 100Q�63   $	 0Q�5U   (   $	
 360Q�67   $ 1��5V   (   $ 1��6?   $ false 5W   (   $ false 6;   $
 true 5X   )   $ false 5Y   (   $ False 5Z   (    5]        5^       5_   "     5`   &   5b       5d      	  5e       61   �� $ 
Gaugesales�$ TwoWay=� 5f   "     5g   &   $	 -10Q�68   $ 10��6E    5i   "     5j   &    �	#FF0D2A936L   5l       5n        5o      $	 100��65   5q      5s      �� 5t      $��0��6   $��1��6!   $��Center=�61   .��6N   Yıllık Kazançlar6`   �� 5v      $��2��6   $��2��6!   $��Center=�61   .��6N   Yıllık Net Gelir6`   �� 5w      $��3��6   $��2��6$   
�������$��
10,5,10,11q�6H   
���   �$��1q�6q    �� CornerRadius$ 7��6�     �� Padding$  5q�6�   ._�5x      %  DevExpress.Xpf.Editors.TextEdit  %  DevExpress.Xpf.Editors.BaseEdit!   
IsReadOnly! . $��17(�61   $��Center=�6?   $��times new roman)�6d   "   
ShowBorder" .  )  #DevExpress.Xpf.Editors.TextEditBase#   TextWrapping$
# Wrap=�6�   $   Text$ 6�   �� $ Textnet�6�   5y      �� 5z      $��2��6   $��3��6"   $��Center=�62   .��6O   Yıllık Toplam Harcama6f   �� 5{      $��3��6   $��3��6$   
�������$��
10,5,10,11q�6H   
���   �$��1q�6q   $ 7��6�   $  5q�6�   ._�5|        ! . $��17(�61   $��Center=�6?   $��times new roman)�6d   " .  $
# Wrap=�6�   $ 6�   �� $ Textpurchase�6�   5}      �� 5~      $��0��6   $��3��6!   $��Center=�61   .��6N   Yıllık Gerçek Kazanç6d   �� 5      $��1��6   $��3��6%   
�������$��
10,5,10,11q�6I   
���   �$��1q�6r   $ 7��6�   $  5q�6�   ._�5�        ! . $��17(�61   $��Center=�6?   $��times new roman)�6d   " .  $
# Wrap=�6�   $ 6�   �� $ 	Textsales�6�   5�      �� 5�      $��0��6   $��2��6!   $��Center=�61   .��6N   Yıllık Potansiyel Kazanç6h   �� 5�      $��1��6   $��2��6%   
�������$��
10,5,10,11q�6I   
���   �$��1q�6r   $ 7��6�   $  5q�6�   ._�5�        ! . $��17(�61   $��Center=�6?   $��times new roman)�6d   " .  $
# Wrap=�6�   $ 6�   �� $ Textpotansial�6�   5�      �� 5�      -   5        % ��Name$% buttonoutput��5�   ;      btnsettings#��[  6   $��1��6Q   $��Right=�6^   $��Bottom=�6z   $��4��6�   $	��120��6�   $��25��6�   $  DevExpress.Xpf.Bars.BarManager&   MenuShowMouseButton$& 
LeftButton=�6�   '   DXContextMenu' 5�      #  DevExpress.Xpf.Bars.PopupMenu  5�      $	��150��6$   (   Items( 5�      '  !DevExpress.Xpf.Bars.BarButtonItem  5�      -   5        )  Name$) btnpdf��5�   )   !  DevExpress.Xpf.Bars.BarItem*   Content)  #DevExpress.Xpf.Core.ObjectConverter$* 
PDF ÇIKTI 5�   !   +   Glyph$+ /Content/pdf.png��5�   !   5�   !     5�      -   5        $) btnxcel��5�   !   $* Excel ÇIKTI 5�   !   $+ /Content/excel.png��5�   !   5�   !   5�      5�      � 5�      $��2��6   $��2��6    $��4��61   $��Right=�6A    5�      �� 5�      �� 5�      .+�5�      �� $��0��6   $��Center=�6%   $��2��6@   .��6Q   Gösterilen Yıl6a   (  "System.Windows.Controls.DatePicker  5�      -   5        ,  Name$, filtregünü��5�      $��1��62   $��Center=�6A   6]   5�      5�      %  DevExpress.Xpf.Grid.GridControl  5�   
   -	   5        -  Name$- 	grdsatıs��5�      $��1��6.   $
��2000��6p   $
��2000��6�   $��Stretch=�6�   $��Stretch=�6�   $��0,0,0,0q�6�   ) 	 #DevExpress.Xpf.Grid.DataControlBase.   ItemsSource. 6;   �� *Yearlyanalysis+$ TwoWay=�/   View/ 5�      #  DevExpress.Xpf.Grid.TableView  5�      -
   5        0  Name$0 tablesatıs��5�       1   AllowPerPixelScrolling1 . 2   BestFitMode$2 AllRows=�6T   3   	AutoWidth3 . & 	  DevExpress.Xpf.Grid.DataViewBase4   ShowSearchPanelMode$4 Always=�6|   5   AllowEditing5 .  &   DevExpress.Xpf.Grid.GridViewBase6   ShowGroupPanel6 .  7   ShowTotalSummary7 . 6�   8   Columns.8 5�      $  DevExpress.Xpf.Grid.GridColumn  $ 	 DevExpress.Xpf.Grid.BaseColumn9   Header$9 ID 6   :   Width2 	 ,DevExpress.Xpf.Grid.GridColumnWidthConverter$: 50 6/   $  	 DevExpress.Xpf.Grid.ColumnBase;    	FieldName$; ID��6;   <   
FixedWidth< . =    Binding= 6`   �� $ Id�  5�      $9 ÜRÜN 6   $	: 120 6/   $; ÜRÜN��6;   < . = 6`   �� $
 Urun�  5�      $9 1 6   $: 50 6/   $; 1��6;   = 6O   �� $	 Ay1�  5�      $9 2 6   $: 50 6/   $; 2��6;   = 6O   �� $	 Ay2�  5�      $9 3 6   $: 50 6/   $; 3��6;   = 6O   �� $	 Ay3�  5�      $9 4 6   $: 50 6/   $; 4��6;   = 6O   �� $	 Ay4�  5�      $9 5 6   $: 50 6/   $; 5��6;   = 6O   �� $	 Ay5�  5�      $9 6 6   $: 50 6/   $; 6��6;   = 6O   �� $	 Ay6�  5�      $9 7 6   $: 50 6/   $; 7��6;   = 6O   �� $	 Ay7�  5�      $9 8 6   $: 50 6/   $; 8��6;   = 6O   �� $	 Ay8�  5�      $9 9 6   $: 50 6/   $; 9��6;   = 6O   �� $	 Ay9�  5�      $9 10 6   $: 50 6/   $; 10��6;   = 6O   �� $
 Ay10�  5�      $9 11 6   $: 50 6/   $; 11��6;   = 6O   �� $
 Ay11�  5�      $9 12 6   $: 50 6/   $; 12��6;   = 6O   �� $
 Ay12�5�      5�      5�      