   M S B A M L   `   `   `  ����  ControlWorkbenchListBox;    5ControlWorkbenchListBox._UseCases.AnimatedListBoxItem   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$   Animationen im ListBoxItem��5       � 	Resources 5	         SimpleStyle1 �� 
TargetType �� 	Resources �� Color �� Property �� Value �� 
TargetType'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup	   States   System.Windows.VisualState
   
Storyboard W� From	 W� To �� 
TargetName �� TargetProperty g� Duration ��Name J� Opacity �Name � Points ��Name��%�  &	        '�� �     �� 5
   
   " ��6%    5      ���� 5      $	 Red��6T   (��       6"   * SystemColors.HighlightBrushKey+)6T   �� 5      $ Green��6R   (��       6"   *SystemColors.ControlBrushKey+)6R   5      5      �� 5   
   " ��6   .�5      ��  � ��$ 3q�6(   �� 5       � ��$
 Left=�6;   �� 5       � ��$ 1q�60   �� 5       � �� 5      �� 5      " ��6&   .R�5      � #��z��6   $
��Auto��6I    5        5   "   SelectionStates��.	 5   &     Selected��.
 5   *   �� .��5   .   W� $ 0X�6>   $ 1X�6G   $ marker��6N   $ Opacity�6m   $ 0:0:0.2D�6�   W� 5   .   $ 0X�6>   $ 1X�6G   $ marker2��6N   $ Opacity�6n   $ 0:0:0.2D�6�   5   +   5    '     5!   &   
Unselected��62   5"   #     5#   "   Ages��.	 5$   &     Default��62     5%   &   	Young��.
 5&   *   �� .��5'   .   W� $ 1X�6>   $	 0.5X�6G   $ Content��6P   $ Opacity�6p   $ 0:0:0.2D�6�   5(   +   5)   '   5*   #   .+�5-      �� $ marker��6(   $ 0Q�68   $��0q�6D   $��3��6O   
�������6c   � 5/      $ marker2��6&   
������� �   @���� $ 0Q�6]   $��Right=�6i   �� 51      $ Content��58   1   $��20, 2, 2, 2q�51   /   #��z��52   1   #��z��53   1   #��z��54   1   #��z��55   1   $
��Left=�56   1   $��Center=�57   1   58   1   5:      5;      5=      5>      5?      .��5@      �  � ColumnDefinitions 5A   
   �� 5B      $��* �6    � RowDefinitions 5D   
   �� 5E      $��* �6   �� 5F      $��30 �6   .+�5H   
   �� -   5        $��
lstPersons��5H   Z   $��0��6   $��0��6"   $��5q�6/   ��6:   �� *	Persons+��5I      �� 5J      .R�5K      � $��25��6   .+�5L      �� 
�5M      �� 5N   "   �6&   �� *	FirstName+ �� 5O   "   $� ��6&    �� 5P   "   �6&   �� *
LastName+5R      5S      5T      5V      �� 5W   
   -   5        $��1��5W      $��25��6   $��
Ausführen��6*   6>   5X      5Y      