   M S B A M L   `   `   `  ����R  NControlWorkbenchListBox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ControlWorkbenchListBoxControlWorkbenchListBox  5      <    6ControlWorkbenchListBox._UseCases.ItemsWithProgressBar   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      IcontrolWorkbenchListBox%clr-namespace:ControlWorkbenchListBox     5        N� Title$&   Einträge mit Fortschrittsbalken��5	       � 	Resources 5
         ValueableCaseTemplate �� DataType � ColumnDefinitions � RowDefinitions � Minimum � Maximum � Value �� 
TargetType	 �� Property
 �� Value �� 
TargetType'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard W� From	 W� To �� 
TargetName �� TargetProperty g� Duration ��Name J� Opacity �Name � Points��%e  &	        '�� �    �� 5   
   $+ %controlWorkbenchListBox:ValueableCase��65   .R�5      � $��0q�6   $��Stretch=�6    5      �� 5       5      �� 5      $��25 �6$   �� 5      $��20 �6$   .+�5      �� $��0��6   ��6)   �� *Title+6B   � 5      $��1��6   $ 0Q�6D   $	 100Q�6P   $��10��6^   $��0q�6j    6+   �� *Amount+6j   5      5      �� 5   
   " ��6   .�5      �� 	 � ��$
 3q�6(   �� 5      	 � ��$

 Left=�6;   �� 5      	 � ��$
 1q�60   �� 5      	 � ��
 5      �� 5      " ��6&   .R�5      � #��z��6   $
��Auto��6I    5         5!      SelectionStates��. 5"        Selected��. 5#      �� .��5$      W� $ 0X�6.   $ 1X�67   $ marker��6>   $ Opacity�6]   $ 0:0:0.2D�6�   W� 5%      $ 0X�6.   $ 1X�67   $ marker2��6>   $ Opacity�6^   $ 0:0:0.2D�6�   5&      5'        5(      
Unselected��6"   5)      .+�5,      �� $ marker��6   $ 0Q�6(   $��0q�64   $��3��6?   
�������6S   � 5.      $ marker2��6   
������� �   @���� $ 0Q�6M   $
��Left=�6Y   $��Bottom=�6t   �� 50      $��20, 2, 2, 2q�6   #��z��51   1   #��z��52   1   #��z��53   1   #��z��54   1   #��z��55   1   #��z��56   1   58      59      5;      5<      5=      .��5>      � .+�5?   
   �� -   5        $��lstItems��5?   ]   $��10,10,10,44q�6   #��[  6'   6]   �� 5@   
   -   5        $��Button��5@      $
��Left=�6"   $��29��6=   $��	10,0,0,10q�6I   $��78��6\   $��Bottom=�6g   6�   5A      5B      