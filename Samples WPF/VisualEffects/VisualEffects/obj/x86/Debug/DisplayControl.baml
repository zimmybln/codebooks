   M S B A M L   `   `   `  ����  VisualEffects"    VisualEffects.DisplayControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      � '  !System.Windows.VisualStateManager    VisualStateGroups  5	   
   %  System.Windows.VisualStateGroup  5
      -   5        Ausgang��   States. 5         System.Windows.VisualState  -   5        
State1��   
Storyboard. 5      �� .��5      W� 	 W� To$ 1X�6*    g� Duration$ 	0:00:00.4D�61    �� 
TargetName$ Border1��6F    �� TargetProperty$ (UIElement.Opacity)�6f   W� 5      $ 0X�6*   $ 	0:00:00.7D�61   $ Border2��6F   $ (UIElement.Opacity)�6f   5      5        5      -   5        
State2��. 5      �� .��5      W� $ 0X�6*   $ 	0:00:00.7D�61   $ Border1��6F   $ (UIElement.Opacity)�6f   W� 5      $ 1X�6*   $ 	0:00:00.4D�61   $ Border2��6F   $ (UIElement.Opacity)�6f   5      5        5      . 5      �� 5      5      5      .+�5   
   �� -   5        $��Border1��5   �   
������� J� Opacity$ 0Q�6&   $��1q�62   $��61��6F   $
��Left=�6R   $��	27,18,0,0q�6m   $	��Top=�6�   $	��367��6�   ���	#FFCE4F4F6�   �� 5   
   -   5        $��Border2��5   i   ���	#FF4F4FCE$ 1Q�6(   
�������$��1q�6I   $��61��6]   $	��367��6x   $��27,85,109,165q�6�   5       5!      