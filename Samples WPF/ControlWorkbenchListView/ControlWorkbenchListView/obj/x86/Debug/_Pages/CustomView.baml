   M S B A M L   `   `   `  ����S  OControlWorkbenchListView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ControlWorkbenchListViewControlWorkbenchListView  5      )    #ControlWorkbenchListView.CustomView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:ControlWorkbenchListView     5        N� Title$+  %Benutzerdefinierte Ansicht von Listen��5       � 	Resources 5	      1   +ControlWorkbenchListView.ImagePathConverter   imgConverter 	 some1 �� 
TargetType �� BasedOn �� Property �� Value �� 	Converter  GridView �� AllowsColumnReorder �� ColumnHeaderToolTip	 �� DisplayMemberBinding  centralTile
 �� TypeInTargetAssembly'   !ControlWorkbenchListView.TileView �� 
ResourceId �� RelativeSource �� AncestorType(   "ControlWorkbenchListView.PlainView  tileView   ItemTemplate   	ItemWidth��%�  &	        &	      7��7   &	 �    &	 �    7   (�� �    5E      "
  $ TileView��)7��&	 F    7    5
      6   �� 5"      " ��6   8   .�5#      ��  � ��$ 3q�6   �� 5$       � ��$ 5q�6   �� 5%       � ��$ Center=�62   �� 5&       � �� 5'      �� 5(      .R�5)      �� $	��100��6   .+�5*   	   �� 
���   �$��1q�6$   ._�5+   
   �� $��5q�6   $	��120��6d   $��80��6p   ��6   �� *PortraitName+8  6p   5,   
   �� 5-   	   $��3q�6   ��6   �� *	FirstName+5.   	   5/      51      53      �� 55       . $
 asdf��69   P�56      �� 57      $��Vorname��6   	 6&   �� *	FirstName+�� 58      $��Stadt��6   	 6$   �� *City+5:      �� 5<      .R�5=      �� $	��100��6   $��90��6   .+�5>      � $��70��6   $��70��6   $��Center=�6"   .+�5?      �� $��6,6,6,9q�6V   ��6   �� *PortraitName+8   6V   5@      �� 5A      $��13(�6+   $��Center=�69   $��0,0,0,1q�6V   
��� �����6   �� *	FirstName+6g   5B      5C      �� 5E   
   " ��5G      8   .�5H      ��  � ��
 �   �6<   �� 5I       � ��$	 0.5q�60   6>   �� 5J       �@�IsSharedSizeScope . 6F   �� 5L       � �� 5M      �� 5N      .R�5O      � ��6$   �� * (FrameworkElement.ActualWidth)+ �� $ ScrollContentPresenterL�5R      5S      5U      5V        5X   
   8   $	 100Q�5Z      5^      .��5_      � .+�5`      �� -   5        $��
lsvPersons��5`      $��2,41,2,2q�6   
�������$	��257��6F    �� View# [ 6s   ��6S   �� *	Persons+5b      �� 5c      -   5        $��cboViews��5c   G   $��23��6   $
��Left=�6   $��	12,12,0,0q�64   $	��Top=�6W   $	��276��6o   @�5d      �� 5e      .��6   
GridView6   �� 5f      .��6   
tileView6   5h      5i      5j      