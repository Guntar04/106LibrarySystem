   M S B A M L   `   `   `  ����K  G106LibrarySystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:LibraryDatabaseLibraryDatabase  5   	   $    LibraryDatabase.BookEditWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:LibraryDatabase     5   	     � Title$  BookEditWindow��5   	   $	��450��6    $	��622��6-   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��75 �6   �� 5      $��* �6   .+�5   
   �� $��2��6    �� Orientation$ 
Horizontal=�6)   $��5q�6B   .+�5      �� $��Images/image 2.png��6   $��	20,0,10,0q�60   $��60��6C   �� 5      $ 
Horizontal=�6   $��Center=�62   $��	85 15 0 0q�6O   .+�5      �� $��UPDATE BOOK DETAILS��6   $��24(�67   $
��Bold"�6E   
���   �6W   5      5      �� 5   
   ���	#FF011936$��10��6&   $	��Top=�62   $��1��6K   $��2��6X   �� 5   
   ���	#FF00487C$��10��6&   $��0,10,0,0q�62   $	��Top=�6D   $��1��6]   $��2��6j   �� 5   
   $��2��6   $��
50 20 50 0q�6"   $ Vertical=�66   $��Bottom=�6M   .+�5      �� -   5         ��Name$ 	bookImage��5      $	��150��6D   ��6'   �� *	ImagePath+6D   �� 5!      -   5        $��Upload Image��5!      $��Italic$�6L   ���#A3B6CC
������ $��25��6�   $	��100��6�   $��	5 30 0 20q�6�    J� Effect 5"      3  -System.Windows.Media.Effects.DropShadowEffect  5#         ShadowDepth$ 1Q�6'      
BlurRadius$ 5Q�67      Opacity$	 0.8Q�6F   	   Color$	 Black��6T   5%      5&      �� 5*   
   $��1��6   $��2��6%   $��0 40 0 0q�62   .+�5+      �� -   5        
 ��Name$
 NameTextBox��5+      $��15(�6+   $	��250��69   $��	10 10 0 0q�6E    �� 
IsReadOnly .  $	��Top=�5.   
   $	��Top=�5/   
    �� TextWrapping$
 Wrap=�50   
   ��5,   
   �� *name+ �� UpdateSourceTrigger$ Explicit=�50   
   �� 51      -   5        $
 AuthorTextBox��51      $��15(�6.   $	��250��6<   $��	10 10 0 0q�6H    .  ��6[   �� *author+$ Explicit=�6�   �� 52      -   5        $
 AvailabilityTextBox��52      $��15(�64   $	��250��6B   $��	10 10 0 0q�6N    .  ��6a   �� *availability+$ Explicit=�6�   �� 53      $��15(�6   $	��250��6%   $��	10 10 0 0q�61    .  ��6D   �� *
language+6^   �� 54      $��15(�6   $	��250��6%   $��	10 10 0 0q�61    .  ��6D   �� *	pageNum+6]   �� 55      $��15(�6   $	��250��6&   $��	10 10 0 0q�62    .  ��6E   �� *date+6[   57      �� 59   
   $��2��6   $��2��6"   $ Vertical=�62   $��Bottom=�6I   $��
230 0 0 12q�6d   .+�5:      �� -   5        $
��Save��5:      $��Italic$�6=   ���#A3B6CC$��14(�6e   
������ $��25��6�   $��80��6�   $��10q�6�    5;        5<      $ 1Q�6'   $ 5Q�67   $	 0.8Q�6F   $	 Black��6T   5>      5?      �� 5@   
   ���	#FF011936$��10��6&   $��Bottom=�62   $��2��6N   $��2��6[   5A      5B      