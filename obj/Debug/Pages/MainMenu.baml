   M S B A M L   `   `   `  ����B  >AlgoVis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:AlgoVis.PagesAlgoVis.Pages  5          AlgoVis.Pages.MainMenu   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:AlgoVis.Pages     5        N� Title$  MainMenu��5	       � 	Resources 5         MainMenuButtonBrush �� 
StartPoint �� EndPoint � Color � Offset �� 
TargetType  FadeInBootleg �� Triggers :� RoutedEvent	 �� TargetProperty
 W� From	 W� To g� Duration  MainMenuButtonStyle �� Property �� Value �� 
TargetType �� CornerRadius �� Triggers P� Property P� Value �� 
TargetName p� KeyTime p� Value��%�  &	        &	 �     &	 �    7   7   �� 5   
   $	 0,0&�6:   $	 1,1&�6K   .��5      � $ 	#AAFFFF00��6   $	 .50Q�6-   � 5      $ 	#00FFFF00��6   $	 0.8Q�6-   5      �� 5   
   " ��6    5      :� 5      $ Shape.Loaded��6   .[�5      �� .��5      �� .��5      W� $	 (Image.Opacity)�6.   $	
 0.0X�6Z   $	 1.0X�6e   $ 0:0:5D�6n   5      5      5      5      �� 5   
   " ��6   .�5      ��  � ��8   6Z   �� 5       � ��$
 10 5q�6'   66   �� 5       � ��$ 0q�60   6<   �� 5       � �� 5       �� 5!      " ��6&   .R�5"      �� $��border��6!   $ 5��6/   $��0q�6@   ���	#00FFFFFF$
��10 5q�6k   ._�5#      �� $
��Left=�6/   $��Center=�6J   $��10 5 q�6e   5$       5%      P� 5&       �@J�IsMouseOver . . �5'   "   �� $ border��6?   8   � ��6S   5(      :� 5)      $ Button.MouseEnter��6+   [�5*   "   �� 5+   &   .��5,   *   �� .��5-   .   W� $	 (Border.Opacity)�5.   /   $	
 0.0X�5/   /   $	 1.0X�6:   $ 0:0:0.15D�6C   r� 50   .   $	 (ContentPresenter.Margin)�51   /   .	�52   2   �� $ 00:00:00��6J   $ 10, 5q�6]   �� 53   2   $ 
00:00:0.15��6J   $ 20, 5q�6_   54   /   55   +   56   '   58      :� 59      $ Button.MouseLeave��6+   [�5:   "   �� 5;   &   .��5<   *   �� .��5=   .   W� $	 (Button.Opacity)�5>   /   $ 1X�5?   /   $ 0:0:0.1D�66   r� 5@   .   $	 (ContentPresenter.Margin)�5A   /   .	�5B   2   �� $ 00:00:00��6J   $ 20, 5q�6]   �� 5C   2   $ 	00:00:0.1��6J   $ 10, 5q�6^   5D   /   5E   +   5F   '   5H      5L      5N      5O      5P      .��5Q      �  � ColumnDefinitions 5R   
   �� 5S      $
��0.5* �6   6.   �� 5T      $��3* �6   6,   �� 5U      $	��10* �6   6-    � RowDefinitions 5W   
   �� 5X      $��5* �6   6*   �� 5Y      $��5* �6   6*   �� 5Z      $��* �6   6)   .+�5\   
   �� $��1��6   $��1��6"   .+�5]      �� -   5        $
��Play��5]      #��[ 6&   $��15(�6S   $��Georgia)�6h   6}   �� 5^      $��Abandon Run��6   #��[ 6-   $��15(�6Z   $��Georgia)�6h   �� 5_      $��
Collection��6   #��[ 6,   $��15(�6Y   $��Georgia)�6h   �� 5`      $��
Statistics��6   #��[ 6,   $��15(�6Y   $��Georgia)�6h   �� 5a      $��Settings��6   #��[ 6*   $��15(�6W   $��Georgia)�6h   �� 5b      $
��Quit��6   #��[ 6&   $��15(�6S   $��Georgia)�6h   5c      �� 5d   
   $��0��6   $��3��6   $��2��6.   $&�� ../Images/MainMenuLogos/Logo.png��6>   6j   �� 5e   
   $��0��6   $��3��6   $��2��6.   $-��'../Images/MainMenuLogos/LogoBootleg.png��6>   #��[ 6o   6�   �� 5f   
   $��2��6   $��1��6!   $��Version 1e15+inf[nan]��61   $��0 20 0 0q�6N   
�������6`   5g      5h      