   M S B A M L   `   `   `  ����C  ?ToDoList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:ToDoList.ViewModelToDoList.ViewModel  5      /    )ToDoList.View.SubForm.CalendarDateControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:ToDoList.ViewModel     5        � DataContext  5	      .   (ToDoList.ViewModel.CalendarDateViewModel  5
   
   .��5      �  � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $��80 �6   .+�5   
   �� $��Center=�6   $��0��61   ��6>   �� *Date+�� 5   
   $��1��6   $ �� IsSynchronizedWithCurrentItem$
 trueY�6@   ��6   �� *
ToDoList+��5      �� 5      .R�5      �  � ColumnDefinitions 5      �� 5      $��1* �6/   �� 5      $��0 �6/   .+�5      �� $
��Wrap=�6$   $��Center=�68   $��Center=�6U   
���   �$��0��6�   ��6�   �� *
ToDoData+�� 5      $��1��6$   ��64   �� *UUID+5      5      5!      5#      5$      