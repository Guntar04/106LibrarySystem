   M S B A M L   `   `   `  ����K  G106LibrarySystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:LibraryDatabaseLibraryDatabase  5   	   )    #LibraryDatabase.EditCatalogueWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   /localclr-namespace:LibraryDatabase     5   	     � Title$  EditCatalogueWindow��5   	   $	��500��6%   $	��600��62    � 	Resources 5         BookButtonStyle �� 
TargetType �� Property �� Value��%w   &	        �� 5   
   " ��6(   .�5	      ��  � ��
 ���� 6+   �� 5
       � ��$ 0q�60   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��75 �6   �� 5      $	��100 �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $
��Left=�6.   $��5q�6I   .+�5      �� $��Images/image 2.png��6   $��	20,0,10,0q�60   $��60��6C   �� 5      $ 
Horizontal=�6   $��Center=�62   $��
105 15 0 0q�6O   .+�5      �� $��EDIT CATALOGUE��6   $��24(�62   $
��Bold"�6@   
���   �6R   5      5      �� 5   
   ���	#FF011936$��10��6&   $	��Top=�62   $��1��6K   �� 5   
   ���	#FF00487C$��10��6&   $��0,10,0,0q�62   $	��Top=�6D   $��1��6]   �� 5"   
   $	��Top=�6   $��Center=�6-   $��	0,107,0,0q�6J   $��2��6]   .+�5#      �� $��Choose a Book to Update��6   $��15(�67   $
��Bold"�6E   
���   �$	��182��6j   �� 5$      ���	#FF011936$��1��6)   $	��190��64   $��0,5,0,10q�6@   5&      �� 5)   
   $��Bottom=�6   $��3��62   .��5*      � .+�5+      �� 
�������
������ $��0q�6j   ��6   �� *Books+��5,      �� 5-      .R�5.      A�  A� Columns$ 4��6*   $��20q�66   5/      ��51      �� 52      .R�54      �� -   5        #��[  54   %   .��55   "   �� $ Vertical=�6-   $��Center=�6D   $��5q�6a   .+�56   &   �� $	��120��6I   ��6,   �� *	ImagePath+6I   57   #   58      59      5;      5<      5=      5>      5?      