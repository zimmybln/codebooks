   M S B A M L   `   `   `  ����  WPFPrinting    WPFPrinting.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��75* �6   �� 5      $	��25* �6   .+�5
   
   Z� -   5        $��viewer��5
   4   $��0��6   $��0q�6)    Z� Zoom$ 80Q�6B   
������� � 	Resources 5       �� 
TargetType �� Property �� Value��%�   '��       'c� O     �� 5      " ��6   .�5      ��  � y�$ 	Collapsed=�63   5      �� 5      " c�6   .�5      ��  � y�$ 	Collapsed=�63   5      5      5      � 5   
   $��1��6    � RowDefinitions 5      �� 5      $��25 �6    �� 5      $��28 �6    6.   �� 5      $��* �6    .+�5      �� -   5        $��0��5      $��Center=�6"   $	��109��6?   $��25��6K   $	��Top=�6W   $��Drucken��6o   6�   �� 5      -   5        $��
cboPrinter��5   /   $��1��6   $��2q�6$   ��5       �� 5!      .R�5"      �� $��2q�6:   
������ ��6$   �� *Name+6E   5#      5%      �� 5&      $��2��6    �� Orientation$ Vertical=�6&   .+�5'      �� $��Anzahl Seiten pro Blatt��6   �� 5(      -   5        $��cboPaperSize��5(      $��5q�6/   �� 5)      $��Farben/Schwarz-Weiß��6   68   �� 5*      -   5        $��cboColor��5*      $��5q�6+   5+      5,      5.      5/      