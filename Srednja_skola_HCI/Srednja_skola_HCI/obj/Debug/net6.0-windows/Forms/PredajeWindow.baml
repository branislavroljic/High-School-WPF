   M S B A M L   `   `   `  ����L  HSrednja_skola_HCI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Srednja_skola_HCI.FormsSrednja_skola_HCI.Forms  5   	   ?$clr-namespace:Srednja_skola_HCI.UtilSrednja_skola_HCI.Util  5   	   5clr-namespace:Srednja_skola_HCISrednja_skola_HCI  5	   
   Z VDataGridExtensions, Version=2.5.13.0, Culture=neutral, PublicKeyToken=43de855f87de903aS<clr-namespace:DataGridExtensions;assembly=DataGridExtensionsDataGridExtensions 5
   	   +    %Srednja_skola_HCI.Forms.PredajeWindow   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Srednja_skola_HCI.Forms     5   	   2p$clr-namespace:Srednja_skola_HCI.Util     5   	   .tbclr-namespace:Srednja_skola_HCI     5	   
   Ldgx<clr-namespace:DataGridExtensions;assembly=DataGridExtensions     5
   	     � Title$  PredajeWindow��5   	    � SizeToContent$ WidthAndHeight=�6    � WindowStartupLocation$ CenterScreen=�6>    � WindowStyle$
 None=�6c    � 
ResizeMode$ NoResize=�6v    � AllowsTransparency$
 True��5   	   .��5      �� ._�5   
   �    	GridStyle#���   6    � RowDefinitions 5      �� 5      $��48 �6    �� 5      $��1 �6    �� 5      .+�5      � $��0��6   .+�5      )   #Srednja_skola_HCI.TopBarUserControl  -   5          Name$ Header��5   '   69   5      � 5      $��1��6     SeparatorColor#���  6    � 5      $��2��6   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��	predajeDG��5         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6,   	   AutoGenerateColumns$	 False��5      '  !DataGridExtensions.DataGridFilter
   IsAutoFilterEnabled$

 True��6+      CanUserAddRows$
 True��6Y      Columns 5      4  .System.Windows.Controls.DataGridComboBoxColumn  5      -   5        
ProfJMBCMB��   SelectedValuePath$	 JMB��5          DisplayMemberPath$	 JMB��5!      ,  &System.Windows.Controls.DataGridColumn   Header 5   2   )   #Srednja_skola_HCI.Util.LocExtension  *	JMBHeader+   SelectedValueBinding 5      �� *Profesor.Osoba.JMB+5!      0  *System.Windows.Controls.DataGridTextColumn  5"       6-     *BrojSedmicnihCasovaHeader+1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6X   �� *BrojSedmicnihCasova+ �� ValidatesOnExceptions$
 True��4
  .System.Windows.Controls.DataGridTemplateColumn
  5#       
  CellTemplate 5$      �� 5%   "   .R�5&   &   �� -   5          ImageButton#��[ 5&   -    � Cursor$
 Hand��6i   ��5'   *   �� 5(   .    �� ImageSource$! /Resources/delete-24x24.png��69    j� Stretch$ Uniform=�6c   5*   '   5+   #   5-      5/      51      52      53      54      