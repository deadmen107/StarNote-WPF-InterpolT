   M S B A M L   `   `   `  ����C  ?StarNote, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:StarNote.ViewStarNote.View  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5          StarNote.View.UsersUC   5      %localclr-namespace:StarNote.View  5      a ]DevExpress.Xpf.Core.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5      a ]DevExpress.Xpf.Grid.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af	 bDevExpress.Xpf.Grid.v18.1.Core, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid  	 5	      Gdxgt<http://schemas.devexpress.com/winfx/2008/xaml/grid/themekeys  5
      0sys&clr-namespace:System;assembly=mscorlib  5      <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5      -   5        $��0q�5      $��0q�6*   ���	#FE9590AD  � 	Resources  5       �� Source�� 5   
   $8 2/StarNote;component/Resources/ButtonResources.xaml?�6   %    5      .��5      &   DevExpress.Xpf.Core.DXTabControl  -   5          Name$ 
tabcontrol��5      �  �DevExpress.Xpf.Core.Native.SelectorBase`2[[DevExpress.Xpf.Core.DXTabControl, DevExpress.Xpf.Core.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a],[DevExpress.Xpf.Core.DXTabItem, DevExpress.Xpf.Core.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a]]   SelectedIndex$ 0��6*      View 5   
   1  +DevExpress.Xpf.Core.TabControlMultiLineView  5      ,  &DevExpress.Xpf.Core.TabControlViewBase   HeaderLocation$
 None=�6)   .@�5   
   #  DevExpress.Xpf.Core.DXTabItem  -   5          Name$ tabtakip��5   (   �  �DevExpress.Xpf.Core.Native.HeaderedSelectorItemBase`2[[DevExpress.Xpf.Core.DXTabControl, DevExpress.Xpf.Core.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a],[DevExpress.Xpf.Core.DXTabItem, DevExpress.Xpf.Core.v18.1, Version=18.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a]]   Header$ takip��6   .��5      � ���	#DDFAFAFA$��Stretch=�6+   $��Stretch=�6G    � RowDefinitions 5      �� 5      $��40 �6$   �� 5      $��* �6$   .+�5       � $��0��6   	 � ColumnDefinitions	 5!      �� 5"      $	��300 �6+   �� 5#      $��* �6+   �� 5$      $	��140 �6+   �� 5%      $	��140 �6+   .+�5'      �� 
������ 
������ $��Center=�6Q   $��18(�6l   $��Times New Roman)�6z   .��6�   Kullanıcılar6�   �� 5(      -   5        
 ��Name$
 buttonyenikayıt��5(   �      btnyenikayıt#��[  6   $��Right=�6D   $��3��6`   $��0,0,10,0q�6p   $��25��6�   $	��120��6�   6�   �� 5)      -   5        $
 buttonoutput��5)   C     btnsettings#��[ 6   $��2��6Y   $	��140��6j   $��25��6v   $  DevExpress.Xpf.Bars.BarManager   MenuShowMouseButton$ 
LeftButton=�6�      DXContextMenu 5*      #  DevExpress.Xpf.Bars.PopupMenu  5+         Items 5,   "   '	  !DevExpress.Xpf.Bars.BarButtonItem	  5-   &   -   5         	 Name$ btnpdf��5.   )   !
  DevExpress.Xpf.Bars.BarItem 
  Content)  #DevExpress.Xpf.Core.ObjectConverter$ 
PDF ÇIKTI 5/   !    
  Glyph$ /Content/pdf.png��50   !   51   !   	  52   &   -   5        $ btnxcel��53   !   $ Excel ÇIKTI 54   !   $ /Content/excel.png��55   !   56   !   58      5;      5<      %  DevExpress.Xpf.Grid.GridControl  5=      -   5          Name$ grdmain��5=   "   $��2��64   $��1��6E   $
��2000��6�   $
��2000��6�   $��Stretch=�6�   $��Stretch=�6�   $��0,0,0,0q�6�   ) 	 #DevExpress.Xpf.Grid.DataControlBase   ItemsSource 6S   ��  �� Path$ Userlist� �� Mode$ TwoWay=�   View 5>      #  DevExpress.Xpf.Grid.TableView  5?      -	   5          Name$ 	tableAcik��5?   (      AllowPerPixelScrolling .    BestFitMode$ AllRows=�6�      	AutoWidth . & 	  DevExpress.Xpf.Grid.DataViewBase   ShowSearchPanelMode$ Never=�6�      AllowEditing .  &   DevExpress.Xpf.Grid.GridViewBase   ShowGroupPanel .     ShowTotalSummary .     RowCellMenuCustomizations 5@      	  5A   "   -
   5        $ btnsil��5A   4   $ Kullanıcı Sil    6D   6_   5C         Columns 5E      $  DevExpress.Xpf.Grid.GridColumn  5F      $ 	 DevExpress.Xpf.Grid.BaseColumn    Header$  ID 6)   $ 	 DevExpress.Xpf.Grid.ColumnBase!   	FieldName$! ID��6p   "   ReadOnly" . #   Binding# 6F   �� $ Id�6     5G      $  İsim 6)   $
