   M S B A M L   `   `   `  ����B  >Лаб4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:Лаб4Лаб4  5   	       Лаб4.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Лаб4     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   �� -   5        $��Blur Effect��5
      $
��Left=�6'   $��	81,82,0,0q�6B   $	��Top=�6U   $��73��6m   $	��253��6y   $��40(�6�   $
��Bold"�6�    J� Effect 5      -  'System.Windows.Media.Effects.BlurEffect  5         Radius$ 3Q�6      
KernelType$ Gaussian=�6(      RenderingBias$ Performance=�6>   5      5      �� 5   
   -   5        $��Drop Shadow��5      $
��Left=�6'   $��
452,82,0,0q�6B   $	��Top=�6V   $��73��6n   $	��267��6z   $��40(�6�   $
��Bold"�6�    5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 15Q�6#      Color$
 Blue��63      ShadowDepth$ 10Q�6@      	Direction$ 45Q�6Q   	   Opacity$		 0.5Q�6`   6p   5      �� 5   
   -   5        
 ��Name$
 label��5      $��Здравствуй!��6   $��Center=�65   $��	0,217,0,0q�6R   $	��Top=�6e   $��45��6}   $	��202��6�   $��25(�6�   $
��Bold"�6�    5        5      $ 3Q�6   $ Gaussian=�6(   $ Performance=�6>   6\   5      �� 5    
   -   5         ��Name$ rect1��5       $
��Left=�6#   $��95��6>   $��
81,284,0,0q�6J   
���   �$	��Top=�6m   $	��114��6�   ��5!      �� 5"       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,1&�67   .��5#      �  � Color$ Black��6#    � Offset$ 0Q�61   � 5$      $	 red��6#   $	 0.5Q�6/   � 5%      $ White��6#   $ 1Q�61   5&      5(      �� 5+   
   $
��Left=�6   $��95��6/   $��250,284,0,0q�6;   
���   �$	��Top=�6_   $	��114��6w   ��5,      
� 5-       
� Center$ 0.5,0.75&�6&    
� GradientOrigin$ 0.5,0.1&�68   .��5.      � $ Black��6#   $ 0Q�61   � 5/      $	 red��6#   $	 0.8Q�6/   � 50      $ White��6#   $ 1Q�61   51      53      57      58      