   M S B A M L   `   `   `  ����Q  MControlWorkbenchButton, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:ControlWorkbenchButton.Contracts ControlWorkbenchButton.Contracts  5   	   '    !ControlWorkbenchButton.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   W SWPFArchitectureModel.Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8	behaviors(http://www.wpfarchitecture.com/Behaviors  5   	   >	Contracts.clr-namespace:ControlWorkbenchButton.Contracts  5   	   ,libraryhttp://www.wpfarchitecture.com  5   	   6controls'http://www.wpfarchitecture.com/Controls  5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)    � DataContext 5	   	   /  )WPFArchitectureModel.Library.ModelLocator  *M� *Contracts:IMainWindowModel++;  5WPFArchitectureModel.Library.Behaviors.WindowBehavior   Loaded 5
   	   �� *LoadedAdapter+.��5      �  � ColumnDefinitions 5   
   �� 5      $	��150 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $	��150 �6   .+�5   
   �� $��0��6   $��0��6"   ��6/   �� *	Modules+ �� SelectedItem 6O   �� *SelectedModule+��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6!   $��0q�6:   .+�5      �� $��Center=�69   $��2q�6V   ��6    �� *Image+6V   �� 5       �� TextAlignment$ Center=�6:   $
��Wrap=�6Q   $��Center=�6e   $��2q�6�   ��6$   �� *Name+6�   5      5      5      2  ,WPFArchitectureModel.Library.Controls.Region  5   
      
RegionName$ MainContent��6   $��0��63   $��1��6@   �� 5    
   $��1��6   $��0��6$   $��2��64   $��3��6H   	 �� ResizeDirection$
	 Rows=�6S   $
��Auto��6j   $��Stretch=�6w   $��Stretch=�6�   $��0q�6�   ��5!      �� 5"      
 �� 
StartPoint$	
 0,0&�6&    �� EndPoint$	 0,1&�67   .��5#      �  � Color$ 	LightGray��6#    � Offset$ 0Q�65   � 5$      $
 Gray��6#   $	 0.5Q�60   � 5%      $ 	LightGray��6#   $ 1Q�65   5&      5(      ]� 5)   
   $��0��6   $��2��6$   $��2��68   ��. .+�5*      �� $��Benachrichtigungen��6   $��28��61   $	��Top=�6=   
�������$��Center=�6i   �� 5+      ��6   �� *
Messages+5,      5-      5.      