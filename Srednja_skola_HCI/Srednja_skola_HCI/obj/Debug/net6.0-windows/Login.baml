   M S B A M L   `   `   `  ����L  HSrednja_skola_HCI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Srednja_skola_HCI.FormsSrednja_skola_HCI.Forms  5   	   ?$clr-namespace:Srednja_skola_HCI.UtilSrednja_skola_HCI.Util  5   
   5clr-namespace:Srednja_skola_HCISrednja_skola_HCI  5   
   #    Srednja_skola_HCI.Forms.Login   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Srednja_skola_HCI.Forms     5   	   2p$clr-namespace:Srednja_skola_HCI.Util     5   
   .tbclr-namespace:Srednja_skola_HCI     5   
     � Title$  Login��5
   	   $	��450��6   $	��300��6$    � WindowStartupLocation$ CenterScreen=�60    � WindowStyle$
 None=�6U    � 
ResizeMode$ NoResize=�6h    � AllowsTransparency$
 True��5   	   
�������.��5      �� ._�5   
   �  � RowDefinitions 5      �� 5      $��48 �6    �� 5      $��1 �6    �� 5      .+�5      � $��0��6   .+�5      )   #Srednja_skola_HCI.TopBarUserControl  -   5          Name$ Header��5   '   69   5      � 5      $��1��6      SeparatorColor#���   6    � 5      $��2��6   .+�5      �� -   5         ��Name$
 Mail��5      $��101,19,24,354q�6(   $��14(�6?   $��Center=�6M   ���	#FFDAF2FF6�   �� 5      -   5         ��Name$ loginPassword��5      $��Password��6/   $��25,67,204,310q�6B   $��Times New Roman)�6Y   $��14(�6v   G� 5       -   5        	 G�Name$	 Password��5       $��101,67,24,310q�60   $��14(�6G   $��Center=�6U   ���	#FFDAF2FF6�   �� 5"      $ ��/Resources/school-logo.png��6   $��
0,136,0,89q�6<   �� 5$      -   5        
 ��Name$
 loginButton��5$   '    � Cursor$
 Hand��6   $��Login��6<   $��36,353,24,20q�6L   ���	#FF092C5B���	#FFFBFBFB6�   �� 5&      -   5        $��ErrorMessage��5&      $��0,108,0,267q�6-   ���	#FFF1BCBC$y�Hidden=�6Y   .+�5'      �� $1��+Invalid mail or password! Please try again.��6   $	��254��6R   $��Italic$�6^   $��12(�6q   
���   � �� Left$ 36��6�   
 �� Top$ 3��6�   5(      �� 5)      $��E-mail��6   $
��Left=�6)   $��	29,21,0,0q�6D   $	��Top=�6W   $��Times New Roman)�6o   $��14(�6�   5*      5+      5,      5.      