   M S B A M L   `   `   `  ����L  HSrednja_skola_HCI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Srednja_skola_HCI.FormsSrednja_skola_HCI.Forms  5   	   ?$clr-namespace:Srednja_skola_HCI.UtilSrednja_skola_HCI.Util  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   
   5clr-namespace:Srednja_skola_HCISrednja_skola_HCI  5	   
   Z VDataGridExtensions, Version=2.5.13.0, Culture=neutral, PublicKeyToken=43de855f87de903aS<clr-namespace:DataGridExtensions;assembly=DataGridExtensionsDataGridExtensions 5
   	   0    *Srednja_skola_HCI.Forms.RadiProvjeruWindow   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Srednja_skola_HCI.Forms     5   	   2p$clr-namespace:Srednja_skola_HCI.Util     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   
   .tbclr-namespace:Srednja_skola_HCI     5	   
   Ldgx<clr-namespace:DataGridExtensions;assembly=DataGridExtensions     5
   	     � Title$  RadiProvjeruWindow��5   	    � SizeToContent$ WidthAndHeight=�6$    � WindowStartupLocation$ CenterScreen=�6C    � WindowStyle$
 None=�6h    � 
ResizeMode$ NoResize=�6{    � AllowsTransparency$
 True��5   	    � 	Resources 5         ImageButton �� 
TargetType �� Property	 �� Value
 �� 
TargetType S� 
MethodName S� 
ObjectTypeU QSystem.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a  System.Enum  GetEnumValues S� MethodParameters M� TypeName��%K  &	        &	 �     �� 5   
   " ��6$   .�5      ��  � ��
	 ���� 6+   �� 5       � ��	 5      �� 5      "
 ��6&   .R�5      � #��z��6   .+�5      �� 5      5      5      5      S� 5   
   $ 	GetValues��6   "  64    5      M� 5      $ local:Ocjena��6   5       5"      .��5#      �� ._�5$   
   �   	GridStyle#���  6    � RowDefinitions 5%      �� 5&      $��48 �6    �� 5'      $��1 �6    �� 5(      .+�5*      � $��0��6   .+�5+      )   #Srednja_skola_HCI.TopBarUserControl  -   5          Name$ Header��5+   (   6:   5,      � 5-      $��1��6     SeparatorColor#���  6    � 5.      $��2��6   .+�5/      &   System.Windows.Controls.DataGrid  -   5        $��radiProvjeruDG��5/         AutoGenerateColumns$ False��50         CanUserAddRows$ False��6+      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6C    �� 
GroupStyle 51   
   (  "System.Windows.Controls.GroupStyle  53         ContainerStyle 54      �� 55      " ��6   .�56      ��  � ��$	 0,0,0,5q�63   �� 57       � ��	 58      �� 59   "   "
 ��62   .R�5:   &   9�  9� 
IsExpanded$
 True��6/   
�������
���   �$��1,1,1,5q�6g   ��5;   *   �� 5<   .   $
��Bold"�68   $	��100��6�   $
��Left=�6�   $��5,0,0,0q�6�   ��6J   �� *64Items[0].Provjera.PredmetNaSmjeru.Predmet.IdPredmeta+6�   ��5>   *   �� 5?   .   5A   '   5B   #   5D      5E      5G         Columns 5I   
   0  *System.Windows.Controls.DataGridTextColumn  5J      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly$
 True��6�      Header 6!   )   #Srednja_skola_HCI.Util.LocExtension  *NazivPredmetaHeader+1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6F   �� *(&Provjera.PredmetNaSmjeru.Predmet.Naziv+6�     5L      $
 True��6b    6!     *DatumHeader+ 6>   �� *Provjera.Datum+6b     5M      $
 True��6f    6!     *	TipHeader+ 6<   �� *Provjera.TipProvjere+6f   4
  .System.Windows.Controls.DataGridComboBoxColumn
  5N       6%     *OcjenaHeader+ 
  ItemsSource 6C   ��  �� Source# [  
  SelectedValueBinding 6�   ��  �� Path$ Ocjena�   RowValidationRules 5Q      1   +Srednja_skola_HCI.Forms.SkolaValidationRule  5R      ,  &System.Windows.Controls.ValidationRule    ValidationStep$  UpdatedValue=�64   !!   RowValidationErrorTemplate! 5U      �� 5V      .R�5W      � $��	0,-2,0,-2q�6#   " � ToolTip" 5X      �� # �� RelativeSource# �� *FindAncestor+$ �� AncestorType)  #System.Windows.Controls.DataGridRow"$  $) #(Validation.Errors)[0].ErrorContent�.+�5[   "   �� $��/Resources/error.png��6(   $��0q�5\      $��11��5]      $��11��6   " 5[   F   �� # �� *FindAncestor+"$  $) #(Validation.Errors)[0].ErrorContent�5]      5^      5_      5a      5c      5d      5e      5f      