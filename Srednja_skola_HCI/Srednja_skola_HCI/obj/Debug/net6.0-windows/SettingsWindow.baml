   M S B A M L   `   `   `  ����L  HSrednja_skola_HCI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Srednja_skola_HCISrednja_skola_HCI  5   	   ?$clr-namespace:Srednja_skola_HCI.UtilSrednja_skola_HCI.Util  5   
   5clr-namespace:Srednja_skola_HCISrednja_skola_HCI  5   
   &     Srednja_skola_HCI.SettingsWindow   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Srednja_skola_HCI     5   	   2p$clr-namespace:Srednja_skola_HCI.Util     5   
   .tbclr-namespace:Srednja_skola_HCI     5   
   $	��322��5
      $	��267��6     � WindowStartupLocation$  CenterScreen=�6    � WindowStyle$
 None=�6C    � 
ResizeMode$ NoResize=�6V    � AllowsTransparency$
 True��6l    � Triggers 5      :� 5   
    :� RoutedEvent$ FrameworkElement.Loaded��6   .[�5      ��  
  FadeIn#��[  6   5      .��5      �� ._�5   
   �   	GridStyle#���  6    � RowDefinitions 5      �� 5      $��48 �6    �� 5      $��1 �6    �� 5      .+�5      � $��0��6   .+�5      )   #Srednja_skola_HCI.TopBarUserControl  -   5          Name$ Header��5   '   69   5      � 5      $��1��6   
���iii�6    � 5      $��2��6   .+�5      �� -   5        $��Center=�5   9   $��	0,229,0,0q�6V   $	��Top=�6i   $��30��6�   $	��181��6�   ��6   )   #Srednja_skola_HCI.Util.LocExtension  *SacuvajButton+6�   	� 5      -   5         	�Name$
 EnRB��5      	 	� 	GroupName$
	 lang��6,   
 d� 	IsChecked$

 TrueY�6=   $��EN��6N   $
��Left=�6[   $��	56,61,0,0q�6v   $	��Top=�6�   	� 5       -   5        $
 SrRB��5       $
	 lang��6,   $��SR��6=   $
��Left=�6J   $��
182,61,0,0q�6e   $	��Top=�6y   �� 5!      $
��Left=�6   $��	95,17,0,0q�6Q   $	��Top=�6d   $
��Bold"�6}   $��16(�6�   ��63     *
JezikLabel+6�   	� 5"      -   5        $ DarkRB��5"      $	 theme��6.   $
��Left=�6Y   $	��Top=�6t   $��106,158,0,0q�6�   ��6@     *DarkRB+6�   	� 5#      -   5        $ WhiteRB��5#      $	 theme��6/   $

 TrueY�6\   $
��Left=�6n   $��
40,158,0,0q�6�   $	��Top=�6�   ��6A     *	WhiteRB+6�   	� 5$      -   5        $ BlueRB��5$      $	 theme��6/   $��Right=�6[   $��
0,158,27,0q�6w   $	��Top=�6�   ��6A     *	GreenRB+6�   �� 5%      $
��Left=�64   $��106,105,0,0q�6O   $	��Top=�6d   $
��Bold"�6|   $��16(�6�   ��6     *	TemaLabel+6�   5'      5(      5)      5*      