   M S B A M L   `   `   `  ����S  OControlWorkbenchListView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:ControlWorkbenchListView._PagesControlWorkbenchListView._Pages  5      C&clr-namespace:ControlWorkbenchListViewControlWorkbenchListView  5      5    /ControlWorkbenchListView._Pages.CustomStateView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @_Pages-clr-namespace:ControlWorkbenchListView._Pages     5      6app&clr-namespace:ControlWorkbenchListView     5        N� Title$  CustomStateView��5
      $	��Top=�6   $
��Left=�62   $��0q�6M    � 	Resources 5         PortfolioTemplate �� DataType �� Triggers �� Value �� Binding �� 
TargetName �� Property �� Value	 � RowDefinitions
 � ToolTip  PortfolioTemplateRed9   3ControlWorkbenchListView.SimpleDataTemplateSelector  TemplateSelector   FirstTemplate   SecondTemplate��%�  &	        &	 &    &	 L    7   7  �� 5      $ _Pages:SampleData��6+    5      �� 5      $
 true��6-    6   �� *IsTest+.a�5      �� $ 
txtContent��6    � ��
 ��� �6F   �� 5      $ picAny��6    � y�$ Visible=�6>   5      .R�5      � $	��180��6
   $��5q�6   	 5      �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5      �� $��0��6   $��../_Resources/cloud.png��6   $��Center=�6:   $��48��6W   $��48��6b   �� 5      $��picAny��6�   $��0��6   $��../_Resources/Person.png��6   $
��Left=�6;   $	��Top=�6V   $��16��6n   $��16��6y   $y�	Collapsed=�6�   �� 5      $��
txtContent��6�   $��1��6   $��Center=�6S   $
��Wrap=�6p   
���������6   �� *Name+
 63   �� *Description+5      5      5      �� 5   
   $ _Pages:SampleData��64    5      �� 5       $
 true��69    6   �� *IsTest+.a�5!      �� $ 
txtContent��6    � ��
 ��� �6U   �� 5"      $ picAny��6    � y�$ Visible=�6M   5#      .R�5%      � $	��180��6   $��5q�6   	 5&      �� 5'      $
��Auto �6$   �� 5(      $
��Auto �6$   .+�5*      �� $��0��6   $��../_Resources/cloud.png��6%   $��Center=�6F   $��48��6c   $��48��6n   �� 5+      $��picAny��6�   $��0��6   $��../_Resources/Person.png��6%   $
��Left=�6G   $	��Top=�6b   $��16��6z   $��16��6�   $y�	Collapsed=�6�   �� 5,      $��
txtContent��6�   $��1��6   $��Center=�6_   $
��Wrap=�6|   
���  ����6)   �� *Name+
 6?   �� *Description+5-      5.      5/        50   
   8   8  6u   51      .��53      � ���	#FFE2D2CD$��0q�6    � ColumnDefinitions 54   
   �� 55      $��* �6   	 57   
   �� 58      $��* �6   �� 59      $��40 �6   .+�5;      �� -   5        $��lvItems��5;   ;   $��0��6   $��0��6   $��0,0,0,0q�6*   ���	#AAFFFFFF J� 	AllowDrop . $��Disabled=�5=      #��[ 5>      ��5;   J   �� *	LocalData+��5@      �� 5A      .R�5B      �  � Orientation$ Vertical=�6    K� IsItemsHost . 6(   5C      ��5E      �� 5F       �� 
TargetType" ��6   .�5G      ��  � ��$	 200��6    �� Triggers 5H      P� 5I       P� Property �@J�IsMouseOver P� Value . . �5J      ��  � ��
 �**��6;   �� 5K       � ��
 �����6;   5L      5N      5P      �� 5Q      -   5        $��button1��5Q   q   $��0��6   $��1��6   $��Button��6(   $��33��69   $
��Left=�6E   $��2,2,0,0q�6`   $	��Top=�6�   $��58��6�   6�   5R      5S      