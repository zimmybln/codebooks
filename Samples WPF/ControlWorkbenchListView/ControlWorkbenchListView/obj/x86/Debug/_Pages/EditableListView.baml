   M S B A M L   `   `   `  ����S  OControlWorkbenchListView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ControlWorkbenchListViewControlWorkbenchListView  5      /    )ControlWorkbenchListView.EditableListView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:ControlWorkbenchListView     5        N� Title$&   Bearbeiten von Daten im ListView��5       � ToolTip$ Zeigt das Bearbeiten��5	       � 	Resources 5
      ;   5ControlWorkbenchListView.BooleanToVisibilityConverter   	boolToVis �� 
TargetType  ReadOnlyItemStyle �� Property �� Value �� Path �� RelativeSource �� AncestorType	 �� 	Converter
 �� ConverterParameter  EditItemStyle��%�  &	        &	      7   &	 �     7     5      6(   �� 5      " ��6
   .�5      ��  � ��$ Center=�6)   �� 5       � y� 5      �� $ 
IsSelected� �� *FindAncestor+" ��8	   $
 false��5      �� 5      " �6
   .�5      ��  � ��$ Center=�6)   �� 5       � ��$ Stretch=�6+   �� 5       � y� 5      �� $ 
IsSelected� �� *FindAncestor+" ��8	   $

 true��5       5!      .��5"      � .+�5#      �� -   5        $��
lsvPersons��5#   9   $
��Left=�6   $��2,2,2,2q�6(   $	��Top=�6K   ��6c   �� *	Persons+��5$      �� 5%      " ��6   .�5&      ��  � ��$ 25��6    5'       �� View 5)      �� 5*      .P�5+      ��  �� Width$	 150��6   $��	Firstname��6"    �� CellTemplate 5,      �� 5-   	   .R�5.   
   � $��Stretch=�6   .+�5/      �� #��[ 65   ��6   �� $ 	FirstName�65   �� 50      #��[ 63   ��6   �� $ 	FirstName�63   51      52   
   54      �� 55      $	 200��6   $
��City��6"    56      �� 57   	   .R�58   
   � $��Stretch=�6   .+�59      �� #��[ 60   ��6   �� $
 City�60   �� 5:      #��[ 5<      $��Stretch=�5=       �� SelectedItem 5:      �� $
 City���5;      ��  �� *FindAncestor+" N�$ Cities�5=      5>      5?   
   5A      5B      5D      5E      5F      