! Name��6h   # 6=   �� $ İsim�6h     5H      $  Soyisim 6)   $! Surname��6p   # 6C   �� $ Soyisim�6p     5I      $  Kullanıcı Adı 6)   $
! User��6y   # 6F   �� $ Kullanıcıadi�6y     5J      $  
Mail Adres 6)   $
! Mail��6u   # 6F   �� $ 	Mailadres�6u     5K      $  Yetki Seviyesi 6)   $! Yetki��6q   # 6F   �� $ Yetki�6q     5L      $  Aktif 6)   $! Isactive��6i   # 6=   �� $ Okumayetkisi�6i     5M      $  Kayıt Tarihi 6)   $! Regdate��6t   # 6F   �� $ Kayıttarihi�6t   5O      5P      5Q        5R   
   -   5        $ tabgüncelleme��5R   +   $ 	güncelle��6   .��5T      �� $	��-12q�6   ���	#FE9590AD$
��Auto=�6C   $
��Auto=�6f     5U      $ �� 
TargetType% �� Property& �� Value' �� Triggers( P� Property) P� Value��%�  '��       �� 5V      "$ ��67   .�5W      �� % �@��IsFlicksEnabled& . 6C   ' 5X      P� 5Y      ( �@��Orientation$) 
Horizontal=�6=   . �5Z   "   �� % � ��$& 7��6;   �� 5[   "   % � ��$& 7��6>   5\      P� 5]      ( �@��Orientation$) Vertical=�6=   . �5^   "   �� % � ��$& 14��6:   �� 5_   "   % � ��$& 14��6=   5`      5b      5c      .��5d      � $��Stretch=�6   $��Stretch=�65   	 5e      �� 5f      $��20 �6+   �� 5g      $��* �6+   �� 5h      $��20 �6+    5j      �� 5k      $��40 �6(   �� 5l      $��* �6(   .+�5n      � $��0��6   $��1��6(   	 5o      �� 5p      $	��300 �60   �� 5q      $��* �6/   �� 5r      $	��300 �6/   .+�5t      �� -   5        * ��Name$* kayıtekrantext��5t   "   
������ 
������ $��Yeni Kayıt Ekleme��6m   $��Center=�6�   $��18(�6�   $��Times New Roman)�6�   �� 5u      -   5        + ��Name$+ isactivebtn��5u   #   $��Center=�68   $��Right=�6S   $	��120��6o   $��2��6{   $��0,0,10,0q�6�   $��24��6�   , d� 	IsChecked, 6�   �� $ Currentdata.Isactive�.��6�   Aktif Kullanıcı6�   5v      � 5w      $��1��6   $��1��6(    5x      �� 5y      $	��100 �6,   �� 5z      $��30 �6,   �� 5{      -   5        - ��Name$- hesaprow��5{   ,   $	��200 �6?   �� 5|      $��30 �6,   �� 5}      $	��400 �6,   �� 5~      $��30 �6,   �� 5�      $��50 �6,   �� 5�      $��30 �6,   .+�5�      �� ���	#FFFAFAFA$��0��68   . �� CornerRadius$. 19��6G   / �� Padding$/ 0q�6Y   ._�5�      � 	 5�   "   �� 5�   &   �� 5�   &    5�   "   �� 5�   &   $��47 �64   �� 5�   &   $��* �65   .+�5�   "   �� $	��Top=�6(   $��
10,0,10,10q�6@   $��13(�6T   $
��Bold"�6b   $
��Left=�6t   $��0��6�   $��0��6�   .��6�   Kullanıcı Bilgileri6�   �� 5�   "   $��0��6,   $��4��6<   $��0��6P   $��
5,25,10,10q�6]   6t   �� 5�   "   $��Bottom=�6(   $��
10,0,10,-4q�6C   $��11(�6W   $
��left=�6f   $��0��6�   $��0��6�   .��6�   İSİM6�   �� 5�   "   $��Bottom=�6(   $��
10,0,10,-4q�6C   $��11(�6W   $
��left=�6f   $��1��6�   $��0��6�   .��6�   	SOYİSİM6�   �� 5�   "   $��0��6*   $��1��6:   
�������$��10,10,10,11q�6Z   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5�   &   %  DevExpress.Xpf.Editors.TextEdit  -   5        $��txtisim��5�   3   %  DevExpress.Xpf.Editors.BaseEdit0   
ShowBorder0 .  1   NullText$1 İsim��6X   )  #DevExpress.Xpf.Editors.TextEditBase2   Text2 6i   �� $ Currentdata.İsim�6�   5�   #   �� 5�   "   $��1��6*   $��1��6:   
�������$��10,10,10,11q�6Z   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5�   &     -   5        $��
txtsoyisim��5�   3   0 .  $1 Soyisim��6Y   2 6m   �� $ Currentdata.Soyisim�6�   5�   #   5�      5�      �� 5�      ���	#FFFAFAFA$��2��69   $��1��6F   $. 19��6V   $/ 0q�6h   ._�5�      � 	 5�   "   �� 5�   &   �� 5�   &    5�   "   �� 5�   &   $��47 �64   �� 5�   &   $��53 �64   �� 5�   &   $��47 �64   �� 5�   &   $��* �65   .+�5�   "   �� $	��Top=�6(   $��
10,0,10,10q�6@   $��13(�6T   $
��Bold"�6b   $
��Left=�6t   $��0��6�   $��0��6�   .��6�   Hesap Bilgileri6�   �� 5�   "   $��0��6,   $��4��6<   $��0��6P   $��
5,25,10,10q�6]   6t   �� 5�   "   $��Bottom=�6(   $��10,10,10,-4q�6C   $��11(�6X   $
��left=�6g   $��0��6�   $��0��6�   .��6�   KULLANICI ADI6�   �� 5�   "   $��Bottom=�6(   $��10,10,10,-4q�6C   $��11(�6X   $
��left=�6g   $��1��6�   $��0��6�   .��6�   	E-POSTA6�   �� 5�   "   $��Bottom=�6(   $��10,10,10,-4q�6C   $��11(�6X   $
��left=�6g   $��0��6�   $��2��6�   .��6�   PAROLA6�   �� 5�   "   $��Bottom=�6(   $��10,10,10,-4q�6C   $��11(�6X   $
��left=�6g   $��1��6�   $��2��6�   .��6�   PAROLA YENİDEN6�   �� 5�   "   $��0��6+   $��1��6;   
�������$��10,10,10,11q�6\   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5�   &     -   5        $��
txtvergino��5�   3   $1 Kullanıcı Adı��6H   0 .  2 6u   �� $  Currentdata.Kullanıcıadi�6�   5�   #   �� 5�   "   $��1��6,   $��1��6<   
�������$��10,10,10,11q�6]   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5�   &     -   5        $��txtvergidaire��5�   3   $1 E-posta��6H   0 .  2 6p   �� $ Currentdata.Mailadres�6�   5�   #   �� 5�   "   $��0��6*   
�������$��3��6N   $��10,10,10,11q�6\   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5�   &   ,  &DevExpress.Xpf.Editors.PasswordBoxEdit  -   5        $��	txtParola��5�   >   0 .  $1 Parola��6b   2 6v   �� $ Currentdata.Şifre�6�   5�   #   �� 5�   "   $��1��6*   
�������$��3��6N   $��10,10,10,11q�6\   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5�   &     -   5        $��txtParolayeniden��5�   >   0 .  $1 Parola��6i   2 6}   �� $ 
Passwordre�6�   5�   #   5�      5�      �� 5�      ���	#FFFAFAFA$��4��68   $��1��6E   $. 19��6U   $/ 0q�6g   ._�5�      � 	 5�   "   �� 5�   &    5�   "   �� 5�   &   $��47 �64   �� 5�   &   $��* �64   .+�5�   "   �� $	��Top=�6(   $��
10,0,10,10q�6@   $��13(�6T   $
��Bold"�6b   $
��Left=�6t   $��0��6�   $��0��6�   .��6�   	YETKİLER6�   &   DevExpress.Xpf.Core.SimpleButton  5�   "   -   5        3  Name$3 buttonallauthory��5�   2   $��	10,3,20,0q�6k   $��Hepsini Seç��6~   $��0��6�   $	��Top=�6�   $��Right=�6�   $��20��6�   $	��120��6�   4 � ToolTip4 5�   &   �� 5�   *   .+�5�   .   �� Bütün Yetkileri Ver !5�   /   �� 5�   .   
������$��0,1,0,0q�6N   $	��0,8q�6h   5�   +   5�   #   �� 5�   "   $��0��6,   $��4��6<   $��0��6P   $��
5,25,10,10q�6]   6t   �� 5�   "   $��1��6*   $��
10,8,10,15q�68   
���   �$��1q�6a   $. 7��6u   $/ 5q�6�   ._�5�   &   �� $
��Auto=�65   $
��Auto=�6X     5�   *   ��%�  '��       �� 5�   .   "$ ��6O   .�5�   2   �� % �@��IsFlicksEnabled& . 6[   ' 5�   2   P� 5�   6   ( �@��Orientation$) 
Horizontal=�6U   . �5�   :   �� % � ��$& 7��6S   �� 5�   :   % � ��$& 7��6V   5�   7   P� 5�   6   ( �@��Orientation$) Vertical=�6U   . �5�   :   �� % � ��$& 12��6R   �� 5�   :   % � ��$& 12��6U   5�   7   5�   /   5�   +   .��5�   *   � 	 5�   .   �� 5�   2   �� 5�   2   �� 5�   2   �� 5�   2    5�   .   �� 5�   2   $��* �6@   �� 5�   2   $��53 �6@   �� 5�   2   $��30 �6@   �� 5�   2   $��53 �6@   �� 5�   2   $��30 �6@   �� 5�   2   $��53 �6A   �� 5�   2   $��30 �6@   �� 5�   2   $��53 �6@   �� 5�   2   $��30 �6@   �� 5�   2   $��53 �6A   �� 5�   2   $��30 �6@   �� 5�   2   $��53 �6@   �� 5�   2   $��30 �6@   �� 5�   2   $��53 �6A   �� 5�   2   $��30 �6@   �� 5�   2   $��53 �6@   �� 5�   2   $��30 �6@   �� 5   2   $��53 �6A   �� 5  2   $��30 �6@   �� 5  2   $��53 �6@   �� 5  2   $��30 �6@   �� 5  2   $��53 �6@   �� 5  2   $��30 �6@   �� 5  2   $��53 �6A   �� 5  2   $��30 �6@   �� 5  2   $��53 �6A   �� 5	  2   $��30 �6@   �� 5
  2   $��53 �6A   �� 5  2   $��30 �6@   �� 5  2   $��53 �6A   �� 5  2   $��30 �6@   �� 5  2   $��53 �6A   �� 5  2   $��30 �6@   �� 5  2   $��53 �6A   �� 5  2   $��30 �6@   �� 5  2   $��53 �6A   .+�5  .   �� $��0��65   $��1��6E   
�������$��
10,8,10,10q�6e   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5  2   &   DevExpress.Xpf.Editors.CheckEdit  -   5        5  Name$5 cmb_1��5  |   0 .  $1 Main Screen��6�   6   Content.6 6�   Genel Takip Ekranı6�   5  /   �� 5  .   $��1��66   $��1��6F   
�������$��
10,8,10,10q�6g   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5  2     -   5        $5 cmb_2��5  {   0 .  $1 
Add Record��6�   .6 6�   Yeni Kayıt Ekleme6�   5  /   �� 5  .   $��2��66   $��1��6F   
�������$��
10,8,10,10q�6f   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5  2     -   5        $5 cmb_3��5  {   0 .  $1 Edit Record��6�   .6 6�   Kayıt Düzenleme6�   5  /   �� 5  .   $��3��67   $��1��6G   
�������$��
10,8,10,10q�6g   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5  2     -   5        $5 cmb_4��5  z   0 .  $1 All Records��6�   .6 6�   " Bütün Kayıtları Görüntüle6�   5   /   �� 5!  .   $��0��67   $��3��6G   
�������$��
10,8,10,10q�6g   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5"  2     -   5        $5 cmb_5��5"  z   0 .  $1 Can Print Main Screen��6�   .6 6�    Genel Takip Ekranı Rapor Alma6�   5#  /   �� 5&  .   $��1��65   $��3��6E   
�������$��
10,8,10,10q�6e   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5'  2     -   5        $5 cmb_6��5'  {   0 .  $1 File Screen��6�   .6 6�   Dosya Takip Ekranı6�   5(  /   �� 5)  .   $��2��66   $��3��6F   
�������$��
10,8,10,10q�6g   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5*  2     -   5        $5 cmb_7��5*  {   0 .  $1 Create File��6�   .6 6�   Dosya Kayıt Oluştur6�   5+  /   �� 5,  .   $��3��66   $��3��6F   
�������$��
10,8,10,10q�6f   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5-  2     -   5        $5 cmb_8��5-  {   0 .  $1 Download File��6�   .6 6�   Dosya İndirme6�   5.  /   �� 5/  .   $��0��67   $��5��6G   
�������$��
10,8,10,10q�6g   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�50  2     -   5        $5 cmb_9��50  {   0 .  $1 Delete File��6�   .6 6�   Dosya Silme6�   51  /   �� 52  .   $��1��67   $��5��6G   
�������$��
10,8,10,10q�6g   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�53  2     -   5        $5 cmb_10��53  {   0 .  $1 
File Print��6�   .6 6�   Dosya Kayıt Rapor Alma6�   54  /   �� 57  .   $��2��65   $��5��6E   
�������$��
10,8,10,10q�6e   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�58  2     -    5        $5 cmb_11��58  {   0 .  $1 Reminding Screen��6�   .6 6�   Hatırlatma Ekranı6�   59  /   �� 5:  .   $��3��66   $��5��6F   
�������$��
10,8,10,10q�6g   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5;  2     -!   5        $5 cmb_12��5;  {   0 .  $1 Add Reminding��6�   .6 6�   Hatırlatma Ekle6�   5<  /   �� 5=  .   $��0��66   $��7��6F   
�������$��
10,8,10,10q�6f   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5>  2     -"   5        $5 cmb_13��5>  {   0 .  $1 Edit Reminding��6�   .6 6�   Hatırlatma Düzenle6�   5?  /   �� 5@  .   $��1��67   $��7��6G   
�������$��
10,8,10,10q�6g   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5A  2     -#   5        $5 cmb_14��5A  {   0 .  $1 All Remindings��6�   .6 6�   '%Bütün Hatırlatmaları Görüntüle6�   5B  /   �� 5C  .   $��2��67   $��7��6G   
�������$��
10,8,10,10q�6g   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5D  2     -$   5        $5 cmb_15��5D  {   0 .  $1 Can Print Reminding��6�   .6 6�   Hatırlatma Rapor Alma6�   5E  /   �� 5H  .   $��3��65   $��7��6E   
�������$��
10,8,10,10q�6e   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5I  2     -%   5        $5 cmb_16��5I  |   0 .  $1 Daily Purchase��6�   .6 6�   Günlük Satın Alma6�   5J  /   �� 5K  .   $��0��65   $��9��6E   
�������$��
10,8,10,10q�6e   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5L  2     -&   5        $5 cmb_17��5L  |   0 .  $1 Daily Purchase Print��6�   .6 6�   !Günlük Satın Alma Rapor Alma6�   5M  /   �� 5N  .   $��1��66   $��9��6F   
�������$��
10,8,10,10q�6g   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5O  2     -'   5        $5 cmb_18��5O  {   0 .  $1 Daily Sales��6�   .6 6�   Günlük Satış6�   5P  /   �� 5Q  .   $��2��66   $��9��6F   
�������$��
10,8,10,10q�6f   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5R  2     -(   5        $5 cmb_19��5R  {   0 .  $1 Daily Sales Print��6�   .6 6�   Günlük Satış Rapor Alma6�   5S  /   �� 5T  .   $��3��66   $��9��6F   
�������$��
10,8,10,10q�6f   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5U  2     -)   5        $5 cmb_20��5U  {   0 .  $1 Monthly Purchase��6�   .6 6�   Aylık Satın Alma6�   5V  /   �� 5W  .   $��0��66   $��11��6F   
�������$��
10,8,10,10q�6g   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5X  2     -*   5        $5 cmb_21��5X  {   0 .  $1 Monthly Purchase Print��6�   .6 6�   Aylık Satın Alma Rapor Alma6�   5Y  /   �� 5Z  .   $��1��67   $��11��6G   
�������$��
10,8,10,10q�6h   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5[  2     -+   5        $5 cmb_22��5[  {   0 .  $1 Monthly Sales��6�   .6 6�   Aylık Satış6�   5\  /   �� 5]  .   $��2��67   $��11��6G   
�������$��
10,8,10,10q�6h   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5^  2     -,   5        $5 cmb_23��5^  {   0 .  $1 Monthly Sales Print��6�   .6 6�   Aylık Satış Rapor Alma6�   5_  /   �� 5c  .   $��3��65   $��11��6E   
�������$��
10,8,10,10q�6f   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5d  2     --   5        $5 cmb_24��5d  {   0 .  $1 Stock Screen��6�   .6 6�   Stok Takip Ekranı6�   5e  /   �� 5f  .   $��0��66   $��13��6F   
�������$��
10,8,10,10q�6h   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5g  2     -.   5        $5 cmb_25��5g  z   0 .  $1 	Add Stock��6�   .6 6�   	Stok Ekle6�   5h  /   �� 5i  .   $��1��66   $��13��6F   
�������$��
10,8,10,10q�6g   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5j  2     -/   5        $5 cmb_26��5j  {   0 .  $1 
Edit Stock��6�   .6 6�   Stok Güncelle6�   5k  /   �� 5l  .   $��2��67   $��13��6G   
�������$��
10,8,10,10q�6h   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5m  2     -0   5        $5 cmb_27��5m  {   0 .  $1 Active Stock Movement��6�   .6 6�   Aktif Stok Hareketi6�   5n  /   �� 5o  .   $��3��67   $��13��6G   
�������$��
10,8,10,10q�6h   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5p  2     -1   5        $5 cmb_28��5p  {   0 .  $1 Active Stock Movement��6�   .6 6�   Stok Takip Ekranı Rapor Alma6�   5q  /   �� 5u  .   $��0��65   $��15��6F   
�������$��
10,8,10,10q�6g   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5v  2     -2   5        $5 cmb_29��5v  {   0 .  $1 Monthly Analysis��6�   .6 6�   Aylık Analiz6�   5w  /   �� 5x  .   $��1��65   $��15��6F   
�������$��
10,8,10,10q�6g   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5y  2     -3   5        $5 cmb_30��5y  {   0 .  $1 Monthly Analysis Print��6�   .6 6�   Aylık Analiz Rapor Alma6�   5z  /   �� 5{  .   $��2��66   $��15��6F   
�������$��
10,8,10,10q�6h   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5|  2     -4   5        $5 cmb_31��5|  {   0 .  $1 Yearly Analysis��6�   .6 6�   Yıllık Analiz6�   5}  /   �� 5~  .   $��3��65   $��15��6F   
�������$��
10,8,10,10q�6g   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5  2     -5   5        $5 cmb_32��5  {   0 .  $1 Yearly Analysis Print��6�   .6 6�   Yıllık Analiz Rapor Alma6�   5�  /   �� 5�  .   $��0��66   $��17��6F   $��2��6T   
�������$��
10,8,10,10q�6|   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5�  2     -6   5        $5 cmb_33��5�  {   0 .  $1 Salesman Analysis��6�   .6 6�   Personel Analiz6�   5�  /   �� 5�  .   $��2��65   $��17��6F   
�������$��2��6g   $��
10,8,10,10q�6{   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5�  2     -7   5        $5 cmb_34��5�  {   0 .  $1 Salesman Analysis Print��6�   .6 6�   Personel Analiz Rapor Alma6�   5�  /   �� 5�  .   $��0��65   $��19��6E   
�������$��
10,8,10,10q�6f   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5�  2     -8   5        $5 cmb_35��5�  {   0 .  $1 File Path Screen��6�   .6 6�   Dosya Uzantı Takip Ekranı6�   5�  /   �� 5�  .   $��1��65   $��19��6E   
�������$��
10,8,10,10q�6f   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5�  2     -9   5        $5 cmb_36��5�  {   0 .  $1 Edit File Path��6�   .6 6�   Dosya Yolu Düzenle6�   5�  /   �� 5�  .   $��2��66   $��19��6F   
�������$��
10,8,10,10q�6h   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5�  2     -:   5        $5 cmb_37��5�  {   0 .  $1 Target Screen��6�   .6 6�   Hedef Ayarlama Ekranı6�   5�  /   �� 5�  .   $��3��66   $��19��6F   
�������$��
10,8,10,10q�6h   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5�  2     -;   5        $5 cmb_38��5�  {   0 .  $1 Edit Tarket��6�   .6 6�   Hedef Düzenleme6�   5�  /   �� 5�  .   $��0��66   $��21��6F   
�������$��
10,8,10,10q�6g   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5�  2     -<   5        $5 cmb_39��5�  {   0 .  $1 
Log Screen��6�   .6 6�   İşlem Kayıt Görüntüle6�   5�  /   �� 5�  .   $��1��65   $��21��6E   
�������$��
10,8,10,10q�6f   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5�  2     -=   5        $5 cmb_40��5�  {   0 .  $1 User Screen��6�   .6 6�   Kullanıcıları Görüntüle6�   5�  /   �� 5�  .   $��2��66   $��21��6F   
�������$��
10,8,10,10q�6h   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5�  2     ->   5        $5 cmb_41��5�  {   0 .  $1 Add User��6�   .6 6�   Kullanıcı Ekle6�   5�  /   �� 5�  .   $��3��66   $��21��6F   
�������$��
10,8,10,10q�6g   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5�  2     -?   5        $5 cmb_42��5�  {   0 .  $1 	Edit User��6�   .6 6�   Kullanıcı Güncelle6�   5�  /   �� 5�  .   $��0��67   $��23��6G   
�������$��
10,8,10,10q�6h   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5�  2     -@   5        $5 cmb_43��5�  {   0 .  $1 Delete User��6�   .6 6�   Kullanıcı Sil6�   5�  /   �� 5�  .   $��1��67   $��23��6G   
�������$��
10,8,10,10q�6h   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5�  2     -A   5        $5 cmb_44��5�  {   0 .  $1 
User Print��6�   .6 6�   Kullanıcı Rapor Alma6�   5�  /   �� 5�  .   $��2��65   $��23��6E   
�������$��
10,8,10,10q�6f   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5�  2     -B   5        $5 cmb_45��5�  {   0 .  $1 Salesman Screen��6�   .6 6�   '%Satş Görevli Ekranı Görüntüleme6�   5�  /   �� 5�  .   $��3��66   $��23��6F   
�������$��
10,8,10,10q�6h   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5�  2     -C   5        $5 cmb_46��5�  {   0 .  $1 Salesman Add��6�   .6 6�   Satş Görevlisi Ekleme6�   5�  /   �� 5�  .   $��0��66   $��25��6F   
�������$��
10,8,10,10q�6g   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5�  2     -D   5        $5 cmb_47��5�  {   0 .  $1 Salesman Update��6�   .6 6�   Satş Görevlisi Güncelleme6�   5�  /   �� 5�  .   $��1��67   $��25��6G   
�������$��
10,8,10,10q�6h   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5�  2     -E   5        $5 cmb_48��5�  {   0 .  $1 Salesman Delete��6�   .6 6�   Satş Görevlisi Silme6�   5�  /   �� 5�  .   $��2��67   $��25��6G   
�������$��
10,8,10,10q�6h   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5�  2     -F   5        $5 cmb_49��5�  {   0 .  $1 Salesman Print��6�   .6 6�   %#Satış Görevli Ekranı Rapor Alma6�   5�  /   �� 5�  .   $��3��65   $��25��6E   
�������$��
10,8,10,10q�6f   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5�  2     -G   5        $5 cmb_50��5�  {   0 .  $1 Type Screen��6�   .6 6�   Tür Ekranı Görüntüleme6�   5�  /   �� 5�  .   $��0��66   $��27��6F   
�������$��
10,8,10,10q�6h   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5�  2     -H   5        $5 cmb_51��5�  {   0 .  $1 Type Add��6�   .6 6�   Tür Ekleme6�   5�  /   �� 5�  .   $��1��66   $��27��6F   
�������$��
10,8,10,10q�6g   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5�  2     -I   5        $5 cmb_52��5�  {   0 .  $1 Type Update��6�   .6 6�   Tür Güncelleme6�   5�  /   �� 5�  .   $��2��67   $��27��6G   
�������$��
10,8,10,10q�6h   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5�  2     -J   5        $5 cmb_53��5�  {   0 .  $1 Type Delete��6�   .6 6�   
Tür Silme6�   5�  /   �� 5�  .   $��3��67   $��27��6G   
�������$��
10,8,10,10q�6h   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5�  2     -K   5        $5 cmb_54��5�  {   0 .  $1 
Type Print��6�   .6 6�   Tür Ekranı Rapor Alma6�   5�  /   �� 5�  .   $��0��66   $��29��6F   
�������$��
10,8,10,10q�6h   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5�  2     -L   5        $5 cmb_55��5�  {   0 .  $1 Product Screen��6�   .6 6�   %#Ürün Detay Ekranı Görüntüleme6�   5�  /   �� 5�  .   $��1��66   $��29��6F   
�������$��
10,8,10,10q�6h   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5�  2     -M   5        $5 cmb_56��5�  {   0 .  $1 Product Add��6�   .6 6�   Ürün Detay Ekleme6�   5�  /   �� 5�  .   $��2��66   $��29��6F   
�������$��
10,8,10,10q�6g   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5�  2     -N   5        $5 cmb_57��5�  {   0 .  $1 Product Update��6�   .6 6�   Ürün Detay Güncelleme6�   5�  /   �� 5�  .   $��3��67   $��29��6G   
�������$��
10,8,10,10q�6h   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5�  2     -O   5        $5 cmb_58��5�  {   0 .  $1 Product Delete��6�   .6 6�   Ürün Detay Silme6�   5�  /   �� 5�  .   $��0��67   $��31��6G   
�������$��
10,8,10,10q�6h   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5�  2     -P   5        $5 cmb_59��5�  {   0 .  $1 Product Print��6�   .6 6�   !Ürün Detay Ekranı Rapor Alma6�   5�  /   �� 5�  .   $��1��65   $��31��6E   
�������$��
10,8,10,10q�6f   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5�  2     -Q   5        $5 cmb_60��5�  {   0 .  $1 Company Screen��6�   .6 6�   $"Firma Takip Ekranı Görüntüleme6�   5�  /   �� 5�  .   $��2��66   $��31��6F   
�������$��
10,8,10,10q�6h   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5�  2     -R   5        $5 cmb_61��5�  {   0 .  $1 Company Add��6�   .6 6�   Firma Ekleme6�   5�  /   �� 5�  .   $��3��66   $��31��6F   
�������$��
10,8,10,10q�6g   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5�  2     -S   5        $5 cmb_62��5�  {   0 .  $1 Company Update��6�   .6 6�   Firma Güncelleme6�   5�  /   �� 5�  .   $��0��67   $��33��6G   
�������$��
10,8,10,10q�6h   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5�  2     -T   5        $5 cmb_63��5�  {   0 .  $1 Company Delete��6�   .6 6�   Firma Silme6�   5�  /   �� 5�  .   $��1��67   $��33��6G   
�������$��
10,8,10,10q�6h   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5�  2     -U   5        $5 cmb_64��5�  {   0 .  $1 Company Print��6�   .6 6�    Firma Takip Ekranı Rapor Alma6�   5�  /   �� 5�  .   $��2��65   $��33��6E   
�������$��
10,8,10,10q�6f   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5�  2     -V   5        $5 cmb_65��5�  {   0 .  $1 Costumer Screen��6�   .6 6�   (&Müşteri Takip Ekranı Görüntüleme6�   5�  /   �� 5�  .   $��3��66   $��33��6F   
�������$��
10,8,10,10q�6h   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5�  2     -W   5        $5 cmb_66��5�  {   0 .  $1 Costumer Add��6�   .6 6�   Müşteri Ekleme6�   5�  /   �� 5�  .   $��0��66   $��35��6F   
�������$��
10,8,10,10q�6g   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5�  2     -X   5        $5 cmb_67��5�  {   0 .  $1 Costumer Update��6�   .6 6�   Müşteri Güncelleme6�   5�  /   �� 5�  .   $��1��67   $��35��6G   
�������$��
10,8,10,10q�6h   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5�  2     -Y   5        $5 cmb_68��5�  {   0 .  $1 Costumer Delete��6�   .6 6�   Müşteri Silme6�   5�  /   �� 5�  .   $��2��67   $��35��6G   
�������$��
10,8,10,10q�6h   
���   �$��1q�6�   $. 7��6�   $/ 5q�6�   ._�5�  2     -Z   5        $5 cmb_69��5�  {   0 .  $1 Costumer Print��6�   .6 6�   $"Müşteri Takip Ekranı Rapor Alma6�   5�  /   5�  +   5  '   5  #   5     5     �� 5     ���	#FFFAFAFA$��6��69   $��1��6F   $. 19��6V   $/ 0q�6h   ._�5     � 	 5	  "   �� 5
  &   �� 5  &   �� 5  &   �� 5  &   .+�5  "     -[   5        $3 	btnkayıt��5  V     btnsave#��[ 63   $��3��6h   $��25��6x   $	��120��6�   $��Right=�6�   $��0,0,10,0q�6�   6�     5  "   -\   5        $3 btngüncelle��5  W     	btnupdate#��[ 63   $��3��6l   $��25��6|   $	��120��6�   $��Right=�6�   $��0,0,10,0q�6�   6�     5  "   -]   5        $3 buttonvazgec��5  W     	btngoback#��[ 63   $��	10,0,10,0q�6�   $��0��6�   $
��Left=�6�   $��25��6�   $	��120��6�   6�   5     5     5     5     5     5     5     5     