   M S B A M L   `   `   `  ����  ControlWorkbenchListBox.    (ControlWorkbenchListBox.CustomCollection   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$"  Anzeige gruppierter Elemente��5      .��5
      � .+�5      �� -   5        $��lsbWithGrouping��5      $��0,0,0,21q�6    �� 
GroupStyle 5      (  "System.Windows.Controls.GroupStyle  5         ContainerStyle 5      �� 5       �� 
TargetType" ��6   .�5   	   ��  �� Property � �� �� Value 5   
   �� 5       �� 
TargetType" ��6   .R�5      9�  9�Name$	 exp��6   ��6"   ��  �� Path$
 Name�.��5      �� $��0,2,0,5q�6T   y�6   �� 	 �� ElementName$		 exp��$ 
IsExpanded�6T   5      5      5   
   5   	   5       ��5#      �� 5$      .R�5%      �� .+�5&      �� $��10, 1, 1, 0q�62   $��Center=�6G   
 �� TextAlignment$
 Center=�6b   $��30��6y   ��6   �� $ 	FirstName�6y   �� 5'      $��10, 1, 1, 0q�6=   $��Center=�6R   $
 Center=�6m   $��30��6�   ��6   �� $ Values[Beschreibung]�6�   5(      5)      5+      ]� 5,      $��Bottom=�6   ��. .+�5-      �� $��28��6   $
��Left=�6    $
��Auto��66   .��6D   16G   �� 5.      $��28��6   $
��Left=�6    $
��Auto��66   .��6D   26G   d� 5/      -   5        $��cmdShowPopup��5/   2   $��Right=�6   $��23��6F   $��Bottom=�6R   $
��Auto��6m   $��Center=�6z   .��6�   Konfiguration der Gruppierung6�   �� 50      -   5        $��	txtFilter��50      $
��Left=�6'   6=   51      � 52      -   5         � AllowsTransparency .  � 	StaysOpen .  $
��Fade=�56      $	��Top=�58      $
��Auto��59      $	��150��5:      $
��Auto��5;      $
��Left=�5<      $	��Top=�5=       � VerticalOffset$ -1��5>      ��54      �� $	 cmdShowPopup��$ 	IsChecked� �� Mode$ TwoWay=� � PlacementTarget 57      �� $	 cmdShowPopup��.��5@      �� #��� ��6   $��1q�6X   $��0,0,8,8q�6l    J� BitmapEffect 5A      F� 5B       F� Softness$ .5Q�6    F� ShadowDepth$ 3Q�6,    F� Color$ Black��6<   ._�5D      � #��� ��6   $
��Left=�6R   $	��250��6m   $
��Auto��6y    � RowDefinitions 5E      �� 5F      $��28 �6   �� 5G      $��28 �6   �� 5H      $��28 �6   �� 5I      $��* �6   .+�5K      	� -   5        $��rbGroupByAge��5K       $��0��6   $��
2, 0, 0, 0q�64   $��Center=�6H   .��6c   Gruppierung nach Alter6{   	� 5L      -   5        $��rbGroupByFirstLetter��5L   /   $��1��6"   $��
2, 0, 0, 0q�6K   $��Center=�6_   .��6z   $"Gruppierung nach Anfangsbuchstaben6�   	� 5M      -   5        $��rbGroupNone��5M   /   $��2��6"   $��
2, 0, 0, 0q�6B   $��Center=�6V   .��6q   Ohne Gruppierung6�   �� 5N      -   5        $��cmdApplyGrouping��5N   q   $��3��6   $��24��6*   $��70��66   $��
0, 0, 2, 2q�6A   $��Right=�6U   .��6�   Übernehmen6�   5P      5Q      5R      5S      5T      