   M S B A M L   `   `   `  ����L  HSrednja_skola_HCI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Srednja_skola_HCISrednja_skola_HCI  5   	   ?$clr-namespace:Srednja_skola_HCI.UtilSrednja_skola_HCI.Util  5   	   (    "Srednja_skola_HCI.MenuWindow_Admin   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Srednja_skola_HCI     5   	   2p$clr-namespace:Srednja_skola_HCI.Util     5   	   $	��450��5	   
   $	��300��6     � WindowStartupLocation$  CenterScreen=�6#    � WindowStyle$
 None=�6H    � 
ResizeMode$ NoResize=�6[    � AllowsTransparency$
 True��6q   .��5      �� ._�5   
   �    	GridStyle#���   6    � RowDefinitions 5      �� 5      $��48 �6    �� 5      $��1 �6    �� 5      .+�5      � $��0��6   .+�5      ��  �� Orientation$ 
Horizontal=�6   $
��Left=�66   $��Center=�6Q   $��8,0,0,0q�6l   $��40��6}   .+�5      �� -   5         ��Name$ Header��5       $��20(�60   $��8,2,0,0q�6>   $��Normal"�6O   $��Center=�6c   $��Center=�6�   $��Segoe WP)�6�   5      n� 5      -   5         J� Opacity$ 0Q�5      
������ ��6=   Z� 6S   �� 5      $ 
Horizontal=�6   $��Center=�66   $��Right=�6Q   $��0,0,8,0q�6m   .+�5      �� -   5        $��32��5      $��28��6)     ImageButton#��[ 65    � Cursor$
 Hand��6q   ��5      �� 5      	 �� ImageSource$	 /Resources/gears.png��6)   
 j� Stretch$
 Uniform=�6L   5      �� 5      -   5        $��32��5      $��28��6)   #��[ 65   $
 Hand��6n   ��5      �� 5       $ 	 /Resources/logout-icon.png��6)   $
 Uniform=�6R   5"      5$      5%      � 5&      $��1��6     SeparatorColor#���  6    � 5'      $��2��6   .+�5(      �� -   5        $
��Left=�5(   7   $��	91,55,0,0q�6R   $	��Top=�6e   $��26��6}   $	��123��6�   ��6   )   #Srednja_skola_HCI.Util.LocExtension  *SkoleButton+6�   �� 5)      -   5        $
��Left=�5)   :   $��
91,115,0,0q�6U   $	��Top=�6i   $��28��6�   $	��123��6�   ��6     *SmjeroviButton+6�   �� 5*      -   5        $
��Left=�5*   :   $��
91,171,0,0q�6U   $	��Top=�6i   $��29��6�   $	��123��6�   ��6     *PredmetiButton+6�   �� 5+      -   5        $
��Left=�5+   ;   $��
91,232,0,0q�6V   $	��Top=�6j    J� RenderTransformOrigin$ -0.391,0.794&�6�   $��25��6�   $	��123��6�   ��6     *ProfesoriButton+6�   �� 5-      $ ��/Resources/school-logo.png��6   $��	0,291,0,0q�6<   6Q   5.      5/      50      51      