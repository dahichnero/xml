   M S B A M L   `   `   `  ����D  @xmlwpfval, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:xmlwpfval	xmlwpfval  5   	       xmlwpfval.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:xmlwpfval     5   	     � Title$  
MainWindow��5   	   $	��800��6   $	��500��6)    � 
ResizeMode$ NoResize=�65   .��5	      �� $��8q�6   .+�5
   
   �� $#��Конвертер валют��6      headerLabel#��[  6*   �� 5   
   $��Из: ��6   �� 5   
   -   5         ��Name$ FromComboBox��5      �� 5   
   $
��В: ��6   �� 5   
   -   5        $ 
ToComboBox��5      �� 5   
   $��0 50 0 0q�6   $(��"Исходная величина:��6"   �� 5   
   -   5         ��Name$ InputBox��5      6B   �� 5   
   $��Результат��6   �� 5   
   -   5        $ 	OutputBox��5   $    �� 
IsReadOnly$
 True��6   6$   5      5      