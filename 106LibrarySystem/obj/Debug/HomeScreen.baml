   M S B A M L   `   `   `  ����K  G106LibrarySystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:_106LibrarySystem_106LibrarySystem  5      "    _106LibrarySystem.HomeScreen   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:_106LibrarySystem     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��50 �6    � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $	��223 �6   �� 5      $��* �6   .+�5   
   �� 
�������$��3��5      $��3��5      �� 5   
    �� Orientation$ 
Horizontal=�6   $
��Left=�6.   $��1��5      $��3��5      .+�5      �� $��Images/image 2.png��6   $��	20 0 10 0q�5      �� 5      
���   �
�������
�������$��13(�5"      $��100px��5#      $��20 5 5 5q�5$      .��6#   Home6)   �� 5%      -   5        
���   �
�������
�������$��13(�5)      $��100px��5*      $��0 5 0 5q�5+      .��6"   	Catalogue6-   �� 5,      
���   �
�������
�������$��13(�50      $��100px��51      $��0 5 0 5q�52      .��6"   	Support6+   �� 53      $ 
Horizontal=�6   $��	200 0 0 0q�54      .+�55      �� $��Images/lang.png��6   $��0��56      $��	20 0 10 0q�57      $��3��6#   $��39��67   $��52��6C   � 58      $��40��6   $��40��59      $��Center=�5:      $��Center=�5;      $��	20 0 10 0q�5<      .+�5=      �� $��Images/profile.png��6   $��0��5?      $��3��5@      $��40��5A      $��34��5B      �� 5C      -   5        $��40��5D      
������ 
������ 5F      5G      5H      5I      �� 5J   
   $��3��6   $��1��6+   $��2��68   $	��800��6I   .��5K      �� .+�5L      �� $��2��6   $��2��5M      .+�5N      �� $��	15 0 15 0q�6   $��Images/homeBanner.png��5O      5P      �� 5Q      -   5         ��Name$ Icons��5Q      $��2��5R      $��1��5S      .+�5T      � .+�5U      �� ���#A3B6CC$��30��5V      $	��500��5W       �� RadiusX$ 5��5X       �� RadiusY$ 5��5Y      $��20q�5Z      �� 5[      $	��100��6%   $��118,26,482,26q�61   Search Library...6[   �� 5\      $��Images/searchIcon.png��6    $��18��5]      $��18��5^      $��569,26,113,26q�6(   5_      �� 5`      $��3��6!   $ 
Horizontal=�5a      $��Center=�5b      .+�5c      �� $��20q�6%   .+�5d      �� $��Images/Card.png��6$   $��50��5e      $��50��5f      �� 5g       �� TextAlignment$ Center=�6(   $
��Bold"�5h   (   
Your Books6F   �� 5i      $	��110��6(   $��WrapWithOverflow=�67   <:Check your borrowed, reserved, due, overdue books and more6�   5j      �� 5k      $��20q�6%   .+�5l      �� $��Images/Calander.png��6$   $��50��5m      $��50��5n      �� 5o      $ Center=�6(   $
��Bold"�5p      Events6&   �� 5q      $	��110��6(   $��WrapWithOverflow=�67   :8Check for upcoming event and book the library for events6�   5r      �� 5s      $��20q�6%   .+�5t      �� $��Images/Contact.png��6$   $��50��5u      $��50��5v      �� 5w      $ Center=�6(   $
��Bold"�5x      	Support6'   �� 5y      $	��110��6(   $��WrapWithOverflow=�67   53Ask for support and view frequently asked questions6�   5z      �� 5{      $��20q�6%   .+�5|      �� $��Images/Audio.png��6$   $��50��5}      $��50��5~      �� 5      $ Center=�6(   $
��Bold"�5�      Online Library6.   �� 5�      $	��110��6(   $��WrapWithOverflow=�67   PNBorrow eBooks and eAudiobooks or browse online magazines, newspapers and books6�   5�      �� 5�      $��20q�6%   .+�5�      �� $��Images/Maps.png��6$   $��50��5�      $��50��5�      �� 5�      $ Center=�6(   $
��Bold"�5�      
Location6(   �� 5�      $	��110��6(   $��WrapWithOverflow=�67   <:Check your borrowed, reserved, due, overdue books and more6�   5�      5�      5�      �� 5�      .+�5�      �� $ Center=�6    $��20(�5�       $
��Bold"�5�       $��0 20 0 0q�5�       #!HAVE A LOOK AT OUR TRENDING BOOKS6U   �� 5�      
���   �$	��500��5�       $��2��5�       $��0 10 0 0q�5�       5�      �� 5�      $ 
Horizontal=�6   $��Center=�5�      $��	0 30 0 30q�5�      .+�5�      �� -   5        $��	15 0 15 0q�5�      $��Images/book7.png��5�      $	��150��5�      
 � Tag$ 2��5�      �� 5�      -   5        $��	15 0 15 0q�5�      $��Images/book2.png��5�      $	��150��5�      $ 4��5�      �� 5�      -   5        $��	15 0 15 0q�5�      $��Images/book3.png��5�      $	��150��5�      $ 5��5�      �� 5�      -   5        $��	15 0 15 0q�5�      $��Images/book4.png��5�      $	��150��5�      $ 6��5�      5�      �� 5�      $ Center=�6   $��20(�5�      $
��Bold"�5�      $��0 20 0 0q�5�      
FEATURED6(   �� 5�      
���   �$	��500��5�      $��2��5�      $��0 10 0 0q�5�      �� 5�      $ 
Horizontal=�6   $��Center=�5�      $��	0,30,0,30q�5�      .+�5�      �� -   5        $��	15 0 15 0q�5�      $��Images/book9.png��5�      $	��150��5�      $ 8��5�      �� 5�      -	   5        $��	15 0 15 0q�5�      $��Images/book8.png��5�      $	��150��5�      $ 7��5�      �� 5�      -
   5        $��	15 0 15 0q�5�      $��Images/book1.png��5�      $	��150��5�      $ 3��5�      �� 5�      -   5        $��	15 0 15 0q�5�      $��Images/book17.png��5�      $	��150��5�      $ 1��5�      5�      �� 5�      ���#011936$	��800��5�      $��40��5�      $��0 20 0 0q�5�      5�      5�      �� 5�   
   -   5        $��HomeContent��5�      $��3��5�      $��3��5�      5�      5�      