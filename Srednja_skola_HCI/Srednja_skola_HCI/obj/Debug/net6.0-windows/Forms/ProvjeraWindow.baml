   M S B A M L   `   `   `  ����L  HSrednja_skola_HCI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Srednja_skola_HCI.FormsSrednja_skola_HCI.Forms  5   	   ?$clr-namespace:Srednja_skola_HCI.UtilSrednja_skola_HCI.Util  5   	   Z VDataGridExtensions, Version=2.5.13.0, Culture=neutral, PublicKeyToken=43de855f87de903aS<clr-namespace:DataGridExtensions;assembly=DataGridExtensionsDataGridExtensions 5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5	   
   5clr-namespace:Srednja_skola_HCISrednja_skola_HCI  5
   
   ,    &Srednja_skola_HCI.Forms.ProvjeraWindow   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Srednja_skola_HCI.Forms     5   	   2p$clr-namespace:Srednja_skola_HCI.Util     5   	   Ldgx<clr-namespace:DataGridExtensions;assembly=DataGridExtensions     5   	   6sys&clr-namespace:System;assembly=mscorlib     5	   
   .tbclr-namespace:Srednja_skola_HCI     5
   
     � Title$  ProvjeraWindow��5   	    � SizeToContent$ WidthAndHeight=�6     � WindowStartupLocation$ CenterScreen=�6?    � WindowStyle$
 None=�6d    � 
ResizeMode$ NoResize=�6w    � AllowsTransparency$
 True��5   	    � 	Resources 5         ImageButton �� 
TargetType �� Property	 �� Value
 �� 
TargetType S� 
MethodName S� 
ObjectTypeU QSystem.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a  System.Enum  GetEnumValues S� MethodParameters M� TypeName��%P  &	        &	 �     �� 5   
   " ��6$   .�5      ��  � ��
	 ���� 6+   �� 5       � ��	 5      �� 5      "
 ��6&   .R�5      � #��z��6   .+�5      �� 5      5      5      5      S� 5   
   $ 	GetValues��6   "  64    5      M� 5      $ local:TipProvjere��6   5       5"      .��5#      �� ._�5$   
   �   	GridStyle#���  6    � RowDefinitions 5%      �� 5&      $��48 �6    �� 5'      $��1 �6    �� 5(      .+�5*      � $��0��6   .+�5+      )   #Srednja_skola_HCI.TopBarUserControl  -   5          Name$ Header��5+   (   6:   5,      � 5-      $��1��6     SeparatorColor#���  6    � 5.      $��2��6   .+�5/      &   System.Windows.Controls.DataGrid  -   5        $��
provjereDG��5/         AutoGenerateColumns$ False��50         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6,   '  !DataGridExtensions.DataGridFilter   IsAutoFilterEnabled$
 True��51         Columns 53      4  .System.Windows.Controls.DataGridTemplateColumn  54      ,  &System.Windows.Controls.DataGridColumn   Header 6%   )   #Srednja_skola_HCI.Util.LocExtension  *DatumHeader+   CellTemplate 55      �� 56      .R�57      (	  "System.Windows.Controls.DatePicker	  $��0q�6I    	  SelectedDate 6%   ��  �� Path$ Datum�6I   58      5:      0
  *System.Windows.Controls.DataGridTextColumn
  5;       6-     *RazredHeader+1  +System.Windows.Controls.DataGridBoundColumn   Binding 6K   �� *PredmetNaSmjeru.Razred+ �� ValidatesOnExceptions$
 True��
  5<       6!     *OdjeljenjeHeader+ 6C   �� *
Odjeljenje+$
 True��
  5=       6!     *NazivPredmetaHeader+ 6F   �� *PredmetNaSmjeru.Predmet.Naziv+
  5>       6!     *NazivSmjeraHeader+ 6D   �� *PredmetNaSmjeru.Smjer.Naziv+4  .System.Windows.Controls.DataGridComboBoxColumn  5?       6%     *	TipHeader+   ItemsSource 6@   ��  �� Source# [    SelectedValueBinding 6~   �� $ TipProvjere�
  5@       6!     *TrajanjeHeader+ 6A   �� *
Trajanje+$
 True��
  5A       6!     *BrojNegativnihHeader+ 6G   �� *BrojNegativnihOcjena+$
 True��
  5B       6!     *BrojPrisutnihHeader+ 6F   �� *BrojPrisutnihUcenika+$
 True��4  .System.Windows.Controls.DataGridCheckBoxColumn  5C       6%     *PonovljenaHeader+ 6G   �� *
Ponovljena+  5D       6%     *BrisanjeHeader+ 5E      �� 5F      .R�5G      �� -   5        #��[  5G   !    � Cursor$
 Hand��6\   ��5H      �� 5I   "    �� ImageSource$! /Resources/delete-24x24.png��6-     j� Stretch$  Uniform=�6W   5K      5L      5N      !   RowValidationRules! 5R      .   (Srednja_skola_HCI.Forms.RPValidationRule  5S      ,  &System.Windows.Controls.ValidationRule"   ValidationStep$" UpdatedValue=�61   !#   RowValidationErrorTemplate# 5V      �� 5W      .R�5X      � $��	0,-2,0,-2q�6#   $ � ToolTip$ 5Y      �� % �� RelativeSource% �� *FindAncestor+& �� AncestorType)  #System.Windows.Controls.DataGridRow"&  $) #(Validation.Errors)[0].ErrorContent�.+�5\   "   �� $��/Resources/error.png��6(   $��0q�5]      $��11��5^      $��11��6   $ 5\   F   �� % �� *FindAncestor+"&  $) #(Validation.Errors)[0].ErrorContent�5^      5_      5`      5b      5d      5e      5f      5g      