   M S B A M L   `   `   `  ����K  G106LibrarySystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:LibraryDatabaseLibraryDatabase  5      #    LibraryDatabase.AdminBrowsing   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7localControlsclr-namespace:LibraryDatabase     5        � 	Resources  5	          BooleanToVisibilityConverter  NormalBookTemplate �� 
TargetType J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   ShadowDepth   
BlurRadius   Opacity  HoverBookTemplate �� 
TargetType �� Triggers �� Binding	 �� RelativeSource
 �� AncestorType �� Value �� Property �� Value �� CornerRadius � DataContext  BookButtonStyle P� Property P� Value��%)  &	        &	      &	 �     &	 
    7  7  �� 5   
   6'   �� 5   
   " ��65   .R�5      �� 
������ $��0q�6.    5        5      $ 0Q�6'   $ 0Q�67   $ 0Q�6F   ._�5      �� 5      5      �� 5   
   " ��64   .R�5      �� 
������ $��0q�6.    5        5      $ 0Q�6'   $ 0Q�67   $ 0Q�6F   ._�5      � .+�5      �� ��5      �� 5      " ��6$    5   "   �� 5    &    62   �� *#!DataContext.IsRemoveButtonVisible+	 �� $
 UserControlL� True6�   .a�5!   *   ��  � y�$ 	Collapsed=�6G   5"   '   5$      .+�5&      �� 
�������$ 5��64   $��1q�6E   
�������._�5'      �� .+�5(   "   �� $	��100��6E   $	��150��6Q   $��0 0 0 10q�6^   ��6(   �� *	ImagePath+6^   �� 5)   "   $
��Bold"�6B   $��14(�6T   $
��Wrap=�6b   $��Center=�6v   ��6,   �� *name+6v   �� 5*   "   $��12(�6D   $��Center=�6R   ��6,   �� *author+6R   �� 5+   "   $��12(�6z   $
��Bold"�6�   $��Center=�6�   ��6,   �� *DisplayAvailability+��6Q   �� *AvailabilityColor+6�   5,      5-      5.      �� 5/      -   5        $��Remove Book��5/      $
��Bold"�63   $��15(�6E   
���  ��$��1��6�   $��0,5,5,5q�6�    6}   �� ��50      �� 51      " ��6$   .�52   "   ��  � y�$ 	Collapsed=�6?    53   "   �� 54   &    62   �� *#!DataContext.IsRemoveButtonVisible+	 �� $
 UserControlL� True6�   .a�55   *   ��  � y�$ Visible=�6G   56   '   58      5:      5;      5<      5=      �� 5@   
   " ��6(   .�5A      ��  � ��
 ���� 6+   �� 5B       � ��$ 0q�60   �� 5C       � ��8   6)    5D      P� 5E       �@J�IsMouseOver . . �5F      ��  � ��8  61   5G      5I      5K      .��5L      �  � ColumnDefinitions 5M   
   �� 5N      $	��150 �6   �� 5O      $��* �6    � RowDefinitions 5R   
   �� 5S      $��50 �6   �� 5T      $��20 �6   �� 5U      $��* �6   .+�5W   
   �� 
�������$��3��5X      $��3��5Y      �� 5Z   
    �� Orientation$ 
Horizontal=�6   $
��Left=�6.   $��1��5[      $��3��5\      .+�5]      �� $��Images/image 2.png��6   $��	20 0 10 0q�5^      �� 5_      -   5        
���   �
�������
�������$��13(�5c      $��100px��5d      $��20 5 5 5q�5e      .��6   Home6%   �� 5f      
���   �
�������
�������$��13(�5j      $��100px��5k      $��0 5 0 5q�5l      .��6   	Catalogue6)   �� 5m      
���   �
�������
�������$��13(�5q      $��100px��5r      $��0 5 0 5q�5s      .��6   	Support6'   �� 5t      $ 
Horizontal=�6   $��	200 0 0 0q�5u      .+�5v      �� $��Images/lang.png��6   $��0��5w      $��	20 0 10 0q�5x      $��3��5y      $��39��5z      $��52��5{      � 5|      $��40��6   $��40��5}      $��Center=�5~      $��Center=�5      $��	20 0 10 0q�5�      .+�5�      �� $��Images/profile.png��6   $��0��5�      $��3��5�      $��40��5�      $��34��5�      �� 5�      -   5        $��40��5�      
������ 
������ 5�      5�      5�      5�      �� 5�   
   ���	#FF011936$��10��6&   $	��Top=�62   $��3��6J   $��1��6^   �� 5�   
   ���	#FF00487C$��10��6&   $��0,10,0,0q�62   $	��Top=�6D   $��3��6\   $��1��6p   �� 5�   
   $��2��5�      $��0��5�      $��2��5�      .��5�      �� $ 
Horizontal=�6   .+�5�      �� ���	#FF011936$	��670��5�       $��2��5�       $��15 0 0 0q�5�       �� 5�      $��Center=�5�      $	��Top=�5�      $��	10,30,0,0q�5�      $	��700��5�      .+�5�      �� $
��Bold"�6    $��15(�62   Advanced Search6Q   �� 5�      $��0 5 0 10q�6!   .+�5�      �� $ 
Horizontal=�6%   $��0 0 0 10q�6>   .+�5�      �� 
������ $��11��6>   $��11��6J   $��0 10 0 0q�6U   6i   �� 5�      $��5 9 0 0q�6(   Available online6K   5�      �� 5�      $ 
Horizontal=�6%   $��0 0 0 10q�6>   .+�5�      �� 
������ $��11��6>   $��11��6J   $��0 10 0 0q�6U   6i   �� 5�      $��5 9 0 0q�6(   Available in store6M   5�      5�      �� 5�      ���	#FF011936$��1��62   �� 5�      $��0 0 0 20q�6!   .+�5�      �� $ 
Horizontal=�6%   .+�5�      �� 
������ $��11��6>   $��11��6J   $��0 10 0 0q�6U   6i   �� 5�      $��	5 19 0 10q�6(   New Releases6I   5�      �� 5�      $ 
Horizontal=�6%   $��0 0 0 10q�6>   .+�5�      �� 
������ $��11��6>   $��11��6J   $��0 10 0 0q�6U   6i   �� 5�      $��5 9 0 0q�6(   
Trending6C   5�      �� 5�      $ 
Horizontal=�6%   $��0 0 0 10q�6>   .+�5�      �� 
������ $��11��6>   $��11��6J   $��0 10 0 0q�6U   6i   �� 5�      $��5 9 0 0q�6(   Books A - Z6F   5�      �� 5�      $ 
Horizontal=�6%   $��0 0 0 10q�6>   .+�5�      �� 
������ $��11��6>   $��11��6J   $��0 10 0 0q�6U   6i   �� 5�      $��5 9 0 0q�6(   Books (Eletronic)6L   5�      �� 5�      $ 
Horizontal=�6%   $��0 0 0 10q�6>   .+�5�      �� 
������ $��11��6>   $��11��6J   $��0 10 0 0q�6U   6i   �� 5�      $��5 9 0 0q�6(   Book (Physical)6J   5�      �� 5�      $ 
Horizontal=�6%   $��0 0 0 10q�6>   .+�5�      �� 
������ $��11��6>   $��11��6J   $��0 10 0 0q�6U   6i   �� 5�      $��5 9 0 0q�6(   Audio-Books6F   5�      �� 5�      $ 
Horizontal=�6%   .+�5�      �� 
������ $��11��6>   $��11��6J   $��0 10 0 0q�6U   6i   �� 5�      $��5 9 0 0q�6(   	Magazines6D   5�      5�      �� 5�      ���	#FF011936$��1��62   �� 5�      .+�5�      �� $ 
Horizontal=�6%   $��0 0 0 10q�6>   .+�5�      �� 
������ $��11��6>   $��11��6J   $��0 10 0 0q�6U   6i   �� 5�      $��5 9 0 0q�6(   Rating6A   5�      �� 5�      $ 
Horizontal=�6%   $��0 0 0 10q�6>   .+�5�      �� 
������ $��11��6>   $��11��6J   $��0 10 0 0q�6U   6i   �� 5�      $��5 9 0 0q�6(   Collections6F   5�      �� 5�      $ 
Horizontal=�6%   $��0 0 0 10q�6>   .+�5�      �� 
������ $��11��6>   $��11��6J   $��0 10 0 0q�6U   6i   �� 5�      $��5 9 0 0q�6(   
Language6C   5�      �� 5�      $ 
Horizontal=�6%   $��0 0 0 10q�6>   .+�5�      �� 
������ $��11��6>   $��11��6J   $��0 10 0 0q�6U   6i   �� 5�      $��5 9 0 0q�6(   	Fiction6B   5�      �� 5�      $ 
Horizontal=�6%   $��0 0 0 10q�6>   .+�5�      �� 
������ $��11��6>   $��11��6J   $��0 10 0 0q�6U   6i   �� 5�      $��5 9 0 0q�6(   Non-Fication6G   5�      �� 5�      $ 
Horizontal=�6%   $��0 0 0 10q�6>   .+�5�      �� 
������ $��11��6>   $��11��6J   $��0 10 0 0q�6U   6i   �� 5�      $��5 9 0 0q�6(   
Historical6E   5�      �� 5�      $ 
Horizontal=�6%   $��0 0 0 10q�6>   .+�5�      �� 
������ $��11��6>   $��11��6J   $��0 10 0 0q�6U   6i   �� 5�      $��5 9 0 0q�6(   Educational6F   5�      5�      �� 5�      ���	#FF011936$��1��62   �� 5�      $ 
Horizontal=�6!   $��0 20 0 0q�6:   .+�5�      �� 
������ $��11��6:   $��11��6F   $��0 10 0 0q�6Q   6e   �� 5�      $��5 9 0 0q�6$   
For Kids6?   5�      5�      �� 5�      $ Vertical=�6   $	��Top=�5�      $	��626��5�      .+�5�      �� $ 
Horizontal=�6!   .+�5�      �� $
��Bold"�6%   $��23(�5�   %   $��38��5�   %   $��25 -20 -50 -20q�5�   %   $��BROWSING CATALOGUE��5�   %   �� 5�      $��1��6%   $��1��65   $ 
Horizontal=�6B   $
��Left=�6[   $��	72 18 0 0q�6v   .+�5�      �� ���#A3B6CC$��30��5�      $	��230��5       �� RadiusX$ 5��5      �� RadiusY$ 5��5     $��
55 -20 0 0q�5     �� 5     $	��100��6)   $��-340,10,0,28q�65   $��Italic$�6K   Search Library...6q   �� 5     $��Images/searchIcon.png��6$   $��18��5      $��18��5      $��-30,6,113,26q�6,   5     5	     �� 5
     ���	#FF011936$��2��5  )   $	��280��5     $��0 -35 294 0q�5     �� 5     $��2��6#   $��2��5  #   ��5  #   �� *Books+��5     �� 5     .R�5  "   A�  A� Columns$ 4��6.    A� Rows$ 2��6:   5     ��5     �� 5     .R�5  "   �� #��[ 6)   .��5  &   �� $ Vertical=�61   $
��Left=�5  1   $��	15,15,0,0q�5  1   .+�5  *   �� -   5        $	��115��5  0   $��0 0 0 0q�5  0   ��5  0   �� *	ImagePath+
 � Tag 5!  0   �� *Id+�� 5"  *   .+�5#  .   �� $��Normal"�5$  8   $��14(�5%  8   $��0 5 0 0q�5&  8   $
��Wrap=�5'  8   $��Center=�5(  0   ��5#  8   �� *name+5(  0   �� 5)  .   $��12(�6P   $��0 0 0 0q�6^   $��Center=�6o   ��68   �� *author+6o   �� 5*  .   $��12(�6�   $
��Bold"�6�   $��0 0 0 0q�6�   $��Center=�6�   ��68   �� *DisplayAvailability+��6]   �� *AvailabilityColor+6�   5+  +   5,  '   5-  #   5.     50     �� 51     $ 
Horizontal=�6!   $��Right=�52  !   $��10q�53  !   .+�54     �� -   5        $��Add Book��54  !   
����������#89A894$��25��58  !   $��80��59  !   $
��Left=�5:  !   $��Bottom=�5;  !   $��10q�5<  !   �� 5=     -   5        $��Edit Catalogue��5=  !   
����������#89A894$��25��5@  !   $	��100��5A  !   $
��Left=�5C  !   $��Bottom=�5D  !   $��10q�5E  !   �� 5F     -   5        $ ��Toggle Remove Book Buttons��5F  !   
����������#89A894$��25��5I  !   $	��190��5J  !   $��10q�5K  !   5L  !   5M     5N     5O     5P     �� 5Q  
   -   5        $��AdminBrowsingContent��5Q     $��2��5R     $��3��5S     5T     5U     