   M S B A M L   `   `   `  ����C  ?ToDoList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:ToDoList.ViewModelToDoList.ViewModel  5
   	       ToDoList.View.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:ToDoList.ViewModel     5
   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � WindowStyle$
 None=�5	   	    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $# /View/ResourceDictionary.xaml?�6%   %    5       � DataContext 5      &    ToDoList.ViewModel.MainViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��1* �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5       $��1* �6#   �� 5!      $��30 �6#   �� 5"      $��30 �6#   �� 5#      $��30 �6#   .+�5%      ]� -   5        
����� �$��0��5%   2   .+�5&      �� -   5        $!��/Resources/ToDoListIcon.png��5&      $��30��6=   6H   �� 5'      $��Center=�6   $��20(�64   
�������$&�� /Resources/#이사만루체 Bold)�6U   $��
To Do List��6y   5(      �� 5)      -   5        $��1��5)      6&   �� 5*      -   5        $��2��5*      6%   �� 5+      -   5        $��3��5+      6%   5,      � 5.   
   $��1��6    5/      �� 50      $��50 �6    �� 51      $��1* �6    .+�53      � $��0,0,0,0q�6   $��0��6$    54      �� 55      $	��100 �6'   �� 56      $	��100 �6'   �� 57      $	��100 �6'   �� 58      $��1* �6'   .+�5:      	� -   5           TodayRadioButton#���   5:      $��0��6I    d� 	IsChecked$
 TrueY�6t   5M      	� 5O      -   5        
������ $��1��5O   7   ��5P      �� 5Q      .R�5R      �� ._�5S   "   �� $��이번 주 할 일!��63   $��Center=�6G   $��Center=�6d   5T      	 �� Triggers	 5U      P� 5V   "   
 P� Property
 �@d�	IsChecked P� Value$
 TrueY�6K   . �5W   &   ��  �� Property � �� �� Value
 �  ��6C   �� 5X   &    � ��$
 Bold"�6C   5Y   #   5[      5]      	� 5^      -   5        $��Center=�5^      $��2��6;   $��달력보기!��6K   ��5_      �� 5`      .R�5a      �� ._�5b   "   �� $��달력보기!��63   $��Center=�6C   $��Center=�6`   5c      	 5d      P� 5e   "   
 �@d�	IsChecked$
 TrueY�6K   . �5f   &   ��  � ��
 ��  �6D   �� 5g   &    � ��$
 Bold"�6C   5h   #   5j      5l      �� 5n      
������ 
������ $��3��6L   $��Right=�6\   $��0,0,50,0q�6x   ��6�   �� *AddInfoCommand+.��5o      ��  �� Orientation$ 
Horizontal=�6!   .+�5p      �� $��Center=�6$   $��일정추가��6?   $'��!/Resources/#이사만루체 Light)�6K   $��15(�6p   �� 5q      $��5q�6    $��/Resources/add.png��6+   5r      5t      5u       � 5v      -	   5        $��	mainFrame��5v   !   $��1��6     � NavigationUIVisibility$ Hidden=�62   5{      5      5�      