   M S B A M L   `   `   `  ����P  LControlWorkbenchPopup, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ControlWorkbenchPopupControlWorkbenchPopup  5      5    /ControlWorkbenchPopup._UseCases.ResizeablePopup   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2my#clr-namespace:ControlWorkbenchPopup     5        N� Title$  ResizeablePopup��6    � 	Resources 5	       �� 
TargetType   
PopupThumb �� Property �� Value � 	StaysOpen  myPopup � RowDefinitions � ColumnDefinitions ��Name	 �� TextAlignment
 � Cursor��%N  &	        &	 �     7   7   7   �� 5
   
   " n�6   .�5      ��  � ��$ Stretch=�5      �� 5       � ��$ Stretch=�5      -   5        5      � 5   
    .  $	��100��6#   $	��100��60   $��Mouse=�5      .��5      �� 
���   �$��1q�6)   ._�5      � 
������� 5      �� 5      $��* �6(   �� 5      $��10 �6(    5      �� 5      $��* �6+   �� 5      $��10 �6+   .+�5       �� $ PopupTxt��5!      $��0��5        $��0��6-   $	 Center=�5"      $��Center=�5#      I'm A Popup!!5%      n� 5&      $��0��6   $��1��6)   $
 SizeWE��5'      8��  5(      n� 5)      $��1��6   $��0��6)   $
 SizeNS��5*      8�� 5+      n� 5,      $��1��6   $��1��6)   $
 SizeNWSE��5-      8�� 5.      5/      50      51      52      .��53      � .+�54   
   �� -   5        $��button1��54   n   $��Button��6#   $��35��64   $
��Left=�6@   $��	60,64,0,0q�6[   $	��Top=�6}   $	��160��6�   +   %ControlWorkbenchPopup.ResizeablePopup  55   
   -   5          Name$ resizeablePopup1��55   Y   $	��124��6   $
��Left=�6*   $��
62,134,0,0q�6E   $	��Top=�6s   $	��196��6�   56      57      58      