   M S B A M L   `   `   `  ����L  HSrednja_skola_HCI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Srednja_skola_HCI.FormsSrednja_skola_HCI.Forms  5   	   ?$clr-namespace:Srednja_skola_HCI.UtilSrednja_skola_HCI.Util  5   	   5clr-namespace:Srednja_skola_HCISrednja_skola_HCI  5   
   2    ,Srednja_skola_HCI.Forms.UcenikDetaljnoWindow   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Srednja_skola_HCI.Forms     5   	   2p$clr-namespace:Srednja_skola_HCI.Util     5   	   .tbclr-namespace:Srednja_skola_HCI     5   
     � Title$  UcenikDetaljnoWindow��5
   	    � SizeToContent$ WidthAndHeight=�6&    � WindowStartupLocation$ CenterScreen=�6E    � WindowStyle$
 None=�6j    � 
ResizeMode$ NoResize=�6}    � AllowsTransparency$
 True��5   	    � 	Resources 5      ��%    5      .��5      �� ._�5   
   �    	GridStyle#���   6    � RowDefinitions 5      �� 5      $��48 �6    �� 5      $��1 �6    �� 5      .+�5      � $��0��6   .+�5      )   #Srednja_skola_HCI.TopBarUserControl  -   5          Name$ Header��5   (   6:   5      � 5      $��1��6     SeparatorColor#���  6    � 5      $��2��6   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��uceniciDetaljnoDG��5      	   AutoGenerateColumns$	 False��5      
   CanUserAddRows$
 False��6+      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6C    �� 
GroupStyle 5      (  "System.Windows.Controls.GroupStyle  5          ContainerStyle 5!      �� 5"   "    �� 
TargetType" ��6(   .�5#   &   ��  �� Property � �� �� Value 5$   "   �� 5%   &    �� 
TargetType" ��66   .R�5&   2   9�  9� 
IsExpanded$
 True��6;     ExpanderBackgroundColor#���  6M     ExpanderForegroundColor#���  6�   $��1,1,1,5q�6�   ��5'   .   ]� 5(   2   .+�5)   6   �� $
��Bold"�6@   $��Comic Sans MS)�6s   $��5,0,0,0q�6�   ��6R   �� *Items[0].Smjer+6�   �� 5*   6   $
��Bold"�6@   $��Comic Sans MS)�6s   ��6R   �� *Items[0].Razred+6s   5,   3   ��5.   .   �� 5/   2   51   +   52   '   54      55      57        59         HeaderTemplate 5:      �� 5;   "   .R�5<   &   ]� 
������ .+�5=   *   �� $
��Bold"�64   $��30,0,0,0q�6�   $��Comic Sans MS)�6�   ��6G   �� *Items[0].Smjer+ �� StringFormat$ 
Smjer: {0}��6�   �� 5>   *   $
��Bold"�64    �� Padding$ 5,0,0,0q�6�   $��Comic Sans MS)�6�   ��6F   �� *Items[0].Razred+$ Razred: {0}��6�   5?   '   5@   #   5B         Columns 5D      0  *System.Windows.Controls.DataGridTextColumn  5E      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly$
 True��6X      Header 6%   )   #Srednja_skola_HCI.Util.LocExtension  *	JMBHeader+1  +System.Windows.Controls.DataGridBoundColumn   Binding 6@   �� *JMB+6X     5F      $
 True��6Y    6%     *	ImeHeader+ 6@   �� *Ime+6Y     5G      $
 True��6a    6%     *PrezimeHeader+ 6D   �� *	Prezime+6a     5H      $
 True��6b    6%     *NazivSkoleHeader+ 6G   �� *Skola+6b     5I      $
 True��6b    6%     *NazivSmjeraHeader+ 6H   �� *Smjer+6b     5J        DataGridCellCentered   ElementStyle# [ 6_   $
 True��6�    6%     *RazredHeader+ 6C   �� *Razred+6�     5K      # [ 6g   $
 True��6�    6%     *OdjeljenjeHeader+ 6G   �� *
Odjeljenje+6�     5L      # [ 6p   $
 True��6�    6-     *ProsjekOcjenaHeader+ 6R   �� *	Prosjek+6�   4	  .System.Windows.Controls.DataGridTemplateColumn	  5M       61     *OcjenaHeader+ 	  CellTemplate 5N      �� 5O   "   .R�5P   &   �� -   5        ��5P   -     *PogledajButton+5Q   '   5R   #   5T      5V      5X      5Y      5Z      5[      