   M S B A M L   `   `   `  ����C  ?StarNote, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:StarNote.ViewStarNote.View  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5          StarNote.View.SalesmanUC   5      %localclr-namespace:StarNote.View  5      a ]DevExpress.Xpf.Core.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5	      a ]DevExpress.Xpf.Grid.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af	 bDevExpress.Xpf.Grid.v18.1.Core, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid  	 5
      Gdxgt<http://schemas.devexpress.com/winfx/2008/xaml/grid/themekeys  5      0sys&clr-namespace:System;assembly=mscorlib  5      c
 _DevExpress.Xpf.Gauges.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a?dxga4http://schemas.devexpress.com/winfx/2008/xaml/gauges 
 5      c _DevExpress.Xpf.Charts.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxc4http://schemas.devexpress.com/winfx/2008/xaml/charts  5      <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5      -   5        $��0q�5      $��0q�6*   ���	#FE9590AD  � 	Resources  5       �� Source�� 5   
   $8 2/StarNote;component/Resources/ButtonResources.xaml?�6   %    5      .��5      � $��10,10q�6   $��Stretch=�6   $��Stretch=�66    � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5!   
   �� 5"      $��* �6   �� 5#      $	��400 �6   .+�5&   
   � $��0��6   $��1��6    5'      �� 5(      $��* �6#   �� 5)      $��70 �6#   �� 5*      $��70 �6#   �� 5+      $��70 �6#   �� 5,      $	��130 �6#    5.      �� 5/      $��* �6    �� 50      $��40 �6    �� 51      $��* �6    .+�53      (  "System.Windows.Controls.DatePicker  -   5          Name$ filtregünü��53      $��2��6-   $��2��6=   $��1��6Q   $��Center=�6`   6|   �� 55      -   5         ��Name$ buttonoutput��55   ;      btnsettings#��[  6   $��1��6Q   $��4��6^   $	��120��6n   $��25��6z   $  DevExpress.Xpf.Bars.BarManager   MenuShowMouseButton$ 
LeftButton=�6�      DXContextMenu 56      #  DevExpress.Xpf.Bars.PopupMenu  57      $	��150��6$      Items 59      '  !DevExpress.Xpf.Bars.BarButtonItem  5;      -   5        	  Name$	 btnpdf��5<   )   !  DevExpress.Xpf.Bars.BarItem
   Content)  #DevExpress.Xpf.Core.ObjectConverter$
 
PDF ÇIKTI 5=   !   
 � Tag$ 0��5>   )      Glyph$ /Content/pdf.png��5?   !   5@   !     5A      -   5        $	 btnxcel��5C   !   $ 0��5B   !   $
 Excel ÇIKTI 5D   !   $ /Content/excel.png��5E   !   5F   !     5G      -   5        $	 btnayar��5H   !   $
 Görünümü Kaydet 5I   !   $  /Content/settings mini.png��5J   !   5K   !   5N      5Q      5R      %  DevExpress.Xpf.Grid.GridControl  5S   
   -   5          Name$ grdsatınalma��5S   ,   $��5,0,5,2q�6   $��0��6B   $��1��6T   $
��2000��6�   $
��2000��6�   $��Stretch=�6�   $��Stretch=�6�   ) 	 #DevExpress.Xpf.Grid.DataControlBase   ItemsSource 6a   �� *Salesmansaleslist+ �� Mode$ TwoWay=�   View 5U      #	  DevExpress.Xpf.Grid.TableView	  5V      -   5         	 Name$ tablesatınalma��5V        	  AllowPerPixelScrolling .  	  BestFitMode$ AllRows=�6X    	  	AutoWidth . &
 	  DevExpress.Xpf.Grid.DataViewBase 
  ShowSearchPanelMode$ Always=�6�    
  AllowEditing .  &   DevExpress.Xpf.Grid.GridViewBase   ShowGroupPanel .   
  ShowTotalSummary . 6�      Columns. 5Y      $  DevExpress.Xpf.Grid.GridColumn  $ 	 DevExpress.Xpf.Grid.BaseColumn   Header$ ID 6      Width2 	 ,DevExpress.Xpf.Grid.GridColumnWidthConverter$ 50 6<   $ 	 DevExpress.Xpf.Grid.ColumnBase   	FieldName$ ID��6J      Binding 6l   �� *Id+  5Z      $ 	TERCÜMAN 6   $
 auto 65   $ SATIŞ GÖREVLİSİ��6C    6e   �� *
