   M S B A M L   `   `   `  ����Q  MControlWorkbenchButton, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:ControlWorkbenchButton.ModulesControlWorkbenchButton.Modules  5      7    1ControlWorkbenchButton.Modules.AdjustedButtonView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @modules,clr-namespace:ControlWorkbenchButton.Modules     5      W SWPFArchitectureModel.Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null(libhttp://www.wpfarchitecture.com  5        � DataContext  5
      8   2ControlWorkbenchButton.Modules.AdjustedButtonModel  5   
    � 	Resources 5         	Default_0  	Default_1  	Default_2  MouseOver_0  MouseOver_1  MouseOver_2 �� 
StartPoint �� EndPoint  ButtonBlackBackground � Color � Offset # ButtonBlackBackground_MouseOver ! ButtonBlackBackground_Pressed $	  ButtonBlackBackground_NotEnabled �� 
TargetType �� Property �� Value	 �� 
TargetType
 �Name ��Name �� CornerRadius ��Name �� Triggers P� Property P� Value �� 
TargetName :� RoutedEvent �� 
TargetName �� TargetProperty	 �� To g� Duration��%C	  &	        &	 !     &	 B     &	 c     &	 �     &	 �     &	 �     7   7  7  &	 W    7  7  7  &	 �    &		 �    '�� �    7  7  7 	 7   7  7  ��5   
   	#FF5A5A5A��6-   ��5   
   	#FF4C4C4C��6-   ��5   
   	#FF3E3E3E��6-   ��5   
   	White��6+   ��5   
   Red��6)   ��5   
   	Green��6+   �� 5   
   $	 0,0&�6   $	 0,1&�6/   ��5      � 8   $	 0.0Q�6B   � 5      8  $	 0.2Q�6B   � 5      8  $	 0.5Q�6B   5       �� 5!   
   $	 0,0&�6   $	 0,1&�6/   ��5#      � 8   $ 0Q�6D   � 5$      8  $	 0.2Q�6D   � 5%      8  $	 0.5Q�6D   5'      �� 5(   
   $	 0,0&�6   $	 0,1&�6/   ��5*      � $ 	#FF565656��6   $ 0Q�61   � 5+      $ 	#FF464646��6   $	 0.2Q�61   � 5,      $ 	#FF363636��6   $	 0.5Q�61   5.      �� 5/   
   $	 0,0&�6   $	 0,1&�6/   ��51      � $ 	#FF969696��6   $ 0Q�61   � 52      $ 	#FF7B7B7B��6   $	 0.2Q�61   � 53      $ 	#FF616161��6   $	 0.5Q�61   55      �� 56   
   " ��6   .�57      ��  � �� 58      �� 59      "	 ��6&   .R�5:      � $
 
ButtonGrid��6   .+�5;      �� $ ButtonBorder��6%   $ 5��6;   $��1q�6L   ���	#FF2E2E2E$��21.96��5<   6   #���  5=      5>      �� 5?      $ ButtonContentPresenter��6/   #��z��5@      #��z��5A      #��z��5B      5C       5D      P� 5K       �@J�IsKeyboardFocused . . �5L   "   �� $ ButtonBorder��6?   8    � ��5M   !   5N      P� 5O       � �� . . �5P   "   �� $ ButtonBorder��6?   8   � ��5Q   !   5R      P� 5S       � {� .  . �5T   "   �� $ ButtonBorder��6?   8   � ��5U   !   5V      :� 5W      $ Button.MouseEnter��6+   [�5X   "   �� 5Y   &   .��5Z   *   �� 5[   +   5\   '   5^      :� 5_      $ Button.MouseLeave��6+   [�5`   "   �� 5a   &   .��5b   *   �� .��5c   .   �� $ ButtonBorder��5d   %   $' !Background.GradientStops[0].Color�5e   %   8  $ 0:0:1D�5f   E   �� 5g   .   $ ButtonBorder��5h   %   $' !Background.GradientStops[1].Color�5i   %   8  $ 0:0:1D�5j   E   �� 5k   .   $ ButtonBorder��5l   %   $' !Background.GradientStops[2].Color�5m   %   8  $ 0:0:1D�5n   E   5o   +   5p   '   5r      5t      5v      5w      5y      .��5z      � .+�5{   
   �� -   5        $��	bttSample��5{   R   $��Angepasster Button��6   $��36,31,106,230q�6.    J� Opacity$ .5Q�6E   6R   5|      5}      