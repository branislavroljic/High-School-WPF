   M S B A M L   `   `   `  ����L  HSrednja_skola_HCI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Srednja_skola_HCI.DialogsSrednja_skola_HCI.Dialogs  5   	   ?$clr-namespace:Srednja_skola_HCI.UtilSrednja_skola_HCI.Util  5   
   5clr-namespace:Srednja_skola_HCISrednja_skola_HCI  5	   
   +    %Srednja_skola_HCI.Dialogs.YesNoDialog   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:Srednja_skola_HCI.Dialogs     5   	   2p$clr-namespace:Srednja_skola_HCI.Util     5   
   .tbclr-namespace:Srednja_skola_HCI     5	   
     � Title$  YesNoDialog��5
   	   $	��150��6   $	��250��6*    � WindowStartupLocation$ CenterScreen=�66    � WindowStyle$
 None=�6[    � 
ResizeMode$ NoResize=�6n    � AllowsTransparency$
 True��5   	   
�������.��5      �� ._�5   
   �    	GridStyle#���   6    � RowDefinitions 5      �� 5      $��48 �6    �� 5      $��1 �6    �� 5      .+�5      � $��0��6   .+�5      )   #Srednja_skola_HCI.TopBarUserControl  6*   5      � 5      $��1��6     SeparatorColor#���  6    �� 5      $��2��6   .+�5      �� -   5        $��
questionTB��5   i   $��WrapWithOverflow=�6    �� Left$ 21��6<   
 �� Top$ 10��6M   $	��198��6]   Tekst6�   �� 5      -   5        $��btnDialogOk��5   *    �� 	IsDefault$
 True��6   $��60��6W   $ 95��6e   $ 71��6v   .��6�   OK6�   �� 5      -   5        $��btnDialogCancel��5   )   	 �� IsCancel$
	 True��6   $ 71��6@   $��60��6P   $	 165��6^   ��6p   )   #Srednja_skola_HCI.Util.LocExtension  *CancelButton+6�   5      5      5      5      