Görevli+  5[      $ ÜRÜN 6   $
 auto 6<   $ ÜRÜN��6J    6l   �� *Ürün+  5\      $ BİRİM 6   $
 auto 6<   $ BİRİM��6J    6l   �� *Birim+  5]      $ MİKTAR 6   $
 auto 6<   $ MİKTAR��6J    6n   �� *Adet+  5^      $ ÜCRET 6   $
 auto 6<   $ Ücret��6J    6l   �� *Ücret+5`        5b   
   -	   5        $ 
grdsatış��5b   ,   $��5,0,5,2q�6   $��0��6>   $��2��6P   $
��2000��6�   $
��2000��6�   $��Stretch=�6�   $��Stretch=�6�    6]   �� *Salesmanpurchaselist+$ TwoWay=� 5d      	  5e      -
   5        $ tablesatış��5e        . $ AllRows=�6T    . $ Always=�6|    .   .   . 6�   . 5h        $ ID 6   $ 50 6>   $ ID��6L    6n   �� *Id+  5i      $ 	TERCÜMAN 6   $
 auto 67   $ SATIŞ GÖREVLİSİ��6E    6g   �� *
Görevli+  5j      $ ÜRÜN 6   $
 auto 6>   $ ÜRÜN��6L    6n   �� *Ürün+  5k      $ BİRİM 6   $
 auto 6>   $ BİRİM��6L    6n   �� *Birim+  5l      $ MİKTAR 6   $
 auto 6>   $ MİKTAR��6L    6n   �� *Adet+  5m      $ ÜCRET 6   $
 auto 6>   $ Ücret��6L    6n   �� *Ücret+5n      (  "DevExpress.Xpf.Charts.ChartControl  5p   
   -   5        $��chartControl��5p      $��1��6/   $��1��6?      Diagram. 5q      +  %DevExpress.Xpf.Charts.SimpleDiagram2D  #  DevExpress.Xpf.Charts.Diagram   Series. 5r      '  !DevExpress.Xpf.Charts.PieSeries2D  -   5           Name$  series��5r   "   "  DevExpress.Xpf.Charts.Series!   DisplayName$! Sales��5s   "   "   ArgumentDataMember$" Argument��5u   "   #   ValueDataMember$# Value��5v   "   $   LabelsVisibility$ . %   LegendTextPattern$% {A}: {V}��5x   "   %  DevExpress.Xpf.Charts.PieSeries&   HoleRadiusPercent$& 50Q�5y   "   '   
DataSource' 5t   "   �� ( �� Path$( Datasalespie�)   Model) 5{      +  %DevExpress.Xpf.Charts.GlarePie2DModel  5|      *   
TotalLabel* 5      )  #DevExpress.Xpf.Charts.PieTotalLabel  5�      +   TextPattern$+  ��6,   ,   Label, 5�      '  !DevExpress.Xpf.Charts.SeriesLabel  5�      -   TextPattern$	- {A}��6*   .   LabelPosition$. 
TwoColumns=�5�   *   /   Titles/ 5�      !  DevExpress.Xpf.Charts.Title  5�      %  DevExpress.Xpf.Charts.TitleBase0   Content$0 Tercüman Aylık Satış��6$   6E   5�      5�      5�        5�   
   -   5        $��chartControl1��5�      $��1��60   $��2��6@   . 5�        . 5�        -   5        $  series1��5�   "   $! Sales��5�   "   $" Argument��5�      $# Value��5�   "   $ . $% {A}:{V}��5�   "   $& 50Q�5�   "   ' 5�   "   �� $( Datapurchasepie�) 5�        5�      * 5�        5�      $+  ��60   , 5�        5�      $	- {A}��6.   $. 
TwoColumns=�5�   *   / 5�        5�      $"0 Tercüman Aylık Satın Alma��6$   6J   5�      5�      ,  &DevExpress.Xpf.Charts.ChartControlBase1   Legends1 5�      5�      5�      5�      